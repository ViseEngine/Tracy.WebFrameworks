using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    [Serializable]
    public class CheckLoginRequest
    {
        public string loginName { get; set; }

        public string loginPwd { get; set; }

        public string remember { get; set; }

    }
}
