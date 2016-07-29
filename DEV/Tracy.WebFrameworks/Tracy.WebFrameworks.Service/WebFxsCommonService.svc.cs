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
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.WebFrameworks.Entity.BusinessBO;

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
                var rootUserMenus = userMenus.Where(p => p.MenuParentId == 0).ToList();
                if (rootUserMenus.HasValue())
                {
                    rootUserMenus.ForEach(item =>
                    {
                        sb.Append("{\"id\":\"" + item.MenuId + "\",\"text\":\"" + item.MenuName + "\",\"iconCls\":\"" + item.MenuIcon + "\",\"children\":[");
                        var childUserMenus = userMenus.Where(p => p.MenuParentId == item.MenuId).ToList();
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

        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public WebFxsResult<User> CheckLogin(CheckLoginRequest request)
        {
            var result = new WebFxsResult<User>
            {
                ReturnCode = ReturnCodeType.Error
            };

            var employee = repository.CheckLogin(request);
            result.ReturnCode = ReturnCodeType.Success;
            result.Content = employee;

            return result;
        }

        /// <summary>
        /// 首次登录初始化密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public WebFxsResult<bool> InitUserPwd(FirstLoginRequest request)
        {
            var result = new WebFxsResult<bool>
            {
                ReturnCode = ReturnCodeType.Error
            };

            if (repository.InitUserPwd(request))
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = true;
            }

            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public WebFxsResult<bool> ChangePwd(ChangePwdRequest request)
        {
            var result = new WebFxsResult<bool>
            {
                ReturnCode = ReturnCodeType.Error
            };

            if (repository.ChangePwd(request))
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = true;
            }

            return result;
        }

        /// <summary>
        /// 我的信息
        /// </summary>
        /// <returns></returns>
        public WebFxsResult<GetMyInfoResponse> GetMyInfo(int id)
        {
            var result = new WebFxsResult<GetMyInfoResponse>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = new GetMyInfoResponse()
            };

            var myInfo = repository.GetMyInfo(id);
            if (myInfo != null)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = myInfo;
            }
            else
            {
                result.Message = "获取我的信息失败!";
            }

            return result;
        }

        /// <summary>
        /// 左侧导航菜单Accordion
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public WebFxsResult<string> GetLeftMenuAccordion(int userId, int menuParentId)
        {
            var result = new WebFxsResult<string>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = string.Empty
            };

            var menus = repository.GetLeftMenu(userId, menuParentId);
            var navMenus = new List<LeftNavMenu>();
            if (menus.HasValue())
            {
                menus.ForEach(item =>
                {
                    navMenus.Add(new LeftNavMenu
                    {
                        id = item.MenuId,
                        text = item.MenuName,
                        iconCls = item.MenuIcon
                    });
                });
            }

            result.ReturnCode = ReturnCodeType.Success;
            result.Content = navMenus.ToJson();

            return result;
        }

        /// <summary>
        /// 左侧导航菜单Tree
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public WebFxsResult<string> GetLeftMenuTree(int userId, int menuParentId)
        {
            var result = new WebFxsResult<string>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = string.Empty
            };

            var data = repository.GetLeftMenu(userId, menuParentId);
            var outPut = GetLeftMenuTreeString(data, menuParentId);
            result.ReturnCode = ReturnCodeType.Success;
            result.Content = outPut;

            return result;
        }

        private string GetLeftMenuTreeString(List<GetLeftMenuResponse> data, int menuParentId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            var childMenus = data.Where(p => p.MenuParentId == menuParentId);
            if (childMenus != null && childMenus.Count() > 0)
            {
                var tempList= childMenus.ToList();
                for (int i = 0; i < tempList.Count; i++)
                {
                    sb.Append("{\"id\":\"" + tempList[i].MenuId.ToString() + "\",\"text\":\"" + tempList[i].MenuName + "\",\"iconCls\":\"" + tempList[i].MenuIcon + "\",\"state\":\"closed\",\"children\":[");
                    var subList = data.Where(p => p.MenuParentId == tempList[i].MenuId);
                    if (subList!=null && subList.Count()>0)
                    {
                        var subTempList = subList.ToList();
                        for (int j = 0; j < subTempList.Count; j++)
                        {
                            sb.Append("{\"id\":\"" + subTempList[j].MenuId.ToString() + "\",\"text\":\"" + subTempList[j].MenuName + "\",\"iconCls\":\"" + subTempList[j].MenuIcon + "\",\"state\":\"open\",\"attributes\":{\"url\":\"" + subTempList[j].MenuUrl + "\"}},");
                        }
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append("]},");
                    }
                    else
                    {
                        sb.Append("]},");
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]");
            }
            else
            {
                sb.Append("]");
            }

            return sb.ToString();
        }

    }
}
