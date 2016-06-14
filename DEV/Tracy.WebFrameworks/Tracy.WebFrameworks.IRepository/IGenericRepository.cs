using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tracy.WebFrameworks.IRepository
{
    /// <summary>
    /// 泛型仓储接口
    /// </summary>
    public interface IGenericRepository<T> where T: class
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// 依条件表达式查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        T Insert(T item);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(T item);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
