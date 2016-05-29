using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracy.WebFrameworks.Common.Helper
{
    /// <summary>
    /// 配置相关的helper
    /// </summary>
    public class WebFxsConfigHelper
    {
        /// <summary>
        /// 缓存过期时间(默认5分钟)
        /// </summary>
        public static int CacheTimeOutMinutes
        {
            get
            {
                var min = ConfigurationManager.AppSettings["Log.CacheTimeOutMinutes"];
                if (min == null)
                {
                    return 5;
                }
                else
                {
                    return int.Parse(min);
                }
            }
        }

    }
}
