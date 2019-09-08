//*******************************
// Create By Holy Guo
// Date 2019-09-08 14:52
//*******************************
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using DXYK.Admin.Entity;
using DXYK.Admin.Repository;
using DXYK.Admin.Entity.Dto;

namespace DXYK.Admin.Service
{
    ///<summary>
    /// 用户信息
    ///</summary>
    public class UserService
    {

        ///<summary>
        ///SysUserService 仓储
        ///</summary>
        public IUserRepository _userRepository { get; }

        ///<summary>
        ///SysUserService 构造函数
        ///</summary>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 根据用户名密码登录
        /// </summary>
        /// <param name="loginname">用户名</param>
        /// <param name="loginpwd">密码</param>
        /// <returns></returns>
        public UserDto LoginIn(string loginname, string loginpwd)
        {
            return _userRepository.LoginIn(loginname, loginpwd);
        }

        /// <summary>
        /// 根据用户名密码登录
        /// </summary>
        /// <param name="loginname">用户名</param>
        /// <param name="loginpwd">密码</param>
        /// <returns></returns>
        public async Task<UserDto> LoginInAsync(string loginname, string loginpwd)
        {
            return await _userRepository.LoginInAsync(loginname, loginpwd);
        }



    }
}

