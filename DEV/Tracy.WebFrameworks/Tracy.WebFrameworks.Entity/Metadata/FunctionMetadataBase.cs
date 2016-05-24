
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
/// 操作(功能),一个菜单包含多个操作 CustomMetadata基類
/// </summary>
[DataContract]
public class FunctionMetadataBase
{


	/// <summary>
    /// 
	/// </summary>
    [Key]
        [Required]
        [Digits]
        [Max(int.MaxValue)]
        [DataMember]
    public object FunctionID { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Required]
        [StringLength(30)]
        [DataMember]
    public object FunctionName { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Required]
        [StringLength(30)]
        [DataMember]
    public object FunctionRefName { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Required]
        [StringLength(30)]
        [DataMember]
    public object CreatedBy { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Required]
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
    public object LastUpdateBy { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [DataType(DataType.Date)]
        [UIHint("DatePicker")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataMember]
    public object LastUpdateTime { get; set; }

}


}
