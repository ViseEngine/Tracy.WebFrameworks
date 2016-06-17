using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Common.Helper;
using Tracy.WebFrameworks.Data;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.IRepository;

namespace Tracy.WebFrameworks.Repository
{
    public class EmployeeDepartmentRepository: IEmployeeDepartmentRepository
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeDepartment GetById(int id)
        {
            EmployeeDepartment result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    result = db.EmployeeDepartment.FirstOrDefault(p => p.ID == id);
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
        public IEnumerable<EmployeeDepartment> GetByCondition(Expression<Func<EmployeeDepartment, bool>> filter = null, Func<IQueryable<EmployeeDepartment>, IOrderedQueryable<EmployeeDepartment>> orderby = null)
        {
            IEnumerable<EmployeeDepartment> result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    var query = db.EmployeeDepartment.AsQueryable();
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
        public EmployeeDepartment Insert(EmployeeDepartment item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var result = db.EmployeeDepartment.Add(item);
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
        public bool Update(EmployeeDepartment item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var employeeDepartment = db.EmployeeDepartment.FirstOrDefault(p => p.ID == item.ID);
                if (employeeDepartment != null)
                {
                    employeeDepartment.EmployeeID = item.EmployeeID;
                    employeeDepartment.DepartmentID = item.DepartmentID;
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
                var employeeDepartment = db.EmployeeDepartment.FirstOrDefault(p => p.ID == id);
                if (employeeDepartment != null)
                {
                    db.EmployeeDepartment.Remove(employeeDepartment);
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
