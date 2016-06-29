using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracy.WebFrameworks.Entity.ViewModel;

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

            //using (var factory = new ChannelFactory<IWebFxsEmployeeService>("*"))
            //{
            //    var client = factory.CreateChannel();
            //    var result = client.CheckLogin(rq);
            //    if (result.Content == true)
            //    {
            //        flag = true;

            //        //将登录信息保存到cookie
            //        Response.Cookies["LoginName"].Value = rq.LoginName;
            //        Response.Cookies["LoginName"].Expires = DateTime.Now.AddDays(7);
            //    }
            //    else
            //    {
            //        msg = result.Message;
            //    }
            //}

            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }

	}
}