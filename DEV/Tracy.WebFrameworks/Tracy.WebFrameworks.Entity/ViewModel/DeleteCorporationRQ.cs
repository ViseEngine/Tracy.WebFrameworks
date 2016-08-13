using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracy.WebFrameworks.Entity.ViewModel
{
    /// <summary>
    /// 删除公司request
    /// </summary>
    public class DeleteCorporationRQ
    {
        /// <summary>
        /// 被删除的公司id
        /// 格式：1,2,3
        /// </summary>
        public string DeleteCorpIds { get; set; }

    }
}
