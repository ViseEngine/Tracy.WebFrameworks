using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity;

namespace Tracy.WebFrameworks.IRepository
{
    /// <summary>
    /// 公司仓储接口
    /// </summary>
    public interface ICorporationRepository
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        IEnumerable<Corporation> GetAll();

        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Corporation GetById(int id);

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
    }
}
