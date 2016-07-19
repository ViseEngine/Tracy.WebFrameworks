using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.WebFrameworks.IService;
using Tracy.Frameworks.Common.Extends;

namespace Tracy.WebFrameworks.Offline.Site.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(CheckLoginRequest request)
        {
            //验证输入的用户名和密码
            var flag = false;
            var msg = string.Empty;

            using (var factory = new ChannelFactory<IWebFxsCommonService>("*"))
            {
                var client = factory.CreateChannel();
                request.loginPwd = request.loginPwd.To32bitMD5();
                var result = client.CheckLogin(request);
                if (result.ReturnCode == Entity.ReturnCodeType.Success)
                {
                    var emp = result.Content;
                    if (emp == null)
                    {
                        msg = "用户名或密码错误!";
                        return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
                    }
                    if (emp.Enabled.Value == false)
                    {
                        msg = "该用户已被禁用,请联系系统管理员!";
                        return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
                    }

                    DateTime dateCookieExpires = GetCookieExpires(request);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                    (
                        2,
                        emp.UserId,
                        DateTime.Now,
                        dateCookieExpires,
                        false,
                        emp.ToJson()
                    );
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    if (dateCookieExpires != new DateTime(9999, 12, 31))
                    {
                        cookie.Expires = dateCookieExpires;
                    }
                    Response.Cookies.Add(cookie);

                    flag = true;
                }
            }

            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 检查是否已登录
        /// </summary>
        /// <returns></returns>
        public ActionResult IfLogin()
        {
            var flag = false;
            var msg = string.Empty;

            if (!Request.IsAuthenticated)
            {
                msg = "no cookie";
                return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
            }

            var id = (FormsIdentity)HttpContext.User.Identity;
            var ticket = id.Ticket;
            var emp = ticket.UserData.FromJson<Employee>();
            using (var factory = new ChannelFactory<IWebFxsCommonService>("*"))
            {
                var client = factory.CreateChannel();
                var result = client.CheckLogin(new CheckLoginRequest() { loginName = emp.UserId, loginPwd = emp.UserPwd });
                if (result.ReturnCode == ReturnCodeType.Success)
                {
                    var emp1 = result.Content;
                    if (emp1 == null)
                    {
                        msg = "用户名或密码错误!";
                        return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
                    }
                    if (emp1.Enabled.Value == false)
                    {
                        msg = "该用户已被禁用,请联系系统管理员!";
                        return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
                    }

                    flag = true;//已登录过并且cookie在有效期内
                    msg = "已登录过,正在为你跳转,请稍后!";
                }
            }

            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Json(new { success = true, msg = "退出成功!" }, JsonRequestBehavior.AllowGet);
        }

        #region Private method
        /// <summary>
        /// 获取cookie过期时间
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private DateTime GetCookieExpires(CheckLoginRequest request)
        {
            var dateCookieExpires = DateTime.MaxValue;
            switch (request.remember)
            {
                case "notremember":
                    dateCookieExpires = new DateTime(9999, 12, 31);
                    break;
                case "oneday":
                    dateCookieExpires = DateTime.Now.AddDays(1);
                    break;
                case "sevenday":
                    dateCookieExpires = DateTime.Now.AddDays(7);
                    break;
                case "onemouth":
                    dateCookieExpires = DateTime.Now.AddDays(30);
                    break;
                case "oneyear":
                    dateCookieExpires = DateTime.Now.AddDays(365);
                    break;
                default:
                    dateCookieExpires = new DateTime(9999, 12, 31);
                    break;
            }
            return dateCookieExpires;
        } 
        #endregion

    }
}