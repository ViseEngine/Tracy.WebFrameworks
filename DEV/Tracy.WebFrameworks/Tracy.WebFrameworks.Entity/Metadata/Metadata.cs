using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tracy.WebFrameworks.Entity.Metadata
{
    /// <summary>
    /// Corporation
    /// </summary>
    [DataContract]
    public class CorporationMetadata : CorporationMetadataBase
    {

    }

    /// <summary>
    /// Department
    /// </summary>
    [DataContract]
    public class DepartmentMetadata : DepartmentMetadataBase
    {

    }

    /// <summary>
    /// User
    /// </summary>
    [DataContract]
    public class UserMetadata : UserMetadataBase
    {

    }

    
    /// <summary>
    /// UserDepartment
    /// </summary>
    [DataContract]
    public class UserDepartmentMetadata : UserDepartmentMetadataBase
    {

    }

    /// <summary>
    /// Role
    /// </summary>
    [DataContract]
    public class RoleMetadata : RoleMetadataBase
    {

    }

    /// <summary>
    /// EmployeeRole
    /// </summary>
    [DataContract]
    public class UserRoleMetadata : UserRoleMetadataBase
    { 
        
    }

    /// <summary>
    /// Menu
    /// </summary>
    [DataContract]
    public class MenuMetadata : MenuMetadataBase
    {

    }

    /// <summary>
    /// Button
    /// </summary>
    [DataContract]
    public class ButtonMetadata : ButtonMetadataBase
    {

    }

    /// <summary>
    /// MenuButton
    /// </summary>
    [DataContract]
    public class MenuButtonMetadata : MenuButtonMetadataBase
    { 
        
    }

    /// <summary>
    /// RoleMenuButton
    /// </summary>
    [DataContract]
    public class RoleMenuButtonMetadata : RoleMenuButtonMetadataBase
    {

    }


}
