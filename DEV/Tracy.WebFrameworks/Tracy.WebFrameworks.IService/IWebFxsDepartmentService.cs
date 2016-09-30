using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.CommonBO;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.Frameworks.Common.Result;

namespace Tracy.WebFrameworks.IService
{
    [ServiceContract(ConfigurationName = "WebFxsDepartmentService.IWebFxsDepartmentService")]
    public interface IWebFxsDepartmentService
    {
        /// <summary>
        /// 获取指定公司下的部门
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<List<Department>> GetDepartmentByCorp(GetDepartmentByCorpRQ request);

        /// <summary>
        /// 获取指定部门下的用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<PagingResult<User>> GetUserByDepartment(GetUserByDepartmentRQ request);

        /// <summary>
        /// 获取组织机构树数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<List<Corporation>> GetOrgTreeData();

    }
}
