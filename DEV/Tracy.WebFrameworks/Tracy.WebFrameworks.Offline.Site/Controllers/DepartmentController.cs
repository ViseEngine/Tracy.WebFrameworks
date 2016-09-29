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

        public ActionResult Add()
        {
            return View();
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

        /// <summary>
        /// 获取组织机构树数据
        /// </summary>
        /// <param name="orgType">组织类型,是公司级还是部门级</param>
        /// <returns></returns>
        public ActionResult GetOrgTreeData(GetOrgTreeDataRQ request)
        {
            var result = string.Empty;
            StringBuilder sb = new StringBuilder();

            using (var factory = new ChannelFactory<IWebFxsDepartmentService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.GetOrgTreeData(request);
                if (rs.ReturnCode == ReturnCodeType.Success)
                {
                    var corps = rs.Content;
                    if (corps.HasValue())
                    {
                        var orgTreeType = request.OrgType.ToEnum<OrgTreeType>();
                        if (orgTreeType == OrgTreeType.Corporation)
                        {
                            sb.Append(RecursionCorp(corps, 0));
                            sb = sb.Remove(sb.Length - 2, 2);
                            result = sb.ToString();
                        }
                        if (orgTreeType == OrgTreeType.Department)
                        {
                            sb.Append(RecursionCorpDepartment(corps, 0));
                            sb = sb.Remove(sb.Length - 2, 2);
                            result = sb.ToString();
                        }
                    }
                    else
                    {
                        result = "[]";
                    }

                }

            }

            return Content(result);
        }

        #region Private method

        /// <summary>
        /// 包含公司和部门
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private string RecursionCorpDepartment(List<Corporation> list, int parentId)
        {
            StringBuilder sb = new StringBuilder();
            var corps = list.Where(p => p.ParentId == parentId).ToList();
            if (corps.HasValue())
            {
                sb.Append("[");
                for (int i = 0; i < corps.Count; i++)
                {
                    var childStr = RecursionCorpDepartment(list, corps[i].Id);
                    if (!childStr.IsNullOrEmpty())
                    {
                        sb.Append("{\"id\":\"" + corps[i].Id.ToString() + "\",\"ParentId\":\"" + corps[i].ParentId.ToString() + "\",\"text\":\"" + corps[i].Name + "\",\"children\":");
                        sb.Append(childStr);
                    }
                    else
                    {
                        //sb.Append("{\"id\":\"" + corps[i].Id.ToString() + "\",\"ParentId\":\"" + corps[i].ParentId.ToString() + "\",\"text\":\"" + corps[i].Name + "\"},");
                        sb.Append("{\"id\":\"" + corps[i].Id.ToString() + "\",\"ParentId\":\"" + corps[i].ParentId.ToString() + "\",\"text\":\"" + corps[i].Name + "\"},\"children\":");
                        var departments = corps[i].Department.ToList();
                        sb.Append(Recursion(departments, 0));
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]},");
            }
            return sb.ToString();
        }

        private string RecursionCorp(List<Corporation> list, int parentId)
        {
            StringBuilder sb = new StringBuilder();
            var childCorps = list.Where(p => p.ParentId == parentId).ToList();
            if (childCorps.HasValue())
            {
                sb.Append("[");
                for (int i = 0; i < childCorps.Count; i++)
                {
                    var childStr = RecursionCorp(list, childCorps[i].Id);
                    if (!childStr.IsNullOrEmpty())
                    {
                        sb.Append("{\"id\":\"" + childCorps[i].Id.ToString() + "\",\"ParentId\":\"" + childCorps[i].ParentId.ToString() + "\",\"text\":\"" + childCorps[i].Name + "\",\"children\":");
                        sb.Append(childStr);
                    }
                    else
                    {
                        sb.Append("{\"id\":\"" + childCorps[i].Id.ToString() + "\",\"ParentId\":\"" + childCorps[i].ParentId.ToString() + "\",\"text\":\"" + childCorps[i].Name + "\"},");
                    }

                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]},");
            }
            return sb.ToString();
        }

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
                        sb.Append("{\"id\":\"" + childDepts[i].Id.ToString() + "\",\"ParentId\":\"" + childDepts[i].ParentId.ToString() + "\",\"Code\":\"" + childDepts[i].Code + "\",\"CorpName\":\"" + childDepts[i].CorporationName + "\",\"Enabled\":\"" + childDepts[i].Enabled.Value + "\",\"Sort\":\"" + childDepts[i].Sort.Value.ToString() + "\",\"CreatedTime\":\"" + childDepts[i].CreatedTime.Value.ToString(DateFormat.DATETIME) + "\",\"text\":\"" + childDepts[i].Name + "\",\"children\":");
                        sb.Append(childStr);
                    }
                    else
                    {
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