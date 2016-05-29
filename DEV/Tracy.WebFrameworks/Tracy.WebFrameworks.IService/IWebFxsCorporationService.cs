using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.CommonBO;

namespace Tracy.WebFrameworks.IService
{
    [ServiceContract(ConfigurationName = "WebFxsCorporationService.IWebFxsCorporationService")]
    public interface IWebFxsCorporationService
    {
        #region IRepository
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<IEnumerable<Corporation>> GetAll();

        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<Corporation> GetById(int id);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<Corporation> Insert(Corporation item);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<bool> Update(Corporation item);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<bool> Delete(int id); 
        #endregion
    }
}
