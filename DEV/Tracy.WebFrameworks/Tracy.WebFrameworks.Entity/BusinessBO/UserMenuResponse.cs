using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tracy.WebFrameworks.Entity.BusinessBO
{
    /// <summary>
    /// 获取用户所拥有菜单权限response
    /// </summary>
    [Serializable]
    [DataContract(IsReference=true)]
    public class UserMenuResponse
    {
        [DataMember]
        public string MenuName { get; set; }

        [DataMember]
        public int MenuId { get; set; }

        [DataMember]
        public string MenuIcon { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public int MenuParentId { get; set; }

        [DataMember]
        public int MenuSort { get; set; }

        [DataMember]
        public string LinkAddress { get; set; }

    }
}
