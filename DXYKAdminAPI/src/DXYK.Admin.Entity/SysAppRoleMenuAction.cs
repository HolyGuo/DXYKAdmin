//*******************************
// Create By Holy Guo
// Date 2019-09-12 18:29
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
        /// 角色授权功能表
        ///</summary>
    public class SysAppRoleMenuAction
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
        /// 菜单id
        ///</summary>
public virtual long? menu_id { get; set; }
    }
    }

