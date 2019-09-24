//*******************************
// Create By Holy Guo
// Date 2019-09-08 14:52
//*******************************
using DXYK.Admin.Dto.Sys;
using DXYK.Admin.Repository;
using System.Threading.Tasks;

namespace DXYK.Admin.Service
{
    ///<summary>
    /// 用户信息
    ///</summary>
    public class AuthorizeService
    {

        ///<summary>
        ///UserService 仓储
        ///</summary>
        public IAuthorizeRepository _authorizeRepository { get; }

        ///<summary>
        ///SysUserService 构造函数
        ///</summary>
        public AuthorizeService(IAuthorizeRepository authorizeRepository)
        {
            _authorizeRepository = authorizeRepository;
        }

        /// <summary>
        /// 根据用户名密码登录
        /// </summary>
        /// <param name="loginname">用户名</param>
        /// <param name="loginpwd">密码</param>
        /// <returns></returns>
        public UserInfo LoginIn(string loginname)
        {
            return _authorizeRepository.LoginIn(loginname);
        }

        /// <summary>
        /// 根据用户名密码登录
        /// </summary>
        /// <param name="loginname">用户名</param>
        /// <param name="loginpwd">密码</param>
        /// <returns></returns>
        public async Task<UserInfo> LoginInAsync(string loginname)
        {
            return await _authorizeRepository.LoginInAsync(loginname);
        }



    }
}

