using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.WebFrameworks.IService;
using Tracy.Frameworks.Common.Extends;
using System.Text;
using Tracy.Frameworks.Common.Const;
using Tracy.WebFrameworks.Entity.Enum;
using Tracy.WebFrameworks.Offline.Site.Filters;

namespace Tracy.WebFrameworks.Offline.Site.Controllers
{
    /// <summary>
    /// 部门管理
    /// </summary>
    public class DepartmentController : BaseController
    {
        [LoginAuthorization]
        public ActionResult Index()
        {
            return View();
        }

        [LoginAuthorization]
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(AddDepartmentRQ request)
        {
            var flag = false;
            var msg = string.Empty;

            using (var factory = new ChannelFactory<IWebFxsDepartmentService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.AddDepartment(request, base.CurrentUserInfo);
                if (rs.ReturnCode == ReturnCodeType.Success && rs.Content == true)
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

        [LoginAuthorization]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(EditDepartmentRQ request)
        {
            var flag = false;
            var msg = string.Empty;

            using (var factory = new ChannelFactory<IWebFxsDepartmentService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.EditDepartment(request, base.CurrentUserInfo);
                if (rs.ReturnCode == ReturnCodeType.Success && rs.Content == true)
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

        [HttpPost]
        public ActionResult Delete(DeleteDepartmentRQ request)
        {
            var flag = false;
            var msg = string.Empty;

            using (var factory = new ChannelFactory<IWebFxsDepartmentService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.DeleteDepartment(request);
                if (rs.ReturnCode == ReturnCodeType.Success && rs.Content == true)
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
        /// 获取指定公司下的部门
        /// 如果没有指定则获取所有公司下的所有部门
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDepartmentByCorp(GetDepartmentByCorpRQ request)
        {
            var result = string.Empty;
            StringBuilder sb = new StringBuilder();
            using (var factory = new ChannelFactory<IWebFxsDepartmentService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.GetDepartmentByCorp(request);
                if (rs.ReturnCode == Entity.ReturnCodeType.Success)
                {
                    var depts = rs.Content;
                    if (depts.HasValue())
                    {
                        sb.Append(RecursionDepartment(depts, 0));
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
        /// 获取部门下的所有用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetUserByDepartment(GetUserByDepartmentRQ request, int page, int rows)
        {
            var result = string.Empty;
            if (request == null)
            {
                request = new GetUserByDepartmentRQ();
            }
            request.PageIndex = page;
            request.PageSize = rows;
            using (var factory = new ChannelFactory<IWebFxsDepartmentService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.GetUserByDepartment(request);
                if (rs.ReturnCode == ReturnCodeType.Success)
                {
                    result = "{\"total\": " + rs.Content.TotalCount + ",\"rows\":" + rs.Content.Entities.ToJson(dateTimeFormat: DateFormat.DATETIME) + "}";
                }
            }

            return Content(result);
        }

        #region Private method
        private string RecursionDepartment(List<Department> list, int parentId)
        {
            StringBuilder sb = new StringBuilder();
            var childDepts = list.Where(p => p.ParentId == parentId).ToList();
            if (childDepts.HasValue())
            {
                sb.Append("[");
                for (int i = 0; i < childDepts.Count; i++)
                {
                    var childStr = RecursionDepartment(list, childDepts[i].Id);
                    if (!childStr.IsNullOrEmpty())
                    {
                        sb.Append("{\"id\":\"" + childDepts[i].Id.ToString() + "\",\"ParentId\":\"" + childDepts[i].ParentId.ToString() + "\",\"Code\":\"" + childDepts[i].Code + "\",\"CorpName\":\"" + childDepts[i].CorporationName + "\",\"Enabled\":\"" + childDepts[i].Enabled.Value + "\",\"Sort\":\"" + childDepts[i].Sort.Value.ToString() + "\",\"CreatedTime\":\"" + childDepts[i].CreatedTime.Value.ToString(DateFormat.DATETIME) + "\",\"text\":\"" + childDepts[i].Name + "\",\"children\":");
                        sb.Append(childStr);
                    }
                    else
                    {
                        //sb.Append("{\"id\":\"" + childDepts[i].Id.ToString() + "\",\"ParentId\":\"" + childDepts[i].ParentId.ToString() + "\",\"Code\":\"" + childDepts[i].Code + "\",\"CorpName\":\"" + childDepts[i].CorporationName + "\",\"Enabled\":\"" + childDepts[i].Enabled.Value + "\",\"Sort\":\"" + childDepts[i].Sort.Value.ToString() + "\",\"CreatedTime\":\"" + childDepts[i].CreatedTime.Value.ToString(DateFormat.DATETIME) + "\",\"attributes\":{\"ParentId\":\"" + childDepts[i].ParentId.ToString() + "\"}\",\"text\":\"" + childDepts[i].Name + "\"},");
                        sb.Append("{\"id\":\"" + childDepts[i].Id.ToString() + "\",\"ParentId\":\"" + childDepts[i].ParentId.ToString() + "\",\"Code\":\"" + childDepts[i].Code + "\",\"CorpName\":\"" + childDepts[i].CorporationName + "\",\"Enabled\":\"" + childDepts[i].Enabled.Value + "\",\"Sort\":\"" + childDepts[i].Sort.Value.ToString() + "\",\"CreatedTime\":\"" + childDepts[i].CreatedTime.Value.ToString(DateFormat.DATETIME) + "\",\"text\":\"" + childDepts[i].Name + "\"},");
                    }

                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]},");
            }
            return sb.ToString();
        }

        #endregion

    }
}