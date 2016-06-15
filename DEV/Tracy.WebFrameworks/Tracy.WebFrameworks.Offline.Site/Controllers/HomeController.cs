using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.WebFrameworks.IService;

namespace Tracy.WebFrameworks.Offline.Site.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 检查登录
        /// </summary>
        /// <returns></returns>
        public JsonResult CheckLogin(CheckLoginRQ rq)
        {
            var flag = false;
            var msg = string.Empty;

            using (var factory = new ChannelFactory<IWebFxsEmployeeService>("*"))
            {
                var client = factory.CreateChannel();
                var result = client.CheckLogin(rq);
                if (result.Content == true)
                {
                    flag = true;

                    //将登录信息保存到cookie
                    Response.Cookies["LoginName"].Value = rq.LoginName;
                    Response.Cookies["LoginName"].Expires = DateTime.Now.AddDays(7);
                }
                else
                {
                    msg = result.Message;
                }
            }

            return Json(new { Success = flag, Message = msg });
        }
    }
}