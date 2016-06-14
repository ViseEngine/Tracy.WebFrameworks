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
    /// <summary>
    /// 泛型仓储接口实现
    /// </summary>
    public class GenericRepository<T>: IGenericRepository<T> where T: class
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            T result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    result = db.Set<T>().Find(id);
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
        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            IEnumerable<T> result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    var query = db.Set<T>().AsQueryable();
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
        public T Insert(T item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var result = db.Set<T>().Add(item);
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
        public bool Update(T item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                db.Set<T>().Attach(item);
                db.Entry<T>(item).State = System.Data.Entity.EntityState.Modified;
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
                var model = db.Set<T>().Find(id);
                if (model!= null)
                {
                    db.Set<T>().Remove(model);
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
