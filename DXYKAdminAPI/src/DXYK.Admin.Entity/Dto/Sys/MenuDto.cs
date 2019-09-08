using System;
using System.Collections.Generic;
using System.Text;

namespace DXYK.Admin.Entity.Dto
{
    public class MenuDto
    {
        ///<summary>
        /// 唯一标识
        ///</summary>
        public virtual long id { get; set; }
        ///<summary>
        /// 菜单名称
        ///</summary>
        public virtual string title { get; set; }
        ///<summary>
        /// 上级id
        ///</summary>
        public virtual long? parent_id { get; set; }
        ///<summary>
        /// 图标(Css-Class)
        ///</summary>
        public virtual string icon { get; set; }
        ///<summary>
        /// 菜单类型
        ///</summary>
        public virtual string menu_type { get; set; }
        ///<summary>
        /// 跳转
        ///</summary>
        public virtual string jump { get; set; }
        ///<summary>
        /// 排序
        ///</summary>
        public virtual int? sort { get; set; }
        ///<summary>
        /// 群组id
        ///</summary>
        public virtual long? group_id { get; set; }
    }
}
