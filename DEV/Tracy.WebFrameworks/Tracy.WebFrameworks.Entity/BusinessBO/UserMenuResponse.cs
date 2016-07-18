using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracy.WebFrameworks.Entity.BusinessBO
{
    /// <summary>
    /// 获取用户所拥有菜单权限response
    /// </summary>
    [Serializable]
    public class UserMenuResponse
    {
        public string MenuName { get; set; }

        public int MenuId { get; set; }

        public string MenuIcon { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public int MenuParentId { get; set; }

        public int MenuSort { get; set; }

        public string LinkAddress { get; set; }

    }
}
