using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using Tracy.Frameworks.Common.Extends;
using Tracy.WebFrameworks.IService;

namespace Tracy.WebFrameworks.Offline.Site.Controllers
{
    public class ButtonController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 获取当前用户当前页面可访问的按钮
        /// </summary>
        /// <param name="menuCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetButtonByUserIdAndMenuCode(string menuCode, string pageName)
        {
            if (menuCode.IsNullOrEmpty())
            {
                throw new ArgumentNullException("menuCode");
            }

            var result = string.Empty;
            using (var factory = new ChannelFactory<IWebFxsButtonService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.GetButtonByUserIdAndMenuCode(menuCode, pageName, CurrentUserInfo.Id);
                if (rs.ReturnCode == Entity.ReturnCodeType.Success)
                {
                    result = rs.Content;
                }
            }

            return Content(result);
        }

    }
}