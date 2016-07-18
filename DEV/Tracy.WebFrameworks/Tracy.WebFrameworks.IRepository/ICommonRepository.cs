using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity.BusinessBO;

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

    }
}
