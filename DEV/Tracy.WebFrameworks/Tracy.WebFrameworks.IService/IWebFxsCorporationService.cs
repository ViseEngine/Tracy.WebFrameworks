using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.CommonBO;
using Tracy.WebFrameworks.Entity.ViewModel;

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
        [OperationContract]
        WebFxsResult<string> GetCorpDepartment(GetCorpDepartmentRQ request);

        /// <summary>
        /// 添加公司
        /// </summary>
        /// <param name="request"></param>
        /// <returns>返回新添加的公司</returns>
        [OperationContract]
        WebFxsResult<Corporation> AddCorporation(AddCorporationRQ request, User loginUser);

        /// <summary>
        /// 修改公司
        /// </summary>
        /// <param name="request"></param>
        /// <param name="loginUser"></param>
        /// <returns>true:修改成功，false：修改失败</returns>
        [OperationContract]
        WebFxsResult<bool> EditCorporation(EditCorporationRQ request, User loginUser);

    }
}
