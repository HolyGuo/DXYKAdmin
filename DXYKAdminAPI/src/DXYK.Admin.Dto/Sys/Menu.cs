using System;
using System.Collections.Generic;
using System.Text;

namespace DXYK.Admin.Dto.Sys
{
    public class Menu
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
        /// 类型编码
        ///</summary>
        public virtual int? type_code { get; set; }
        ///<summary>
        /// 权限id
        ///</summary>
        public virtual long? map_id { get; set; }
        ///<summary>
        /// 群组id
        ///</summary>
        public virtual long? group_id { get; set; }


    }
}
