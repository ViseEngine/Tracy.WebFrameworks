using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.CommonBO;
using Tracy.WebFrameworks.Entity.ViewModel;

namespace Tracy.WebFrameworks.IService
{
    [ServiceContract(ConfigurationName = "WebFxsEmployeeService.IWebFxsEmployeeService")]
    public interface IWebFxsEmployeeService
    {
        #region IRepository
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<Employee> GetById(int id);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<Employee> Insert(Employee item);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<bool> Update(Employee item);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<bool> Delete(int id);
        #endregion

        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<bool> CheckLogin(CheckLoginRQ rq);

    }
}
