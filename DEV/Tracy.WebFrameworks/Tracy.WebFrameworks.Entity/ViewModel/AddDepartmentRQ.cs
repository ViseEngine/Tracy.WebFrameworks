using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    /// <summary>
    /// 添加部门request
    /// </summary>
    [Serializable]
    public class AddDepartmentRQ
    {
        public string Name { get; set; }

        public string Code { get; set; }

        /// <summary>
        /// 部门上级
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 部门所属公司
        /// </summary>
        public int CorpId { get; set; }

        public int Sort { get; set; }

    }
}
