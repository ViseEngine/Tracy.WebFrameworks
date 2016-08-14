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

namespace Tracy.WebFrameworks.Offline.Site.Controllers
{
    /// <summary>
    /// 部门管理
    /// </summary>
    public class DepartmentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取指定公司下的部门
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
                        sb.Append(Recursion(depts, 0));
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

        private string Recursion(List<Department> list, int parentId)
        {
            StringBuilder sb = new StringBuilder();
            var childDepts = list.Where(p => p.ParentId == parentId).ToList();
            if (childDepts.HasValue())
            {
                sb.Append("[");
                for (int i = 0; i < childDepts.Count; i++)
                {
                    var childStr = Recursion(list, childDepts[i].Id);
                    if (!childStr.IsNullOrEmpty())
                    {
                        sb.Append("{\"id\":\"" + childDepts[i].Id.ToString() + "\",\"ParentId\":\"" + childDepts[i].ParentId.ToString() + "\",\"Code\":\"" + childDepts[i].Code + "\",\"Enabled\":\"" + childDepts[i].Enabled.Value + "\",\"Sort\":\"" + childDepts[i].Sort.Value.ToString() + "\",\"CreatedTime\":\"" + childDepts[i].CreatedTime.Value.ToString(DateFormat.DATETIME) + "\",\"text\":\"" + childDepts[i].Name + "\",\"children\":");
                        sb.Append(childStr);
                    }
                    else
                    {
                        sb.Append("{\"id\":\"" + childDepts[i].Id.ToString() + "\",\"ParentId\":\"" + childDepts[i].ParentId.ToString() + "\",\"Code\":\"" + childDepts[i].Code + "\",\"Enabled\":\"" + childDepts[i].Enabled.Value + "\",\"Sort\":\"" + childDepts[i].Sort.Value.ToString() + "\",\"CreatedTime\":\"" + childDepts[i].CreatedTime.Value.ToString(DateFormat.DATETIME) + "\",\"text\":\"" + childDepts[i].Name + "\"},");
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