//*******************************
// Create By Holy Guo
// Date 2019-10-06 22:21
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
    /// 功能信息表
    ///</summary>
    public class SysAppAction
    {
        ///<summary>
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
        /// 描述
        ///</summary>
        public virtual string description { get; set; }
        ///<summary>
        /// 排序
        ///</summary>
        public virtual int? sort { get; set; }
        ///<summary>
        /// 状态
        ///</summary>
        public virtual string is_enable { get; set; }
        ///<summary>
        /// 上级id
        ///</summary>
        public virtual long parent_id { get; set; }
        ///<summary>
        /// 群组id
        ///</summary>
        public virtual string group_id { get; set; }
        ///<summary>
        /// 乐观锁
        ///</summary>
        public virtual int? re_vision { get; set; }
        ///<summary>
        /// 创建人
        ///</summary>
        public virtual long? created_by { get; set; }
        ///<summary>
        /// 创建时间
        ///</summary>
        public virtual DateTime? created_time { get; set; }
        ///<summary>
        /// 更新人
        ///</summary>
        public virtual long? updated_by { get; set; }
        ///<summary>
        /// 更新时间
        ///</summary>
        public virtual DateTime? updated_time { get; set; }
        ///<summary>
        /// 删除人
        ///</summary>
        public virtual long? deleted_by { get; set; }
        ///<summary>
        /// 删除时间
        ///</summary>
        public virtual DateTime? deleted_time { get; set; }
    }
}

