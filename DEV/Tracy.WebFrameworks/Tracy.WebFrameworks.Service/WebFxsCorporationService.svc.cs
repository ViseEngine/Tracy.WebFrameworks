using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.CommonBO;
using Tracy.WebFrameworks.IService;
using Tracy.WebFrameworks.Common.Helper;
using System.Linq.Expressions;
using Tracy.Frameworks.Common.Extends;
using Tracy.Frameworks.Common.Const;
using Tracy.Frameworks.Common.Result;
using Tracy.WebFrameworks.Data;
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.RepositoryFactory;
using Tracy.WebFrameworks.Entity.ViewModel;

namespace Tracy.WebFrameworks.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[WcfServiceCounter(SystemCode = "WebFrameworks", Source = "Offline.Service")]
    public class WebFxsCorporationService : IWebFxsCorporationService
    {
        private static readonly ICorporationRepository repository = Factory.GetCorporationRepository();

        #region IRepository
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Corporation GetById(int id)
        {
            return repository.GetById(id);
        }

        /// <summary>
        /// 依条件表达式查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public IEnumerable<Corporation> GetByCondition(Expression<Func<Corporation, bool>> filter = null, Func<IQueryable<Corporation>, IOrderedQueryable<Corporation>> orderby = null)
        {
            return repository.GetByCondition(filter: filter, orderby: orderby);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Corporation Insert(Corporation item)
        {
            return repository.Insert(item);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(Corporation item)
        {
            return repository.Update(item);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        #endregion

        /// <summary>
        /// 查询所有公司，输出json字符串
        /// </summary>
        /// <returns></returns>
        public WebFxsResult<string> GetAll()
        {
            var result = new WebFxsResult<string>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = string.Empty
            };
            StringBuilder sb = new StringBuilder();
            var allCorps = this.GetByCondition().ToList();
            if (allCorps.HasValue())
            {
                sb.Append(Recursion(allCorps, 0));
                sb = sb.Remove(sb.Length - 2, 2);
            }

            result.Content = sb.ToString();
            if (!result.Content.IsNullOrEmpty())
            {
                result.ReturnCode = ReturnCodeType.Success;
            }

            return result;
        }

        /// <summary>
        /// 查询选中公司下的所有部门并分页显示
        /// </summary>
        /// <param name="corpIds"></param>
        /// <returns></returns>
        public WebFxsResult<string> GetCorpDepartment(GetCorpDepartmentRQ request)
        {
            var result = new WebFxsResult<string>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = string.Empty
            };

            var pagingResult = repository.GetCorpDepartmentByPaging(request);
            result.Content = "{\"total\": " + pagingResult.TotalCount + ",\"rows\":" + pagingResult.Entities.ToJson(dateTimeFormat: DateFormat.DATETIME) + "}";
            result.ReturnCode = ReturnCodeType.Success;

            return result;
        }

        /// <summary>
        /// 添加公司
        /// </summary>
        /// <param name="request"></param>
        /// <returns>返回新添加的公司</returns>
        public WebFxsResult<Corporation> AddCorporation(AddCorporationRQ request, User loginUser)
        {
            var result = new WebFxsResult<Corporation>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = new Corporation()
            };

            var item = new Corporation
            {
                Name = request.Name,
                Code = request.Code,
                ParentId = request.ParentId,
                Sort = request.Sort,
                Enabled = true,//默认启用
                CreatedBy = loginUser.UserId,//当前登录人
                CreatedTime = DateTime.Now
            };
            var rs = Insert(item);
            if (rs != null)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = rs;
            }

            return result;
        }

        /// <summary>
        /// 修改公司
        /// </summary>
        /// <param name="request"></param>
        /// <param name="loginUser"></param>
        /// <returns>true:修改成功，false：修改失败</returns>
        public WebFxsResult<bool> EditCorporation(EditCorporationRQ request, User loginUser)
        {
            var result = new WebFxsResult<bool>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = false
            };

            var item = new Corporation
            {
                Id = request.Id,
                Name = request.Name,
                Sort = request.Sort,
                LastUpdatedBy = loginUser.UserId,
                LastUpdatedTime = DateTime.Now
            };
            var rs = Update(item);
            if (rs == true)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = rs;
            }

            return result;
        }

        /// <summary>
        /// 删除公司
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public WebFxsResult<bool> DeleteCorporation(DeleteCorporationRQ request)
        {
            //删除所选公司包括子公司
            //删除公司下的所有部门包括子部门
            //解除部门与用户的关系
            var result = new WebFxsResult<bool>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = false
            };

            var rs = repository.DeleteCorporation(request);
            if (rs == true)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = true;
            }

            return result;
        }

        #region Private method

        private string Recursion(List<Corporation> list, int parentId)
        {
            StringBuilder sb = new StringBuilder();
            var childCorps = list.Where(p => p.ParentId == parentId).ToList();
            if (childCorps.HasValue())
            {
                sb.Append("[");
                for (int i = 0; i < childCorps.Count; i++)
                {
                    var childStr = Recursion(list, childCorps[i].Id);
                    if (!childStr.IsNullOrEmpty())
                    {
                        sb.Append("{\"id\":\"" + childCorps[i].Id.ToString() + "\",\"ParentId\":\"" + childCorps[i].ParentId.ToString() + "\",\"Code\":\"" + childCorps[i].Code + "\",\"Enabled\":\"" + childCorps[i].Enabled.Value + "\",\"Sort\":\"" + childCorps[i].Sort.Value.ToString() + "\",\"CreatedTime\":\"" + childCorps[i].CreatedTime.Value.ToString(DateFormat.DATETIME) + "\",\"text\":\"" + childCorps[i].Name + "\",\"children\":");
                        sb.Append(childStr);
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


        #endregion

    }
}
