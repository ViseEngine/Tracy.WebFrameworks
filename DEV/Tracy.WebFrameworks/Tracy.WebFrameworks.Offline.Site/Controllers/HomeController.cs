using System;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.WebFrameworks.IService;
using Tracy.Frameworks.Common.Extends;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Offline.Site.Filters;

namespace Tracy.WebFrameworks.Offline.Site.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [LoginAuthorization]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 首次登录,需修改密码
        /// </summary>
        /// <returns></returns>
        [LoginAuthorization]
        public ActionResult FirstLogin()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FirstLogin(FirstLoginRequest request)
        {
            var flag = false;
            var msg = string.Empty;

            //只能修改当前登录用户的密码
            //新密码不能和原密码一样
            //修改成功需要重新生成cookie
            if (CurrentUserInfo == null || CurrentUserInfo.EmployeeID != request.EmployeeId)
            {
                msg = "未知错误,重置密码失败";
                return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
            }

            if (CurrentUserInfo.UserPwd.Equals(request.NewPwd.To32bitMD5()))
            {
                msg = "新密码不能和默认密码一样!";
                return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
            }

            using (var factory = new ChannelFactory<IWebFxsCommonService>("*"))
            {
                var client = factory.CreateChannel();
                var result = client.InitUserPwd(request);
                if (result.ReturnCode == ReturnCodeType.Success && result.Content == true)
                {
                    //更新cookie
                    FormsIdentity id = (FormsIdentity)HttpContext.User.Identity;
                    FormsAuthenticationTicket ticketOld = id.Ticket;
                    CurrentUserInfo.UserPwd= request.NewPwd.To32bitMD5();
                    CurrentUserInfo.IsChangePwd = true;

                    FormsAuthentication.SignOut();
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                    (
                        2,
                        CurrentUserInfo.UserId,
                        DateTime.Now,
                        ticketOld.Expiration,
                        false,
                        CurrentUserInfo.ToJson()
                    );
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    if (ticket.Expiration != new DateTime(9999, 12, 31))
                    { 
                        cookie.Expires = ticketOld.Expiration;
                    }
                    HttpContext.Response.Cookies.Add(cookie);

                    flag = true;
                    msg = "重置密码成功";
                }
                else
                {
                    msg = "重置密码失败!";
                    return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [LoginAuthorization]
        public ActionResult ChangePwd()
        {
            return View();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePwd(ChangePwdRequest request)
        {
            //更新密码
            //更新密码成功后清除cookie，然后登录的时候会重写cookie
            var flag = false;
            var msg = string.Empty;

            var originalPwd = request.OriginalPwd.To32bitMD5();
            var newPwd = request.NewPwd.To32bitMD5();
            if (!originalPwd.Equals(CurrentUserInfo.UserPwd))
            {
                msg = "原密码不正确!";
                return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
            }

            using (var factory = new ChannelFactory<IWebFxsCommonService>("*"))
            {
                var client = factory.CreateChannel();
                request.EmployeeId = CurrentUserInfo.EmployeeID;
                request.NewPwd = newPwd;
                var result = client.ChangePwd(request);
                if (result.ReturnCode== ReturnCodeType.Success && result.Content== true)
                {
                    //修改成功要清除cookie然后到登录页面重写cookie
                    FormsAuthentication.SignOut();
                    flag = true;
                    msg = "修改成功,正在跳转到登陆页面！";

                }
                else
                {
                    msg = "修改失败!";
                }
            }

            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 获取该用户所拥有的菜单权限
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserMenu()
        {
            using (var factory = new ChannelFactory<IWebFxsCommonService>("*"))
            {
                var client = factory.CreateChannel();
                var result = client.GetUserMenu(CurrentUserInfo.EmployeeID);
                return Content(result.Content);
            }
        }

        /// <summary>
        /// 获取该用户的信息并再次验证cookie
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserInfo()
        {
            var flag = false;
            var msg = "";

            //能走到这里说明cookie已经验证通过
            FormsIdentity id = (FormsIdentity)HttpContext.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            msg = ticket.UserData;
            if (!msg.IsNullOrEmpty())
            {
                flag = true;                
            }

            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }


    }
}