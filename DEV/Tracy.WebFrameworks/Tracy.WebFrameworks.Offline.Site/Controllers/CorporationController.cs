using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracy.WebFrameworks.Offline.Site.Filters;

namespace Tracy.WebFrameworks.Offline.Site.Controllers
{
    /// <summary>
    /// 公司管理
    /// </summary>
    public class CorporationController : BaseController
    {
        // GET: Corporation
        [LoginAuthorization]
        public ActionResult Index()
        {
            return View();
        }
    }
}