using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        /// 查询所有公司，输出json字符串
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<string> GetAll();

    }
}
