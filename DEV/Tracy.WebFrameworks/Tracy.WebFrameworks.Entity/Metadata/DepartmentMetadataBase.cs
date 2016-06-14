
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码是根据模板生成的。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，则所做更改将丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using DataAnnotationsExtensions;//http://dataannotationsextensions.org/


namespace Tracy.WebFrameworks.Entity.Metadata
{

/// <summary>
///  CustomMetadata基類
/// </summary>
[DataContract]
public class DepartmentMetadataBase
{


	/// <summary>
    /// 
	/// </summary>
    [Key]
    [Required]
    [Digits]
    [Max(int.MaxValue)]
    [DataMember]
    public object DepartmentID { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Required]
    [Digits]
    [Max(int.MaxValue)]
    [DataMember]
    public object ParentDeptID { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Digits]
    [Max(int.MaxValue)]
    [DataMember]
    public object CorporationID { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [StringLength(30)]
    [DataMember]
    public object DepartmentCode { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Required]
    [StringLength(100)]
    [DataMember]
    public object DepartmentName { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [DataMember]
    public object Enabled { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [StringLength(30)]
    [DataMember]
    public object CreatedBy { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [DataType(DataType.Date)]
    [UIHint("DatePicker")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    [DataMember]
    public object CreatedTime { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [StringLength(30)]
    [DataMember]
    public object LastUpdatedBy { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [DataType(DataType.Date)]
    [UIHint("DatePicker")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    [DataMember]
    public object LastUpdatedTime { get; set; }

}


}
