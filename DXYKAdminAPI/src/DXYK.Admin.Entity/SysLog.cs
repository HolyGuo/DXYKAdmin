//*******************************
// Create By Holy Guo
// Date 2019-09-12 15:48
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
    /// 系统日志表
    ///</summary>
    public class SysLog
    {
        ///<summary>
        /// 唯一标识
        ///</summary>
        public virtual long id { get; set; }
        ///<summary>
        /// 应用id
        ///</summary>
        public virtual string app_id { get; set; }
        ///<summary>
        /// 日志时间
        ///</summary>
        public virtual DateTime? logged_time { get; set; }
        ///<summary>
        /// 日志级别
        ///</summary>
        public virtual string level { get; set; }
        ///<summary>
        /// 日志内容
        ///</summary>
        public virtual string msg { get; set; }
        ///<summary>
        /// 异常内容
        ///</summary>
        public virtual string exception { get; set; }
        ///<summary>
        /// 状态
        ///</summary>
        public virtual string status { get; set; }
        ///<summary>
        /// 请求地址
        ///</summary>
        public virtual string call_url { get; set; }
        ///<summary>
        /// IP
        ///</summary>
        public virtual string ip { get; set; }
        ///<summary>
        /// 用户ID
        ///</summary>
        public virtual long? user_id { get; set; }
        ///<summary>
        /// 登录账号
        ///</summary>
        public virtual string login_name { get; set; }
        ///<summary>
        /// 姓名
        ///</summary>
        public virtual string true_name { get; set; }
        ///<summary>
        /// 浏览器
        ///</summary>
        public virtual string browser { get; set; }
    }
}

