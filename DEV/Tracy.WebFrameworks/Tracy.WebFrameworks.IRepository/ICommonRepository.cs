using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.BusinessBO;
using Tracy.WebFrameworks.Entity.ViewModel;

namespace Tracy.WebFrameworks.IRepository
{
    public interface ICommonRepository
    {
        /// <summary>
        /// 获取用户所拥有的菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<UserMenuResponse> GetUserMenu(int employeeId);

        /// <summary>
        /// 登录检查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Employee CheckLogin(CheckLoginRequest request);

        /// <summary>
        /// 首次登录初始化密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool InitUserPwd(FirstLoginRequest request);

    }
}
