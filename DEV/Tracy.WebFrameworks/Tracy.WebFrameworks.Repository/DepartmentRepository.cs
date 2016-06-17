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

namespace Tracy.WebFrameworks.Repository
{
    /// <summary>
    /// 部门仓储接口实现
    /// </summary>
    public class DepartmentRepository: IDepartmentRepository
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
                    result = db.Department.FirstOrDefault(p => p.DepartmentID == id);
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
                var department = db.Department.FirstOrDefault(p => p.DepartmentID == item.DepartmentID);
                if (department != null)
                {
                    department.DepartmentCode = item.DepartmentCode;
                    department.DepartmentName = item.DepartmentName;
                    department.ParentDeptID = item.ParentDeptID;
                    department.CorporationID = item.CorporationID;
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
                var department = db.Department.FirstOrDefault(p => p.DepartmentID == id);
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
    }
}
