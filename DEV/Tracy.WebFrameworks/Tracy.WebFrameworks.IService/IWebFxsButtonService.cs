using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.BusinessBO;
using Tracy.WebFrameworks.Entity.CommonBO;

namespace Tracy.WebFrameworks.IService
{
    /// <summary>
    /// 按钮相关服务接口
    /// </summary>
    [ServiceContract(ConfigurationName = "WebFxsButtonService.IWebFxsButtonService")]
    public interface IWebFxsButtonService
    {
        /// <summary>
        /// 获取当前用户当前页面可访问的按钮
        /// </summary>
        /// <param name="menuCode"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        WebFxsResult<string> GetButtonByUserIdAndMenuCode(string menuCode, string pageName, int userId);


    }
}
