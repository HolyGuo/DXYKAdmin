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
        /// 菜单编码
        ///</summary>
        public virtual string name { get; set; }

        ///<summary>
        /// 上级菜单id
        ///</summary>
        public virtual string pid { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public virtual string path { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public virtual string icon { get; set; }

        /// <summary>
        /// 是否可见
        /// </summary>
        public virtual string hidden { get; set; } = "false";



    }
}
