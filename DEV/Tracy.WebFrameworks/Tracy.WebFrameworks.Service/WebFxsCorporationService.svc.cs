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
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.Repository.Factory;
using System.Linq.Expressions;
using Tracy.Frameworks.Common.Extends;

namespace Tracy.WebFrameworks.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[WcfServiceCounter(SystemCode = "WebFrameworks", Source = "Offline.Service")]
    public class WebFxsCorporationService : IWebFxsCorporationService
    {
        private ICorporationRepository repository = CorporationRepositoryFactory.GetInstance();

        #region IRepository

        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebFxsResult<Corporation> GetById(int id)
        {
            var result = new WebFxsResult<Corporation>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = new Corporation()
            };
            var corporation = repository.GetById(id);
            if (corporation != null)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = corporation;
            }
            return result;
        }

        /// <summary>
        /// 依据条件查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public WebFxsResult<IEnumerable<Corporation>> GetByCondition(Expression<Func<Corporation, bool>> filter = null, Func<IQueryable<Corporation>, IOrderedQueryable<Corporation>> orderby = null)
        {
            var result = new WebFxsResult<IEnumerable<Corporation>>() 
            {
                ReturnCode= ReturnCodeType.Error,
                Content= new List<Corporation>()
            };
            var corporations= repository.GetByCondition(filter: filter, orderby: orderby);
            if (corporations!= null)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = corporations;
            }

            return result;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public WebFxsResult<Corporation> Insert(Corporation item)
        {
            var result = new WebFxsResult<Corporation>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = new Corporation()
            };
            var corporation = repository.Insert(item);
            if (corporation != null)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = corporation;
            }

            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public WebFxsResult<bool> Update(Corporation item)
        {
            var result = new WebFxsResult<bool>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = false
            };
            var flag = repository.Update(item);
            if (flag)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = true;
            }

            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebFxsResult<bool> Delete(int id)
        {
            var result = new WebFxsResult<bool>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = false
            };
            var flag = repository.Delete(id);
            if (flag)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = true;
            }

            return result;
        }
        #endregion

    }
}
