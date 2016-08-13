using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    /// <summary>
    /// 修改公司
    /// </summary>
    public class EditCorporationRQ
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 新公司名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 新的排序
        /// </summary>
        public int Sort { get; set; }

    }
}
