using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity;

namespace Tracy.WebFrameworks.IRepository
{
    /// <summary>
    /// 职员-角色仓储接口
    /// </summary>
    public interface IEmployeeRoleRepository
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserRole GetById(int id);

        /// <summary>
        /// 依条件表达式查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        IEnumerable<UserRole> GetByCondition(Expression<Func<UserRole, bool>> filter = null, Func<IQueryable<UserRole>, IOrderedQueryable<UserRole>> orderby = null);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        UserRole Insert(UserRole item);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(UserRole item);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
