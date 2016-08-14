using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tracy.WebFrameworks.Entity.CommonBO;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    /// <summary>
    /// 获取指定公司下的所有部门
    /// </summary>
    public class GetDepartmentByCorpRQ: PagingBase
    {
        /// <summary>
        /// 选择的公司id
        /// </summary>
        public int CorporationId { get; set; }

    }
}
