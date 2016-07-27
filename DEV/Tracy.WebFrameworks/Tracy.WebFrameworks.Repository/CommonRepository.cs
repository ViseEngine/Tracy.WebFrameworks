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
using Tracy.Frameworks.Common.Const;

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

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool ChangePwd(ChangePwdRequest request)
        {
            using (var db = new WebFrameworksDB())
            {
                var employee = db.Employee.FirstOrDefault(p => p.EmployeeID == request.EmployeeId);
                if (employee != null)
                {
                    employee.UserPwd = request.NewPwd;
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

        /// <summary>
        /// 我的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GetMyInfoResponse GetMyInfo(int id)
        {
            var result = new GetMyInfoResponse();

            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    var query = from emp in db.Employee
                                join empRole in db.EmployeeRole on emp.EmployeeID equals empRole.EmployeeID into aa
                                from empRole in aa.DefaultIfEmpty()
                                join role in db.Role on empRole.RoleID equals role.RoleID into bb
                                from role in bb.DefaultIfEmpty()
                                join empDepartment in db.EmployeeDepartment on emp.EmployeeID equals empDepartment.EmployeeID into cc
                                from empDepartment in cc.DefaultIfEmpty()
                                join depart in db.Department on empDepartment.DepartmentID equals depart.DepartmentID into dd
                                from depart in dd.DefaultIfEmpty()
                                where emp.EmployeeID == id
                                select new
                                {
                                    UserId = emp.UserId,
                                    UserName = emp.EmployeeName,
                                    CreatedTime = emp.CreatedTime,
                                    RolesName = role.RoleName,
                                    DepartmentsName = depart.DepartmentName
                                };
                    if (query != null && query.Count() > 0)
                    {
                        var list = query.ToList();
                        result.UserId = list[0].UserId;
                        result.UserName = list[0].UserName;
                        result.CreatedTime = list[0].CreatedTime.ToString(DateFormat.DATETIME);
                        result.RolesName = string.Join(",", list.Select(p => p.RolesName));
                        result.DepartmentsName = string.Join(",", list.Select(p => p.DepartmentsName));
                    }
                }
            });

            return result;
        }

    }
}
