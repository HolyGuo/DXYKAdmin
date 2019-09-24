//*******************************
// Create By Holy Guo
// Date 2019-09-08 14:52
//*******************************
using DXYK.Admin.Dto.Sys;
using SmartSql.DyRepository.Annotations;
using System.Threading.Tasks;

namespace DXYK.Admin.Repository
{
    ///<summary>
    /// 用户信息
    ///</summary>
    public interface IAuthorizeRepository
    {

        ///<summary>
        /// 根据用户名密码登录
        ///</summary>
        [Statement(Id = "LoginIn")]
        UserInfo LoginIn([Param("loginname")]string loginnamed);

        /////<summary>
        /// 根据用户名密码登录
        ///</summary>
        [Statement(Id = "LoginIn")]
        Task<UserInfo> LoginInAsync([Param("loginname")]string loginname);

    }
}

