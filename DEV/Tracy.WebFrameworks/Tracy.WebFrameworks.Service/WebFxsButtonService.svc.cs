using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.IService;
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.RepositoryFactory;
using Tracy.WebFrameworks.Entity.CommonBO;
using Tracy.WebFrameworks.Entity.BusinessBO;
using Tracy.Frameworks.Common.Extends;
using Tracy.WebFrameworks.Common.Helper;

namespace Tracy.WebFrameworks.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[WcfServiceCounter(SystemCode = "WebFrameworks", Source = "Offline.Service")]
    public class WebFxsButtonService : IWebFxsButtonService
    {
        private static readonly IButtonRepository repository = Factory.GetButtonRepository();

        /// <summary>
        /// 获取当前用户当前页面可访问的按钮
        /// </summary>
        /// <param name="menuCode"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public WebFxsResult<string> GetButtonByUserIdAndMenuCode(string menuCode, string pageName, int userId)
        {
            var result = new WebFxsResult<string>
            {
                ReturnCode = Entity.ReturnCodeType.Error,
                Content = string.Empty
            };
            var buttons = repository.GetButtonByUserIdAndMenuCode(menuCode, userId);
            if (buttons.HasValue())
            {
                //构造json
                var dt = buttons.ToDataTable();
                result.Content = ToolbarHelper.GetToolBar(dt, pageName);
                if (!result.Content.IsNullOrEmpty())
                {
                    result.ReturnCode = Entity.ReturnCodeType.Success;
                }
            }

            return result;
        }


    }
}
