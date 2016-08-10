using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tracy.WebFrameworks.Entity.CommonBO;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    public class GetCorpDepartmentRQ : PagingBase
    {
        /// <summary>
        /// 公司id，多个公司id以，分隔
        /// </summary>
        public string CorpIds { get; set; }
    }
}
