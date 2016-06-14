
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
/// 

/// </summary>
[Serializable]
[DataContract(IsReference = true)]
[MetadataType(typeof(CorporationMetadata))]
public partial class Corporation
{

	/// <summary>
	/// 创建新实例
	/// </summary>
    public Corporation()
    {

        this.Employee = new HashSet<Employee>();

        this.Department = new HashSet<Department>();

    }



	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public int CorporationID { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public int ParentCorpID { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string CorporationCode { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string CorporationName { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string Address { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public Nullable<bool> Enabled { get; set; }


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
    public Nullable<System.DateTime> CreatedTime { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string LastUpdatedBy { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public Nullable<System.DateTime> LastUpdatedTime { get; set; }




	/// <summary>
    /// 獲取或設置(導航屬性)
	/// </summary>
    [DataMember]
    public virtual ICollection<Employee> Employee { get; set; }


	/// <summary>
    /// 獲取或設置(導航屬性)
	/// </summary>
    [DataMember]
    public virtual ICollection<Department> Department { get; set; }

}


}
