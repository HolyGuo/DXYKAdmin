//*******************************
// Create By Holy Guo
// Date 2019-10-20 01:08
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
    /// 邮件信息表
    ///</summary>
    public class OaMail
    {
        ///<summary>
        /// 唯一标识
        ///</summary>
        public virtual long id { get; set; }
        ///<summary>
        /// 标题
        ///</summary>
        public virtual string title { get; set; }
        ///<summary>
        /// 发布时间
        ///</summary>
        public virtual DateTime? publish_time { get; set; }
        ///<summary>
        /// 内容
        ///</summary>
        public virtual string content { get; set; }
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

