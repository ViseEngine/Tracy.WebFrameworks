using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tracy.WebFrameworks.Entity.Enum
{
    /// <summary>
    /// 日志类型
    /// </summary>
    [DataContract]
    public enum LogType : byte
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "错误日志")]
        [EnumMember]
        Error = 1,

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "调试日志")]
        [EnumMember]
        Debug = 2
    }

    [DataContract]
    public enum OrgTreeType : byte
    {
        /// <summary>
        /// 公司
        /// </summary>
        [Display(Name = "公司")]
        [EnumMember]
        Corporation = 1,

        /// <summary>
        /// 部门
        /// </summary>
        [Display(Name = "部门")]
        [EnumMember]
        Department = 2
    }

}
