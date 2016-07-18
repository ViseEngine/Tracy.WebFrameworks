using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Common.Helper;
using Tracy.WebFrameworks.Data;
using Tracy.WebFrameworks.Entity.BusinessBO;
using Tracy.WebFrameworks.IRepository;

namespace Tracy.WebFrameworks.Repository
{
    public class CommonRepository : ICommonRepository
    {
        /// <summary>
        /// 获取用户所拥有的菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UserMenuResponse> GetUserMenu(int employeeId)
        {
            var result = new List<UserMenuResponse>();
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    //EF多表连接查询
                    var query = from emp in db.Employee
                                join empRole in db.EmployeeRole on emp.EmployeeID equals empRole.EmployeeID
                                join roleMenuButton in db.RoleMenuButton on empRole.RoleID equals roleMenuButton.RoleID
                                join menu in db.Menu on roleMenuButton.MenuID equals menu.MenuID
                                where emp.EmployeeID == employeeId
                                orderby menu.ParentMenuID, menu.Sort
                                select new UserMenuResponse
                                {
                                    MenuName = menu.MenuName,
                                    MenuId = menu.MenuID,
                                    MenuIcon = menu.Icon,
                                    UserId = emp.EmployeeID,
                                    UserName = emp.UserId,
                                    MenuParentId = menu.ParentMenuID,
                                    MenuSort = menu.Sort.HasValue ? menu.Sort.Value : 0,
                                    LinkAddress = menu.MenuUrl
                                };
                    result = query.DistinctBy(p => new { p.MenuName }).ToList();
                }
            });

            return result;
        }

    }
}
