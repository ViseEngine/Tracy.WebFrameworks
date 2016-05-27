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

namespace Tracy.WebFrameworks.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[WcfServiceCounter(SystemCode = "WebFrameworks", Source = "Offline.Service")]
    public class WebFxsCorporationService: IWebFxsCorporationService
    {
        /// <summary>
        /// 批量插入公司信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public WebFxsResult<bool> BatchInsert(List<Corporation> list)
        {
            var result = new WebFxsResult<bool> 
            {
                ReturnCode= ReturnCodeType.Error
            };

            using (var db = new WebFrameworksDB())
            {
                db.Corporation.AddRange(list);
                if (db.SaveChanges()>0)
                {
                    result.Content = true;
                    result.ReturnCode = ReturnCodeType.Success;
                }
            }

            return result;
        }

    }
}
