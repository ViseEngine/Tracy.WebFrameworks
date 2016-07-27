using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.Entity;
using System.Linq.Expressions;
using Tracy.WebFrameworks.Common.Helper;
using Tracy.WebFrameworks.Data;

namespace Tracy.WebFrameworks.Repository
{
    /// <summary>
    /// 角色仓储接口实现
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetById(int id)
        {
            Role result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    result = db.Role.FirstOrDefault(p => p.Id == id);
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
        public IEnumerable<Role> GetByCondition(Expression<Func<Role, bool>> filter = null, Func<IQueryable<Role>, IOrderedQueryable<Role>> orderby = null)
        {
            IEnumerable<Role> result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    var query = db.Role.AsQueryable();
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
        public Role Insert(Role item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var result = db.Role.Add(item);
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
        public bool Update(Role item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var role = db.Role.FirstOrDefault(p => p.Id == item.Id);
                if (role != null)
                {
                    role.Name = item.Name;
                    role.Description = item.Description;
                    role.LastUpdatedBy = item.LastUpdatedBy;
                    role.LastUpdatedTime = item.LastUpdatedTime;
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
                var role = db.Role.FirstOrDefault(p => p.Id == id);
                if (role != null)
                {
                    db.Role.Remove(role);
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
