﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.Frameworks.Common.Result;

namespace Tracy.WebFrameworks.IRepository
{
    /// <summary>
    /// 公司仓储接口
    /// </summary>
    public interface ICorporationRepository
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Corporation GetById(int id);

        /// <summary>
        /// 依条件表达式查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        IEnumerable<Corporation> GetByCondition(Expression<Func<Corporation, bool>> filter = null, Func<IQueryable<Corporation>, IOrderedQueryable<Corporation>> orderby= null);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Corporation Insert(Corporation item);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(Corporation item);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 获取选中公司下所有部门
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PagingResult<Department> GetCorpDepartmentByPaging(GetCorpDepartmentRQ request);
        
        /// <summary>
        /// 删除公司
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool DeleteCorporation(DeleteCorporationRQ request);

    }
}
