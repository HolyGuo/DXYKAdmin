//*******************************
// Create By Holy Guo
// Date 2019-09-08 14:52
//*******************************
using DXYK.Admin.Entity.Dto;
using DXYK.Admin.Repository;
using System.Threading.Tasks;

namespace DXYK.Admin.Service
{
    ///<summary>
    /// 用户信息
    ///</summary>
    public class UserService
    {

        ///<summary>
        ///UserService 仓储
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
        public UserInfo LoginIn(string loginname)
        {
            return _userRepository.LoginIn(loginname);
        }

        /// <summary>
        /// 根据用户名密码登录
        /// </summary>
        /// <param name="loginname">用户名</param>
        /// <param name="loginpwd">密码</param>
        /// <returns></returns>
        public async Task<UserInfo> LoginInAsync(string loginname)
        {
            return await _userRepository.LoginInAsync(loginname);
        }



    }
}

