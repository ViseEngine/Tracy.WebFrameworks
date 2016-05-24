
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
/// 菜单(页面) CustomMetadata基類
/// </summary>
[DataContract]
public class MenuMetadataBase
{


	/// <summary>
    /// 
	/// </summary>
    [Key]
        [Required]
        [Digits]
        [Max(int.MaxValue)]
        [DataMember]
    public object MenuID { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Required]
        [Digits]
        [Max(int.MaxValue)]
        [DataMember]
    public object ParentMenuID { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Required]
        [StringLength(30)]
        [DataMember]
    public object MenuName { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Required]
        [StringLength(200)]
        [DataMember]
    public object MenuUrl { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Digits]
        [Max(int.MaxValue)]
        [DataMember]
    public object MenuLevel { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [Required]
        [Digits]
        [Max(int.MaxValue)]
        [DataMember]
    public object SortOrder { get; set; }


	/// <summary>
    /// 菜单图标url
	/// </summary>
    [DisplayName("菜单图标url")]
        [StringLength(200)]
        [DataMember]
    public object MenuIcon { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [DataMember]
    public object IsShortcut { get; set; }


	/// <summary>
    /// 
	/// </summary>
    [DataMember]
    public object IsShow { get; set; }


	/// <summary>
    /// 该菜单所包含的操作集合
	/// </summary>
    [DisplayName("该菜单所包含的操作集合")]
        [DataMember]
    public object FunctionIDs { get; set; }


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
