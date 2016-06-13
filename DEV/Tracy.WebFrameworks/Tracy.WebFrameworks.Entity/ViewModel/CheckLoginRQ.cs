using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    /// <summary>
    /// 检查登录请求实体
    /// </summary>
    [Serializable]
    public class CheckLoginRQ
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

    }
}
