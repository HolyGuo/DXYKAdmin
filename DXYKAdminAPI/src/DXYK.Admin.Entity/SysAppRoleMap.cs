//*******************************
// Create By Holy Guo
// Date 2019-10-03 09:12
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
    /// 角色授权表
    ///</summary>
    public class SysAppRoleMap
    {
        ///<summary>
        /// 唯一标识
        ///</summary>
        public virtual long id { get; set; }
        ///<summary>
        /// 角色id
        ///</summary>
        public virtual long? role_id { get; set; }
        ///<summary>
        /// 类型编码(1：菜单权限，2：功能权限)
        ///</summary>
        public virtual int? type_code { get; set; }
        ///<summary>
        /// 权限id
        ///</summary>
        public virtual long? map_id { get; set; }
        ///<summary>
        /// 群组id
        ///</summary>
        public virtual string group_id { get; set; }
    }
}

