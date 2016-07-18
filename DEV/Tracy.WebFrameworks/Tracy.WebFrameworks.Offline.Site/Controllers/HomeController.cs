using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.WebFrameworks.IService;
using Tracy.Frameworks.Common.Extends;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.ViewModel;

namespace Tracy.WebFrameworks.Offline.Site.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {
            return View();
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

            //检查cookie里的用户信息是否与DB中的用户信息一致
            if (Request.IsAuthenticated)
            {
                msg = "nocookie";
                return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
            }

            FormsIdentity id = (FormsIdentity)HttpContext.User.Identity;
            FormsAuthenticationTicket tickets = id.Ticket;

            var empFromCookie = tickets.UserData.FromJson<Employee>();
            using (var factory = new ChannelFactory<IWebFxsEmployeeService>("*"))
            {
                var client = factory.CreateChannel();
                var result = client.CheckLogin(new CheckLoginRequest { loginName = empFromCookie.UserId, loginPwd = empFromCookie.UserPwd });
                if (result.ReturnCode== ReturnCodeType.Success)
                {
                    var empFromDB = result.Content;

                }


            }

            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }


    }
}