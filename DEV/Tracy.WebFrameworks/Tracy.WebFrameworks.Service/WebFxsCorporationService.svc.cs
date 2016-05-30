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
using System.Linq.Expressions;

namespace Tracy.WebFrameworks.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[WcfServiceCounter(SystemCode = "WebFrameworks", Source = "Offline.Service")]
    public class WebFxsCorporationService : IWebFxsCorporationService
    {
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
            //var corporation = _repository.GetById(id);
            //if (corporation != null)
            //{
            //    result.ReturnCode = ReturnCodeType.Success;
            //    result.Content = corporation;
            //}
            return result;
        }

        ///// <summary>
        ///// 依据条件查询
        ///// </summary>
        ///// <param name="filter"></param>
        ///// <param name="orderby"></param>
        ///// <returns></returns>
        //public WebFxsResult<IEnumerable<Corporation>> GetByCondition(Expression<Func<Corporation, bool>> filter = null, Func<IQueryable<Corporation>, IOrderedQueryable<Corporation>> orderby = null)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public WebFxsResult<Corporation> Insert(Corporation item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public WebFxsResult<bool> Update(Corporation item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebFxsResult<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
