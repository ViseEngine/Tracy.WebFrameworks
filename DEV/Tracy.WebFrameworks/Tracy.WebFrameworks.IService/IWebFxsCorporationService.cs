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

        /// <summary>
        /// 查询选中公司下的所有部门并分页显示
        /// </summary>
        /// <param name="corpIds"></param>
        /// <returns></returns>
        //[OperationContract]
        //WebFxsResult<string> GetCorpDepartment(string corpIds);

    }
}
