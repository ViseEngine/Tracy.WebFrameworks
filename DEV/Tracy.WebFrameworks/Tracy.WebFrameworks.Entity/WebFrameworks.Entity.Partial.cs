using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tracy.WebFrameworks.Entity
{
    /// <summary>
    /// 扩展属性，数据中不存在的
    /// </summary>
    public partial class Corporation
    {

    }

    public partial class Department
    {
        /// <summary>
        /// 所有公司名称
        /// </summary>
        [DataMember]
        public string CorporationName { get; set; }

    }
}
