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
using Tracy.WebFrameworks.Entity.BusinessBO;
using Tracy.WebFrameworks.Common.Helper;
using Tracy.Frameworks.Common.Extends;

namespace Tracy.WebFrameworks.Repository
{
    /// <summary>
    /// 按钮仓储接口实现
    /// </summary>
    public class ButtonRepository : IButtonRepository
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Button GetById(int id)
        {
            Button result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    result = db.Button.FirstOrDefault(p => p.Id == id);
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
        public IEnumerable<Button> GetByCondition(Expression<Func<Button, bool>> filter = null, Func<IQueryable<Button>, IOrderedQueryable<Button>> orderby = null)
        {
            IEnumerable<Button> result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    var query = db.Button.AsQueryable();
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
        public Button Insert(Button item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var result = db.Button.Add(item);
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
        public bool Update(Button item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var button = db.Button.FirstOrDefault(p => p.Id == item.Id);
                if (button != null)
                {
                    button.Name = item.Name;
                    button.Code = item.Code;
                    button.Icon = item.Icon;
                    button.Sort = item.Sort;
                    button.LastUpdatedBy = item.LastUpdatedBy;
                    button.LastUpdatedTime = item.LastUpdatedTime;
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
                var button = db.Button.FirstOrDefault(p => p.Id == id);
                if (button != null)
                {
                    db.Button.Remove(button);
                }

                if (db.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取当前用户当前页面可访问的按钮
        /// </summary>
        /// <param name="menuCode"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<GetButtonByUAMResponse> GetButtonByUserIdAndMenuCode(string menuCode, int userId)
        {
            List<GetButtonByUAMResponse> result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    var query = from u in db.User
                                join userRole in db.UserRole on u.Id equals userRole.UserId into aa
                                from userRole in aa.DefaultIfEmpty()
                                join roleMenuButton in db.RoleMenuButton on userRole.RoleId equals roleMenuButton.RoleId into bb
                                from roleMenuButton in bb.DefaultIfEmpty()
                                join menu in db.Menu on roleMenuButton.MenuId equals menu.Id into cc
                                from menu in cc.DefaultIfEmpty()
                                join button in db.Button on roleMenuButton.ButtonId equals button.Id into dd
                                from button in dd.DefaultIfEmpty()
                                where menu.Code.Equals(menuCode) && u.Id == userId
                                select new GetButtonByUAMResponse
                                {
                                    ButtonId = button.Id,
                                    Name = button.Name,
                                    Code = button.Code,
                                    Icon = button.Icon,
                                    ButtonSort = button.Sort ?? 1
                                };
                    if (query!=null && query.Count()>0)
                    {
                        result= query.DistinctBy(p => p.ButtonId).OrderBy(p => p.ButtonSort).ToList();
                    }
                }
            });

            return result;
        }
    }
}
