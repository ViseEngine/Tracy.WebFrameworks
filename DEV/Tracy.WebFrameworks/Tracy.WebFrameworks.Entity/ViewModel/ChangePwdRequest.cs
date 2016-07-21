using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    [Serializable]
    public class ChangePwdRequest
    {
        public int EmployeeId { get; set; }

        public string OriginalPwd { get; set; }

        public string NewPwd { get; set; }

    }
}
