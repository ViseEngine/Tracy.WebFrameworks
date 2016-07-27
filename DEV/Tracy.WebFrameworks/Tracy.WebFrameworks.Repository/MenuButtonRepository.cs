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
    public class MenuButtonRepository: IMenuButtonRepository
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MenuButton GetById(int id)
        {
            MenuButton result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    result = db.MenuButton.FirstOrDefault(p => p.Id == id);
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
        public IEnumerable<MenuButton> GetByCondition(Expression<Func<MenuButton, bool>> filter = null, Func<IQueryable<MenuButton>, IOrderedQueryable<MenuButton>> orderby = null)
        {
            IEnumerable<MenuButton> result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    var query = db.MenuButton.AsQueryable();
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
        public MenuButton Insert(MenuButton item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var result = db.MenuButton.Add(item);
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
        public bool Update(MenuButton item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var menuButton = db.MenuButton.FirstOrDefault(p => p.Id == item.Id);
                if (menuButton != null)
                {
                    menuButton.MenuId = item.MenuId;
                    menuButton.ButtonId = item.ButtonId;
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
                var menuButton = db.MenuButton.FirstOrDefault(p => p.Id == id);
                if (menuButton != null)
                {
                    db.MenuButton.Remove(menuButton);
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
