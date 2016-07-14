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
    public class LoginController : BaseController
    {
        /// <summary>
        /// 登录页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 检查用户是否已登录
        /// </summary>
        /// <returns>如果已登录，则直接跳转到首页</returns>
        [HttpPost]
        public ActionResult CheckIfLogin()
        {
            //从FormsAuthenticationTicket取出票证，然后校验
            var flag = false;
            var msg = string.Empty;


            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckLogin(CheckLoginRequest request)
        {
            //验证输入的用户名和密码
            var flag = true;
            var msg = string.Empty;

            using (var factory = new ChannelFactory<IWebFxsEmployeeService>("*"))
            {
                var client = factory.CreateChannel();
                var result = client.CheckLogin(request);
                if (result.ReturnCode == Entity.ReturnCodeType.Success)
                {
                    //成功
                    //1.记登录日志
                    //2.将登录token保存到cookie中
                    var emp= result.Content;
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
                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    if (dateCookieExpires != new DateTime(9999, 12, 31))
                    {
                        cookie.Expires = dateCookieExpires;
                    }
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    flag = false;
                    msg = result.Message;
                }
            }

            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }

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

    }
}