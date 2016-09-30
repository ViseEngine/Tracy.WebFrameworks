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
using System.Text;
using Tracy.Frameworks.Common.Extends;
using Tracy.Frameworks.Common.Const;

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
                if (rs.ReturnCode == ReturnCodeType.Success)
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
                if (rs.ReturnCode == ReturnCodeType.Success)
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
        /// 删除公司
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(DeleteCorporationRQ request)
        {
            var flag = false;
            var msg = string.Empty;

            using (var factory = new ChannelFactory<IWebFxsCorporationService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.DeleteCorporation(request);
                if (rs.ReturnCode == ReturnCodeType.Success)
                {
                    flag = true;
                    msg = "删除成功!";
                }
                else
                {
                    msg = "删除失败!";
                }
            }

            return Json(new { success = flag, msg = msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查询所有公司,并且以树形展示
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAll()
        {
            var result = string.Empty;
            StringBuilder sb = new StringBuilder();
            using (var factory = new ChannelFactory<IWebFxsCorporationService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.GetAllCorps();
                if (rs.ReturnCode == Entity.ReturnCodeType.Success)
                {
                    var corps = rs.Content;
                    if (corps.HasValue())
                    {
                        sb.Append(RecursionCorp(corps, 0));
                        sb = sb.Remove(sb.Length - 2, 2);
                        result = sb.ToString();
                    }
                    else
                    {
                        result = "[]";
                    }
                }
            }

            return Content(result);
        }

        /// <summary>
        /// 递归所有公司
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private string RecursionCorp(List<Corporation> list, int parentId)
        {
            StringBuilder sb = new StringBuilder();
            var childCorps = list.Where(p => p.ParentId == parentId).ToList();
            if (childCorps.HasValue())
            {
                sb.Append("[");
                for (int i = 0; i < childCorps.Count; i++)
                {
                    var childCorpStr = RecursionCorp(list, childCorps[i].Id);
                    if (!childCorpStr.IsNullOrEmpty())
                    {
                        sb.Append("{\"id\":\"" + childCorps[i].Id.ToString() + "\",\"ParentId\":\"" + childCorps[i].ParentId.ToString() + "\",\"Code\":\"" + childCorps[i].Code + "\",\"Enabled\":\"" + childCorps[i].Enabled.Value + "\",\"Sort\":\"" + childCorps[i].Sort.Value.ToString() + "\",\"CreatedTime\":\"" + childCorps[i].CreatedTime.Value.ToString(DateFormat.DATETIME) + "\",\"text\":\"" + childCorps[i].Name + "\",\"children\":");
                        sb.Append(childCorpStr);
                    }
                    else
                    {
                        sb.Append("{\"id\":\"" + childCorps[i].Id.ToString() + "\",\"ParentId\":\"" + childCorps[i].ParentId.ToString() + "\",\"Code\":\"" + childCorps[i].Code + "\",\"Enabled\":\"" + childCorps[i].Enabled.Value + "\",\"Sort\":\"" + childCorps[i].Sort.Value.ToString() + "\",\"CreatedTime\":\"" + childCorps[i].CreatedTime.Value.ToString(DateFormat.DATETIME) + "\",\"text\":\"" + childCorps[i].Name + "\"},");
                    }

                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]},");
            }
            return sb.ToString();
        }

    }
}