using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Data;

namespace Tracy.WebFrameworks.Repository
{
    /// <summary>
    /// 公司仓储实现
    /// </summary>
    public class CorporationRepository
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Corporation> GetAll()
        {
            using (var db = new WebFrameworksDB())
            {
                return db.Corporation;
            }
        }

        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Corporation GetById(int id)
        {
            using (var db = new WebFrameworksDB())
            {
                return db.Corporation.FirstOrDefault(p => p.CorporationID == id);
            }
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Corporation Insert(Corporation item)
        {
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
            using (var db = new WebFrameworksDB())
            {
                var corporation = db.Corporation.FirstOrDefault(p => p.CorporationID == item.CorporationID);
                if (corporation != null)
                {
                    corporation.ParentCorpID = item.ParentCorpID;
                    corporation.CorporationCode = item.CorporationCode;
                    corporation.CorporationName = item.CorporationName;
                    corporation.Address = item.Address;
                    corporation.CreatedBy = item.CreatedBy;
                    corporation.CreatedTime = item.CreatedTime;
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
            using (var db = new WebFrameworksDB())
            {
                //var flag= db.Configuration.AutoDetectChangesEnabled;
                var corporation = db.Corporation.FirstOrDefault(p => p.CorporationID == id);
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
    }
}
