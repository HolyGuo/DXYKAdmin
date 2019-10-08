//*******************************
// Create By Holy Guo
// Date 2019-10-03 09:12
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
    /// 应用信息表
    ///</summary>
    public class SysApp
    {
        ///<summary>
        /// 唯一标识
        ///</summary>
        public virtual string id { get; set; }
        ///<summary>
        /// 应用名称
        ///</summary>
        public virtual string app_name { get; set; }
        ///<summary>
        /// 简称
        ///</summary>
        public virtual string short_name { get; set; }
        ///<summary>
        /// 描述
        ///</summary>
        public virtual string description { get; set; }
        ///<summary>
        /// 状态
        ///</summary>
        public virtual string is_enable { get; set; }
        ///<summary>
        /// 系统图标
        ///</summary>
        public virtual string logo { get; set; }
        ///<summary>
        /// 排序
        ///</summary>
        public virtual int? sort { get; set; }
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

