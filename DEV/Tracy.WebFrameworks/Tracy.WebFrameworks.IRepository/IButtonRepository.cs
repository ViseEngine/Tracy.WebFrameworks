using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.BusinessBO;

namespace Tracy.WebFrameworks.IRepository
{
    /// <summary>
    /// 按钮仓储接口
    /// </summary>
    public interface IButtonRepository
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Button GetById(int id);

        /// <summary>
        /// 依条件表达式查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        IEnumerable<Button> GetByCondition(Expression<Func<Button, bool>> filter = null, Func<IQueryable<Button>, IOrderedQueryable<Button>> orderby = null);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Button Insert(Button item);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(Button item);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 获取当前用户当前页面可访问的按钮
        /// </summary>
        /// <param name="menuCode"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<GetButtonByUAMResponse> GetButtonByUserIdAndMenuCode(string menuCode, int userId);



    }
}
