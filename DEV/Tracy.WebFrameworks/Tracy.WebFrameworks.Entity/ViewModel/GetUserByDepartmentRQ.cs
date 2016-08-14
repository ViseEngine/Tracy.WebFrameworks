using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tracy.WebFrameworks.Entity.CommonBO;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    /// <summary>
    /// 获取指定部门下的所有用户
    /// </summary>
    public class GetUserByDepartmentRQ: PagingBase
    {
        /// <summary>
        /// 选择的部门id，多个id以','分隔
        /// 如：1,2,3
        /// </summary>
        public string DeptIds { get; set; }

    }
}
