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
                    var query = from emp in db.User
                                join empRole in db.UserRole on emp.Id equals empRole.UserId
                                join roleMenuButton in db.RoleMenuButton on empRole.RoleId equals roleMenuButton.RoleId
                                join menu in db.Menu on roleMenuButton.MenuId equals menu.Id
                                where emp.Id == employeeId
                                orderby menu.ParentId, menu.Sort
                                select new UserMenuResponse
                                {
                                    MenuName = menu.Name,
                                    MenuId = menu.Id,
                                    MenuIcon = menu.Icon,
                                    UserId = emp.Id,
                                    UserName = emp.UserId,
                                    MenuParentId = menu.ParentId,
                                    MenuSort = menu.Sort.HasValue ? menu.Sort.Value : 0,
                                    LinkAddress = menu.Url
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
        public User CheckLogin(CheckLoginRequest request)
        {
            User user = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    user = db.User.FirstOrDefault(p => p.UserId.Equals(request.loginName) && p.UserPwd.Equals(request.loginPwd));
                }
            });

            return user;
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
                var user = db.User.FirstOrDefault(p => p.Id == request.Id);
                if (user != null)
                {
                    user.UserPwd = request.NewPwd.To32bitMD5();
                    user.IsChangePwd = true;
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
                var user = db.User.FirstOrDefault(p => p.Id == request.UserId);
                if (user != null)
                {
                    user.UserPwd = request.NewPwd;
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
                    var query = from emp in db.User
                                join empRole in db.UserRole on emp.Id equals empRole.UserId into aa
                                from empRole in aa.DefaultIfEmpty()
                                join role in db.Role on empRole.RoleId equals role.Id into bb
                                from role in bb.DefaultIfEmpty()
                                join empDepartment in db.UserDepartment on emp.Id equals empDepartment.UserId into cc
                                from empDepartment in cc.DefaultIfEmpty()
                                join depart in db.Department on empDepartment.DepartmentId equals depart.Id into dd
                                from depart in dd.DefaultIfEmpty()
                                where emp.Id == id
                                select new
                                {
                                    UserId = emp.UserId,
                                    UserName = emp.UserName,
                                    CreatedTime = emp.CreatedTime,
                                    RolesName = role.Name,
                                    DepartmentsName = depart.Name
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

        /// <summary>
        /// 当前登录用户可以访问的所有菜单
        /// </summary>
        public List<GetLeftMenuResponse> CurrentUserMenu { get; set; }

        /// <summary>
        /// 左侧导航菜单
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<GetLeftMenuResponse> GetLeftMenu(int userId, int menuParentId)
        {
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    CurrentUserMenu = (from user in db.User
                                       join userRole in db.UserRole on user.Id equals userRole.UserId into aa
                                       from userRole in aa.DefaultIfEmpty()
                                       join roleMenuButton in db.RoleMenuButton on userRole.RoleId equals roleMenuButton.RoleId into bb
                                       from roleMenuButton in bb.DefaultIfEmpty()
                                       join menu in db.Menu on roleMenuButton.MenuId equals menu.Id into cc
                                       from menu in cc.DefaultIfEmpty()
                                       where user.Id == userId
                                       orderby menu.ParentId, menu.Sort
                                       select new GetLeftMenuResponse
                                       {
                                           MenuId = menu.Id,
                                           MenuName = menu.Name,
                                           MenuIcon = menu.Icon,
                                           MenuParentId = menu.ParentId,
                                           MenuSort = menu.Sort ?? 0,
                                           MenuUrl = menu.Url,
                                           UserId = user.Id,
                                           LoginId = user.UserId
                                       }).ToList();
                }
            });

            return GetAllChildMenu(menuParentId).DistinctBy(p=> p.MenuName).ToList();
        }

        public IEnumerable<GetLeftMenuResponse> GetAllChildMenu(int menuParentId)
        {
            var query = from item in CurrentUserMenu
                        where item.MenuParentId == menuParentId
                        select item;
            if (query != null && query.Count() > 0)
            {
                if (menuParentId == 0)
                {
                    return query;
                }
            }

            return query.ToList().Concat(query.ToList().SelectMany(p => GetAllChildMenu(p.MenuId)));
        }

    }
}
