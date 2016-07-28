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
        /// 左侧导航菜单
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public WebFxsResult<List<LeftNavMenu>> GetLeftMenu(int userId, int menuParentId)
        {
            //menuParentId=0，创建accordion，否则创建tree
            var result = new WebFxsResult<List<LeftNavMenu>>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = new List<LeftNavMenu>()
            };

            var leftMenus = repository.GetLeftMenu(userId, menuParentId);
            if (leftMenus.HasValue())
            {
                if (menuParentId == 0)
                {
                    leftMenus.ForEach(item => 
                    {
                        result.Content.Add(new LeftNavMenu 
                        {
                            id= item.MenuId,
                            text= item.MenuName,
                            iconCls= item.MenuIcon
                        });
                    });
                }
                else
                {
                    var roots = leftMenus.Where(p => p.MenuParentId == menuParentId).ToList();
                    if (roots.HasValue())
                    {
                        foreach (var item in roots)
                        {
                            var leftNavMenu = new LeftNavMenu 
                            {
                                id= item.MenuId,
                                text= item.MenuName,
                                iconCls= item.MenuIcon
                            };
                            if (IsHasChildNode(item.MenuId, leftMenus))
                            {
                                
                            }

                        }

                    }


                }
                result.ReturnCode = ReturnCodeType.Success;
            }            

            return result;
        }

        /// <summary>
        /// 判断该菜单是否含有子菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private bool IsHasChildNode(int menuId, List<GetLeftMenuResponse> list)
        {
            return list.Where(p => p.MenuParentId == menuId).Count() > 0;
        }

    }
}
