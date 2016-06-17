using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    /// <summary>
    /// 检查登录请求实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class CheckLoginRQ
    {
        [DataMember]
        public string LoginName { get; set; }

        [DataMember]
        public string Password { get; set; }

    }
}
