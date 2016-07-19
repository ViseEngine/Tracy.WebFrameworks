using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Common.Helper;
using Tracy.WebFrameworks.Data;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.BusinessBO;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.WebFrameworks.IRepository;
using Tracy.Frameworks.Common.Extends;

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

        /// <summary>
        /// 登录检查
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Employee CheckLogin(CheckLoginRequest request)
        {
            Employee employee = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    employee = db.Employee.FirstOrDefault(p => p.UserId.Equals(request.loginName) && p.UserPwd.Equals(request.loginPwd));
                }
            });

            return employee;
        }

        /// <summary>
        /// 首次登录初始化密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool InitUserPwd(FirstLoginRequest request)
        {
            using (var db = new WebFrameworksDB())
            {
                var employee = db.Employee.FirstOrDefault(p => p.EmployeeID == request.EmployeeId);
                if (employee != null)
                {
                    employee.UserPwd = request.NewPwd.To32bitMD5();
                    employee.IsChangePwd = true;
                }
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
