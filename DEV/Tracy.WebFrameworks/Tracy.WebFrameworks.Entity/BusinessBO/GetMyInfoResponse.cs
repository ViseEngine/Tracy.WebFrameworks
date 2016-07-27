using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tracy.WebFrameworks.Entity.BusinessBO
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class GetMyInfoResponse
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string CreatedTime { get; set; }

        [DataMember]
        public string RolesName { get; set; }

        [DataMember]
        public string DepartmentsName { get; set; }

    }
}
