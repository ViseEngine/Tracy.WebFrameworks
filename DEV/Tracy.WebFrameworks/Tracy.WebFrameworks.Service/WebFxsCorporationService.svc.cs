using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.CommonBO;
using Tracy.WebFrameworks.IService;
using Tracy.WebFrameworks.Data;
using Tracy.WebFrameworks.Common.Helper;

namespace Tracy.WebFrameworks.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[WcfServiceCounter(SystemCode = "WebFrameworks", Source = "Offline.Service")]
    public class WebFxsCorporationService : IWebFxsCorporationService
    {
        #region IRepository
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public WebFxsResult<IEnumerable<Corporation>> GetAll()
        {
            var result = new WebFxsResult<IEnumerable<Corporation>>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = new List<Corporation>()
            };
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    result.ReturnCode = ReturnCodeType.Success;
                    result.Content = db.Corporation;
                }
            });
            return result;
        }

        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebFxsResult<Corporation> GetById(int id)
        {
            var result = new WebFxsResult<Corporation>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = new Corporation()
            };
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    result.ReturnCode = ReturnCodeType.Success;
                    result.Content = db.Corporation.FirstOrDefault(p => p.CorporationID == id);
                }
            });
            return result;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public WebFxsResult<Corporation> Insert(Corporation item)
        {
            var result = new WebFxsResult<Corporation>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = new Corporation()
            };
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                result.Content = db.Corporation.Add(item);
                if (db.SaveChanges() > 0)
                {
                    result.ReturnCode = ReturnCodeType.Success;
                }
            }

            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public WebFxsResult<bool> Update(Corporation item)
        {
            var result = new WebFxsResult<bool>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = false
            };
            //CRUD Operation in Connected mode
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
                    result.ReturnCode = ReturnCodeType.Success;
                    result.Content = true;
                }
            }

            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebFxsResult<bool> Delete(int id)
        {
            var result = new WebFxsResult<bool>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = false
            };
            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var corporation = db.Corporation.FirstOrDefault(p => p.CorporationID == id);
                if (corporation != null)
                {
                    db.Corporation.Remove(corporation);
                }

                if (db.SaveChanges() > 0)
                {
                    result.ReturnCode = ReturnCodeType.Success;
                    result.Content = true;
                }
            }

            return result;
        }
        #endregion

    }
}
