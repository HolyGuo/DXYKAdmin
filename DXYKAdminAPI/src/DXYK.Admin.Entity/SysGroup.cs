//*******************************
// Create By Holy Guo
// Date 2019-10-03 09:12
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
    /// 群组信息表
    ///</summary>
    public class SysGroup
    {
        ///<summary>
        /// 唯一标识
        ///</summary>
        public virtual string id { get; set; }
        ///<summary>
        /// 群组名称
        ///</summary>
        public virtual string group_name { get; set; }
        ///<summary>
        /// 群组简称
        ///</summary>
        public virtual string group_short_name { get; set; }
        ///<summary>
        /// logo
        ///</summary>
        public virtual string logo_pic { get; set; }
        ///<summary>
        /// 联系人
        ///</summary>
        public virtual string contact_user_name { get; set; }
        ///<summary>
        /// 联系人电话
        ///</summary>
        public virtual string contact_user_mobile { get; set; }
        ///<summary>
        /// 状态
        ///</summary>
        public virtual string is_enable { get; set; }
        ///<summary>
        /// 排序
        ///</summary>
        public virtual int? sort { get; set; }
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

