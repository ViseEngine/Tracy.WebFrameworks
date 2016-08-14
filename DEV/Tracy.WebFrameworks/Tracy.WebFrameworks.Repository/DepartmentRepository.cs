using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Common.Helper;
using Tracy.WebFrameworks.Data;
using System.Linq.Expressions;
using Tracy.Frameworks.Common.Result;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.Frameworks.Common.Extends;

namespace Tracy.WebFrameworks.Repository
{
    /// <summary>
    /// 部门仓储接口实现
    /// </summary>
    public class DepartmentRepository : IDepartmentRepository
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetById(int id)
        {
            Department result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    result = db.Department.FirstOrDefault(p => p.Id == id);
                }
            });
            return result;
        }

        /// <summary>
        /// 依条件表达式查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public IEnumerable<Department> GetByCondition(Expression<Func<Department, bool>> filter = null, Func<IQueryable<Department>, IOrderedQueryable<Department>> orderby = null)
        {
            IEnumerable<Department> result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    var query = db.Department.AsQueryable();
                    if (filter != null)
                    {
                        query = query.Where(filter);
                    }
                    if (orderby != null)
                    {
                        result = orderby(query).ToList();
                    }
                    else
                    {
                        result = query.ToList();
                    }
                }
            });

            return result;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Department Insert(Department item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var result = db.Department.Add(item);
                if (db.SaveChanges() > 0)
                {
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(Department item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var department = db.Department.FirstOrDefault(p => p.Id == item.Id);
                if (department != null)
                {
                    department.Code = item.Code;
                    department.Name = item.Name;
                    department.ParentId = item.ParentId;
                    department.CorporationId = item.CorporationId;
                    department.Sort = item.Sort;
                    department.Enabled = item.Enabled;
                    department.LastUpdatedBy = item.LastUpdatedBy;
                    department.LastUpdatedTime = item.LastUpdatedTime;
                }
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var department = db.Department.FirstOrDefault(p => p.Id == id);
                if (department != null)
                {
                    db.Department.Remove(department);
                }

                if (db.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取指定部门下的所有用户(分页)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PagingResult<User> GetUserByDepartment(GetUserByDepartmentRQ request)
        {
            var result = new PagingResult<User>();
            var departmentIds = request.DeptIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.ToInt()).ToList();

            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    var query = db.User.GroupJoin(db.UserDepartment, user => user.Id, userDepart => userDepart.UserId, (user, userDepart) => new { user, userDepart = userDepart.FirstOrDefault() })
                                .GroupJoin(db.Department, ud => ud.userDepart.DepartmentId, depart => depart.Id, (ud, depart) => new { ud, depart = depart.FirstOrDefault() })
                                .Where(p => departmentIds.Contains(p.depart.Id))
                                .Select(p => p.ud.user);
                    result = query.OrderByDescending(p => p.CreatedTime)
                        .Paging(request.PageIndex, request.PageSize);
                }
            });

            return result;
        }
    }
}
