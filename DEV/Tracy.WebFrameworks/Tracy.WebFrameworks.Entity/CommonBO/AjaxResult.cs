using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracy.WebFrameworks.Entity.CommonBO
{
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
