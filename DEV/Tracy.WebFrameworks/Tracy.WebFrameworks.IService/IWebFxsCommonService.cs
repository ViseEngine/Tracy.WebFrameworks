using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.BusinessBO;
using Tracy.WebFrameworks.Entity.CommonBO;
using Tracy.WebFrameworks.Entity.ViewModel;

namespace Tracy.WebFrameworks.IService
{
    [ServiceContract(ConfigurationName = "WebFxsCommonService.IWebFxsCommonService")]
    public interface IWebFxsCommonService
    {
        /// <summary>
        /// 获取该用户所拥有的菜单
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<string> GetUserMenu(int employeeId);

        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<Employee> CheckLogin(CheckLoginRequest request);

        /// <summary>
        /// 首次登录初始化密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<bool> InitUserPwd(FirstLoginRequest request);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<bool> ChangePwd(ChangePwdRequest request);

        /// <summary>
        /// 我的信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<GetMyInfoResponse> GetMyInfo(int id);

    }
}
