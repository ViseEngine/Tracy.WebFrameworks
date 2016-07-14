using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracy.WebFrameworks.Entity.CommonBO
{
    /// <summary>
    /// 前端给客户端的结果实体
    /// </summary>
    [Serializable]
    public class AjaxResult
    {
        public string msg { get; set; }

        public bool success { get; set; }

        public AjaxResult(string msg, bool success)
        {
            this.msg = msg;
            this.success = success;
        }
    }
}
