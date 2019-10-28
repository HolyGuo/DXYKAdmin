//*******************************
// Create By Holy Guo
// Date 2019-10-20 01:08
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
    /// 附件信息表
    ///</summary>
    public class OaAttachment
    {
        ///<summary>
        /// 唯一标识
        ///</summary>
        public virtual long id { get; set; }
        ///<summary>
        /// 业务数据id
        ///</summary>
        public virtual long? obj_id { get; set; }
        ///<summary>
        /// 文件唯一标识
        ///</summary>
        public virtual string hash_value { get; set; }
        ///<summary>
        /// 文件名称
        ///</summary>
        public virtual string file_name { get; set; }
        ///<summary>
        /// 文件扩展名
        ///</summary>
        public virtual string file_ext { get; set; }
        ///<summary>
        /// 文件类型
        ///</summary>
        public virtual string file_type { get; set; }
        ///<summary>
        /// 文件大小
        ///</summary>
        public virtual string file_size { get; set; }
        ///<summary>
        /// 服务器名称(IP或编号)
        ///</summary>
        public virtual string server_name { get; set; }
        ///<summary>
        /// 上传路径
        ///</summary>
        public virtual string upload_path { get; set; }
        ///<summary>
        /// 发布路径
        ///</summary>
        public virtual string publish_path { get; set; }
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

