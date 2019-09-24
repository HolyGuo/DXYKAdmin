//*******************************
// Create By Holy Guo
// Date 2019-09-12 18:29
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
    /// 用户信息表
    ///</summary>
    public class SysUser
    {
        ///<summary>
        /// 唯一标识
        ///</summary>
        public virtual long id { get; set; }
        ///<summary>
        /// 姓名
        ///</summary>
        public virtual string true_name { get; set; }
        ///<summary>
        /// 昵称
        ///</summary>
        public virtual string nick_name { get; set; }
        ///<summary>
        /// 登录账号
        ///</summary>
        public virtual string login_name { get; set; }
        ///<summary>
        /// 登录密码
        ///</summary>
        public virtual string login_pwd { get; set; }
        ///<summary>
        /// 状态
        ///</summary>
        public virtual string is_enable { get; set; }
        ///<summary>
        /// 人员类型
        ///</summary>
        public virtual string user_type { get; set; }
        ///<summary>
        /// 性别
        ///</summary>
        public virtual string sex { get; set; }
        ///<summary>
        /// 头像
        ///</summary>
        public virtual string head_pic { get; set; }
        ///<summary>
        /// 电话
        ///</summary>
        public virtual string telephone { get; set; }
        ///<summary>
        /// 手机
        ///</summary>
        public virtual string mobile { get; set; }
        ///<summary>
        /// 邮箱
        ///</summary>
        public virtual string email { get; set; }
        ///<summary>
        /// 描述
        ///</summary>
        public virtual string summary { get; set; }
        ///<summary>
        /// 组织机构Id
        ///</summary>
        public virtual long? org_id { get; set; }
        ///<summary>
        /// 最近一次登录时间
        ///</summary>
        public virtual DateTime? last_login_time { get; set; }
        ///<summary>
        /// 微信OpenId/UnionId
        ///</summary>
        public virtual string wx_openid { get; set; }
        ///<summary>
        /// 微信号
        ///</summary>
        public virtual string wx_id { get; set; }
        ///<summary>
        /// 微信昵称
        ///</summary>
        public virtual string wx_name { get; set; }
        ///<summary>
        /// QQ开发者Id
        ///</summary>
        public virtual string qq_openid { get; set; }
        ///<summary>
        /// QQ号
        ///</summary>
        public virtual string qq_id { get; set; }
        ///<summary>
        /// QQ昵称
        ///</summary>
        public virtual string qq_name { get; set; }
        ///<summary>
        /// 排序
        ///</summary>
        public virtual int? sort { get; set; }
        ///<summary>
        /// 用于全局数据划分
        ///</summary>
        public virtual long? group_id { get; set; }
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
        /// 更新时间
        ///</summary>
        public virtual DateTime? deleted_time { get; set; }
    }
}

