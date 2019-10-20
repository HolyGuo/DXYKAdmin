//*******************************
// Create By Holy Guo
// Date 2019-10-20 15:28
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
    /// 收件人信息表
    ///</summary>
    public class OaMailReceiver
    {
        ///<summary>
        /// 唯一标识
        ///</summary>
        public virtual long id { get; set; }
        ///<summary>
        /// 邮件id
        ///</summary>
        public virtual long? mail_id { get; set; }
        ///<summary>
        /// 邮件标题
        ///</summary>
        public virtual string mail_title { get; set; }
        ///<summary>
        /// 收件人id
        ///</summary>
        public virtual long? receiver_id { get; set; }
        ///<summary>
        /// 收件人名称
        ///</summary>
        public virtual string receiver_name { get; set; }
        ///<summary>
        /// 发件人id
        ///</summary>
        public virtual long? sender_id { get; set; }
        ///<summary>
        /// 发件人名称
        ///</summary>
        public virtual string sender_name { get; set; }
        ///<summary>
        /// 附件ids
        ///</summary>
        public virtual string attachment_ids { get; set; }
        ///<summary>
        /// 发件时间
        ///</summary>
        public virtual DateTime? send_time { get; set; }
        ///<summary>
        /// 阅读时间
        ///</summary>
        public virtual DateTime? read_time { get; set; }
    }
}

