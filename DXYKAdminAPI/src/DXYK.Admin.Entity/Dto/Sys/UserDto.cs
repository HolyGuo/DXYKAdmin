using System;
using System.Collections.Generic;
using System.Text;

namespace DXYK.Admin.Entity.Dto
{
    public class UserDto
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfo User { get; set; }

        /// <summary>
        /// 授权菜单集合
        /// </summary>
        public List<MenuDto> MenuList { get; set; }

    }

    public class UserInfo
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
        /// 性别
        ///</summary>
        public virtual string sex { get; set; }
        ///<summary>
        /// 头像
        ///</summary>
        public virtual string head_pic { get; set; }
        ///<summary>
        /// 用于全局数据划分
        ///</summary>
        public virtual long? group_id { get; set; }
        ///<summary>
        /// 创建时间
        ///</summary>
        public virtual DateTime? created_time { get; set; }
    }

    public class UserLoginDto
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string loginname { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 应用系统id
        /// </summary>
        public string appid { get; set; }
    }

    public class UserLoginConfigDto
    {
        /// <summary>
        /// 登录次数
        /// </summary>
        public int Count { get; set; } = 0;

        /// <summary>
        /// 过期时间-分钟
        /// </summary>
        public DateTime? DelayMinute { get; set; }
    }
}
