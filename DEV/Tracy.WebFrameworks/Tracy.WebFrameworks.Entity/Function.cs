
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码是根据模板生成的。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，则所做更改将丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Tracy.WebFrameworks.Entity.Metadata;


namespace Tracy.WebFrameworks.Entity
{

/// <summary>
/// <para>【WebFrameworks.Entity.tt生成的，与数据库对应的】</para>
/// 操作(功能),一个菜单包含多个操作

/// </summary>
[Serializable]
[DataContract(IsReference = true)]
[MetadataType(typeof(FunctionMetadata))]
public partial class Function
{

	/// <summary>
	/// 创建操作(功能),一个菜单包含多个操作新实例
	/// </summary>
    public Function()
    {

        this.RoleFunction = new HashSet<RoleFunction>();

    }



	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public int FunctionID { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string FunctionName { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string FunctionRefName { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string CreatedBy { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public System.DateTime CreatedTime { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string LastUpdateBy { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public Nullable<System.DateTime> LastUpdateTime { get; set; }




	/// <summary>
    /// 獲取或設置(導航屬性)
	/// </summary>
    [DataMember]
    public virtual ICollection<RoleFunction> RoleFunction { get; set; }

}


}
