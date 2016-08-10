using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Data;
using Tracy.WebFrameworks.Common.Helper;
using Tracy.Frameworks.Common.Result;
using Tracy.WebFrameworks.Entity.ViewModel;

namespace Tracy.WebFrameworks.Repository
{
    /// <summary>
    /// 公司仓储实现
    /// </summary>
    public class CorporationRepository : ICorporationRepository
    {
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Corporation GetById(int id)
        {
            Corporation result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    result = db.Corporation.FirstOrDefault(p => p.Id == id);
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
        public IEnumerable<Corporation> GetByCondition(Expression<Func<Corporation, bool>> filter = null, Func<IQueryable<Corporation>, IOrderedQueryable<Corporation>> orderby = null)
        {
            IEnumerable<Corporation> result = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    var query = db.Corporation.AsQueryable();
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
        public Corporation Insert(Corporation item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var result = db.Corporation.Add(item);
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
        public bool Update(Corporation item)
        {
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var corporation = db.Corporation.FirstOrDefault(p => p.Id == item.Id);
                if (corporation != null)
                {
                    corporation.ParentId = item.ParentId;
                    corporation.Code = item.Code;
                    corporation.Name = item.Name;
                    corporation.Sort = item.Sort;
                    corporation.Enabled = item.Enabled;
                    corporation.LastUpdatedBy = item.LastUpdatedBy;
                    corporation.LastUpdatedTime = item.LastUpdatedTime;
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
                var corporation = db.Corporation.FirstOrDefault(p => p.Id == id);
                if (corporation != null)
                {
                    db.Corporation.Remove(corporation);
                }

                if (db.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取选中公司下所有部门
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PagingResult<Department> GetCorpDepartmentByPaging(GetCorpDepartmentRQ request)
        {
            var result = new PagingResult<Department>();

            //分页查询
            DBHelper.NoLockInvokeDB(() => 
            {
                using (var db = new WebFrameworksDB())
                { 
                    

                }

            });

            return result;
        }
    }
}
