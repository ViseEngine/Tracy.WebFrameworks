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
        /// <summary>
        /// 批量插入公司信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<bool> BatchInsert(List<Corporation> list);

    }
}
