using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity.CommonBO;
using Tracy.WebFrameworks.IService;
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.RepositoryFactory;
using Tracy.Frameworks.Common.Extends;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace Tracy.WebFrameworks.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[WcfServiceCounter(SystemCode = "WebFrameworks", Source = "Offline.Service")]
    public class WebFxsCommonService : IWebFxsCommonService
    {
        private static readonly ICommonRepository repository = Factory.GetCommonRepository();

        /// <summary>
        /// 获取该用户所拥有的菜单
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public WebFxsResult<string> GetUserMenu(int employeeId)
        {
            var result = new WebFxsResult<string>
            {
                ReturnCode = Entity.ReturnCodeType.Error,
                Content = string.Empty
            };

            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            var userMenus = repository.GetUserMenu(employeeId);
            if (userMenus.HasValue())
            {
                //TODO:组装json字符串，有更好的方案要优化
                var rootUserMenus= userMenus.Where(p => p.MenuParentId == 0).ToList();
                if (rootUserMenus.HasValue())
                {
                    rootUserMenus.ForEach(item => 
                    {
                        sb.Append("{\"id\":\"" + item.MenuId + "\",\"text\":\"" + item.MenuName + "\",\"iconCls\":\"" + item.MenuIcon + "\",\"children\":[");
                        var childUserMenus= userMenus.Where(p => p.MenuParentId == item.MenuId).ToList();
                        if (childUserMenus.HasValue())
                        {
                            childUserMenus.ForEach(subItem => 
                            {
                                sb.Append("{\"id\":\"" + subItem.MenuId + "\",\"text\":\"" + subItem.MenuName + "\",\"iconCls\":\"" + subItem.MenuIcon + "\",\"attributes\":{\"url\":\"" + subItem.LinkAddress + "\"}},");
                            });
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append("]},");
                        }
                        else
                        {
                            sb.Append("]},");
                        }
                    });
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("]");
                }
                else
                {
                    sb.Append("]");
                }
            }
            else
            {
                sb.Append("]");
            }
            result.ReturnCode = Entity.ReturnCodeType.Success;
            result.Content = sb.ToString();

            return result;
        }

    }
}
