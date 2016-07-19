using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    [Serializable]
    public class FirstLoginRequest
    {
        public int EmployeeId { get; set; }

        public string NewPwd { get; set; }

    }
}
