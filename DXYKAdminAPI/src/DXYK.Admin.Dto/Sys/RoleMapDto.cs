using System;
using System.Collections.Generic;
using System.Text;

namespace DXYK.Admin.Dto.Sys
{
    /// <summary>
    /// 角色对应权限
    /// </summary>
    public class RoleMapDto
    {
        ///<summary>
        /// 唯一标识
        ///</summary>
        public virtual string id { get; set; }
        ///<summary>
        /// 角色id
        ///</summary>
        public virtual string role_id { get; set; }
        ///<summary>
        /// 类型编码
        ///</summary>
        public virtual int type_code { get; set; }
        ///<summary>
        /// 权限id
        ///</summary>
        public virtual string map_id { get; set; }
        ///<summary>
        /// 群组id
        ///</summary>
        public virtual string group_id { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        public virtual string menu_code { get; set; }
        /// <summary>
        /// 父级菜单id
        /// </summary>
        public virtual string menu_pid { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public virtual string menu_icon { get; set; }
        /// <summary>
        /// 菜单标题
        /// </summary>
        public virtual string menu_title { get; set; }
        /// <summary>
        /// 菜单类型
        /// </summary>
        public virtual string menu_type { get; set; }
        /// <summary>
        /// 跳转路径
        /// </summary>
        public virtual string menu_jump { get; set; }
        /// <summary>
        /// 功能编码
        /// </summary>
        public virtual string action_code { get; set; }
        /// <summary>
        /// 父级功能id
        /// </summary>
        public virtual string action_pid { get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>
        public virtual string action_name { get; set; }

        ///<summary>
        /// 地址url
        ///</summary>
        public virtual string action_url { get; set; }

    }
}
