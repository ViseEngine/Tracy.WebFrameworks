
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
/// 职员(用户)，一个用户只属于一个公司的一个部门。

/// </summary>
[Serializable]
[DataContract(IsReference = true)]
[MetadataType(typeof(EmployeeMetadata))]
public partial class Employee
{


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public int EmployeeID { get; set; }


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
    public int DepartmentID { get; set; }


	/// <summary>
    /// 獲取或設置职员所拥有角色列表，用','分隔
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string RoleIDs { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string EmployeeName { get; set; }


	/// <summary>
    /// 獲取或設置登录帐号
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string LoginName { get; set; }


	/// <summary>
    /// 獲取或設置登录密码，加密保存
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string Password { get; set; }


	/// <summary>
    /// 獲取或設置
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public System.DateTime PwdExpiredTime { get; set; }


	/// <summary>
    /// 獲取或設置性别，0：未知，1：女，2：男
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public byte Sex { get; set; }


	/// <summary>
    /// 獲取或設置电话
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string Phone { get; set; }


	/// <summary>
    /// 獲取或設置邮箱
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string Email { get; set; }


	/// <summary>
    /// 獲取或設置状态。
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public byte Status { get; set; }


	/// <summary>
    /// 獲取或設置登录次数
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public Nullable<int> LoginCount { get; set; }


	/// <summary>
    /// 獲取或設置最后登录时间
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public Nullable<System.DateTime> LastLoginTime { get; set; }


	/// <summary>
    /// 獲取或設置最后登录IP
	/// </summary>
    [DatabaseTableColumn]
    [DataMember]
    public string LastLoginIP { get; set; }


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
    public virtual Corporation Corporation { get; set; }


	/// <summary>
    /// 獲取或設置(導航屬性)
	/// </summary>
    [DataMember]
    public virtual Department Department { get; set; }

}


}
