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
using Tracy.WebFrameworks.Data;
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.RepositoryFactory;

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
            return repository.GetByCondition(filter:filter, orderby: orderby);
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
                ReturnCode= ReturnCodeType.Error,
                Content= string.Empty
            };
            StringBuilder sb = new StringBuilder();
            var allCorps = this.GetByCondition().ToList();
            if (allCorps.HasValue())
            {
                sb.Append(Recursion(allCorps, 0));
                sb = sb.Remove(sb.Length-2, 2);
            }

            result.Content = sb.ToString();
            if (!result.Content.IsNullOrEmpty())
            {
                result.ReturnCode = ReturnCodeType.Success;
            }

            return result;
        }

        #region Private method

        private string Recursion(List<Corporation> list, int parentId)
        {
            StringBuilder sb = new StringBuilder();
            var childCorps= list.Where(p => p.ParentId == parentId).ToList();
            if (childCorps.HasValue())
            {
                sb.Append("[");
                for (int i = 0; i < childCorps.Count; i++)
                {
                    var childStr = Recursion(list, childCorps[i].Id);
                    if (!childStr.IsNullOrEmpty())
                    {
                        sb.Append("{\"id\":\"" + childCorps[i].Id.ToString() + "\",\"ParentId\":\"" + childCorps[i].ParentId.ToString() + "\",\"Code\":\"" + childCorps[i].Code + "\",\"Enabled\":\""+childCorps[i].Enabled.Value+"\",\"Sort\":\"" + childCorps[i].Sort.Value.ToString() + "\",\"CreatedTime\":\"" + childCorps[i].CreatedTime.Value.ToString(DateFormat.DATETIME) + "\",\"text\":\"" + childCorps[i].Name + "\",\"children\":");
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
