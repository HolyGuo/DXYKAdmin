//*******************************
// Create By Holy Guo
// Date 2019-10-06 17:28
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
    /// 用户应用角色授权表
    ///</summary>
    public class SysUserAppRole
    {
        ///<summary>
        /// 唯一标识
        ///</summary>
        public virtual string id { get; set; }
        ///<summary>
        /// 用户id
        ///</summary>
        public virtual string user_id { get; set; }
        ///<summary>
        /// 应用id
        ///</summary>
        public virtual string app_id { get; set; }
        ///<summary>
        /// 角色id
        ///</summary>
        public virtual string role_id { get; set; }
        ///<summary>
        /// 用于全局数据划分
        ///</summary>
        public virtual string group_id { get; set; }
    }
}

