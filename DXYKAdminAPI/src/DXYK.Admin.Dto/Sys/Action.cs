using System;
using System.Collections.Generic;
using System.Text;

namespace DXYK.Admin.Dto.Sys
{
    public class Action
    {
        //<summary>
        /// 唯一标识
        ///</summary>
        public virtual long id { get; set; }
        ///<summary>
        /// 功能编码
        ///</summary>
        public virtual string action_code { get; set; }
        ///<summary>
        /// 功能名称
        ///</summary>
        public virtual string action_name { get; set; }
        ///<summary>
        /// 地址
        ///</summary>
        public virtual string url { get; set; }
        ///<summary>
        /// 上级id
        ///</summary>
        public virtual long? parent_id { get; set; }
    }
}
