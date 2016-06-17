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
    /// 角色-菜单-按钮仓储接口实现
    /// </summary>
    public class RoleMenuButtonRepository: IRoleMenuButtonRepository
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleMenuButton GetById(int id)
        {
            RoleMenuButton result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    result = db.RoleMenuButton.FirstOrDefault(p => p.ID == id);
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
        public IEnumerable<RoleMenuButton> GetByCondition(Expression<Func<RoleMenuButton, bool>> filter = null, Func<IQueryable<RoleMenuButton>, IOrderedQueryable<RoleMenuButton>> orderby = null)
        {
            IEnumerable<RoleMenuButton> result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    var query = db.RoleMenuButton.AsQueryable();
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
        public RoleMenuButton Insert(RoleMenuButton item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var result = db.RoleMenuButton.Add(item);
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
        public bool Update(RoleMenuButton item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var roleMenuButton = db.RoleMenuButton.FirstOrDefault(p => p.ID == item.ID);
                if (roleMenuButton != null)
                {
                    roleMenuButton.RoleID = item.RoleID;
                    roleMenuButton.MenuID = item.MenuID;
                    roleMenuButton.ButtonID = item.ButtonID;
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
                var roleMenuButton = db.RoleMenuButton.FirstOrDefault(p => p.ID == id);
                if (roleMenuButton != null)
                {
                    db.RoleMenuButton.Remove(roleMenuButton);
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
