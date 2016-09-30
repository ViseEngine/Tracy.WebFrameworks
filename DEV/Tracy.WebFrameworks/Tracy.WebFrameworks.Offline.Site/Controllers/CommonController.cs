using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.WebFrameworks.IService;
using Tracy.Frameworks.Common.Extends;
using Tracy.WebFrameworks.Entity.Enum;

namespace Tracy.WebFrameworks.Offline.Site.Controllers
{
    /// <summary>
    /// 通用
    /// </summary>
    public class CommonController : BaseController
    {
        /// <summary>
        /// 获取组织机构树数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetOrgTreeData(GetOrgTreeDataRQ request)
        {
            var result = string.Empty;
            StringBuilder sb = new StringBuilder();

            using (var factory = new ChannelFactory<IWebFxsCommonService>("*"))
            {
                var client = factory.CreateChannel();
                var rs = client.GetOrgTreeData();
                if (rs.ReturnCode == ReturnCodeType.Success)
                {
                    var corps = rs.Content;
                    if (corps.HasValue())
                    {
                        var orgTreeType = request.OrgType.ToEnum<OrgTreeType>();
                        if (orgTreeType == OrgTreeType.Corporation)//按公司
                        {
                            sb.Append(RecursionCorp(corps, 0));
                            sb = sb.Remove(sb.Length - 2, 2);
                            result = sb.ToString();
                        }
                        if (orgTreeType == OrgTreeType.Department)//按部门
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
        /// 递归所有公司和部门(无限层级)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private string RecursionCorpDepartment(List<Corporation> list, int parentId)
        {
            //TODO:还有个bug，非最底部的节点下如果有部门展示不出来
            StringBuilder sb = new StringBuilder();
            var childCorps = list.Where(p => p.ParentId == parentId).ToList();
            if (childCorps.HasValue())
            {
                sb.Append("[");
                for (int i = 0; i < childCorps.Count; i++)
                {
                    var childStr = RecursionCorpDepartment(list, childCorps[i].Id);
                    if (!childStr.IsNullOrEmpty())
                    {
                        sb.Append("{\"id\":\"" + childCorps[i].Id.ToString() + "\",\"ParentId\":\"" + childCorps[i].ParentId.ToString() + "\",\"text\":\"" + childCorps[i].Name +"\",\"attributes\":{\"url\":\"" + childCorps[i].Id + "\"}"+ "\",\"children\":");
                        sb.Append(childStr);
                    }
                    else
                    {
                        //公司下是否有部门
                        var departments = childCorps[i].Department.ToList();
                        if (departments.HasValue())
                        {
                            var departmentStr = RecursionDepartment(departments, 0);
                            sb.Append("{\"id\":\"" + childCorps[i].Id.ToString() + "\",\"ParentId\":\"" + childCorps[i].ParentId.ToString() + "\",\"text\":\"" + childCorps[i].Name + "\",\"children\":");
                            sb.Append(departmentStr);
                        }
                        else
                        {
                            sb.Append("{\"id\":\"" + childCorps[i].Id.ToString() + "\",\"ParentId\":\"" + childCorps[i].ParentId.ToString() + "\",\"text\":\"" + childCorps[i].Name + "\"},");
                        }
                    }

                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]},");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 递归所有部门
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
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
                        sb.Append("{\"id\":\"" + childDepts[i].Id.ToString() + "\",\"ParentId\":\"" + childDepts[i].ParentId.ToString() + "\",\"text\":\"" + childDepts[i].Name + "\",\"children\":");
                        sb.Append(childStr);
                    }
                    else
                    {
                        sb.Append("{\"id\":\"" + childDepts[i].Id.ToString() + "\",\"ParentId\":\"" + childDepts[i].ParentId.ToString() + "\",\"text\":\"" + childDepts[i].Name + "\"},");
                    }

                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]},");
            }
            return sb.ToString();
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

        #endregion

    }
}