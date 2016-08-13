using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using Tracy.WebFrameworks.Offline.Site.Filters;
using Tracy.WebFrameworks.IService;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.ViewModel;

namespace Tracy.WebFrameworks.Offline.Site.Controllers
{
    /// <summary>
    /// 公司管理
    /// </summary>
    public class CorporationController : BaseController
    {
        [LoginAuthorization]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [LoginAuthorization]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddCorporationRQ request)
        {
            var flag = false;
            var msg = string.Empty;

            using (var factory = new ChannelFactory<IWebFxsCorporationService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.AddCorporation(request, base.CurrentUserInfo);
                if (rs.ReturnCode== ReturnCodeType.Success)
                {
                    flag = true;
                    msg = "添加成功!";
                }
                else
                {
                    msg = "添加失败!";
                }
            }

            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [LoginAuthorization]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(EditCorporationRQ request)
        {
            var flag = false;
            var msg = string.Empty;

            using (var factory = new ChannelFactory<IWebFxsCorporationService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.EditCorporation(request, base.CurrentUserInfo);
                if (rs.ReturnCode== ReturnCodeType.Success)
                {
                    flag = true;
                    msg = "修改成功!";
                }
                else
                {
                    msg = "修改失败!";
                }
            }
            
            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查询所有公司
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAll()
        {
            var result = string.Empty;
            using (var factory = new ChannelFactory<IWebFxsCorporationService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.GetAll();
                if (rs.ReturnCode == Entity.ReturnCodeType.Success)
                {
                    result = rs.Content;
                }
            }

            return Content(result);
        }

        /// <summary>
        /// 查询选中公司下的所有部门
        /// </summary>
        /// <param name="CorpIds">公司包括子公司id</param>
        /// <returns></returns>
        public ActionResult GetCorpDepartment(GetCorpDepartmentRQ request, int page, int rows)
        {
            var result = string.Empty;
            if (request == null)
            {
                request = new GetCorpDepartmentRQ();
            }
            request.PageIndex = page;
            request.PageSize = rows;

            using (var factory = new ChannelFactory<IWebFxsCorporationService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.GetCorpDepartment(request);
                if (rs.ReturnCode == Entity.ReturnCodeType.Success)
                {
                    result = rs.Content;
                }
            }

            return Content(result);
        }

    }
}