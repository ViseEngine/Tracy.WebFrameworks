using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Tracy.WebFrameworks.Entity.BusinessBO
{
    /// <summary>
    /// 左侧导航菜单实体
    /// </summary>
    [Serializable]
    [DataContract(IsReference= true)]
    public class LeftNavMenu
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string text { get; set; }

        [DataMember]
        public string iconCls { get; set; }

        [DataMember]
        public AttributesUrl attributes { get; set; }

        [DataMember]
        public string state { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        [DataMember]
        public List<LeftNavMenu> children { get; set; }

    }

    [Serializable]
    [DataContract(IsReference = true)]
    public class AttributesUrl
    {
        [DataMember]
        public string url { get; set; }
    }
}