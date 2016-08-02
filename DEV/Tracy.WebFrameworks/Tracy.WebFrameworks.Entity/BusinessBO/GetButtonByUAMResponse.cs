using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tracy.WebFrameworks.Entity.BusinessBO
{
    [Serializable]
    [DataContract(IsReference= true)]
    public class GetButtonByUAMResponse
    {
        [DataMember]
        public int ButtonId { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public int ButtonSort { get; set; }

    }
}
