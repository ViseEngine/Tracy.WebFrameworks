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
    /// 职员-部门仓储接口
    /// </summary>
    public interface IEmployeeDepartmentRepository
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserDepartment GetById(int id);

        /// <summary>
        /// 依条件表达式查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        IEnumerable<UserDepartment> GetByCondition(Expression<Func<UserDepartment, bool>> filter = null, Func<IQueryable<UserDepartment>, IOrderedQueryable<UserDepartment>> orderby = null);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        UserDepartment Insert(UserDepartment item);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(UserDepartment item);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
