using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tracy.WebFrameworks.Entity.BusinessBO
{
    [Serializable]
    [DataContract(IsReference=true)]
    public class GetLeftMenuResponse
    {
        [DataMember]
        public int MenuId { get; set; }

        [DataMember]
        public string MenuName { get; set; }

        [DataMember]
        public string MenuIcon { get; set; }

        [DataMember]
        public int MenuParentId { get; set; }

        [DataMember]
        public int MenuSort { get; set; }

        [DataMember]
        public string MenuUrl { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string LoginId { get; set; }

    }
}
