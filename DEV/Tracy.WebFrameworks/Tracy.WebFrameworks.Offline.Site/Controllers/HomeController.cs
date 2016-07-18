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


            return View();
        }


    }
}