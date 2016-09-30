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
        WebFxsResult<User> CheckLogin(CheckLoginRequest request);

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

        /// <summary>
        /// 左侧导航菜单Accordion
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<string> GetLeftMenuAccordion(int userId, int menuParentId);

        /// <summary>
        /// 左侧导航菜单Tree
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<string> GetLeftMenuTree(int userId, int menuParentId);

        /// <summary>
        /// 获取组织机构树数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<List<Corporation>> GetOrgTreeData();

    }
}
