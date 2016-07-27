using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tracy.WebFrameworks.Entity;
using Tracy.Frameworks.Common.Extends;

namespace Tracy.WebFrameworks.Offline.Site.Controllers
{
    /// <summary>
    /// 父控制器，包含通用操作
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 保存当前登录用户会话
        /// </summary>
        public User CurrentUserInfo { get; set; }

        /// <summary>
        /// Action执行前调用
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                FormsIdentity id = (FormsIdentity)filterContext.HttpContext.User.Identity;
                FormsAuthenticationTicket tickets = id.Ticket;

                CurrentUserInfo = tickets.UserData.FromJson<User>();   
            }
        }



	}
}