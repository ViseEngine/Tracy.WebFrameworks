using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    /// <summary>
    /// 获取组织机构树数据
    /// </summary>
    [Serializable]
    public class GetOrgTreeDataRQ
    {
        /// <summary>
        /// 组织机构类型
        /// </summary>
        public string OrgType { get; set; }

    }
}
