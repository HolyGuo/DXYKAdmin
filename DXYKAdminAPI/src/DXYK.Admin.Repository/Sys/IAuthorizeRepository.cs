//*******************************
// Create By Holy Guo
// Date 2019-09-08 14:52
//*******************************
using DXYK.Admin.Dto.Sys;
using DXYK.Admin.Entity;
using SmartSql.DyRepository.Annotations;
using System.Collections.Generic;
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

        /// <summary>
        /// 查询用户已授权的App 和Role
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        [Statement(Id = "QueryUerAppRole")]
        List<SysUserAppRole> QueryUerAppRole([Param("userId")]long userId);

        /// <summary>
        /// 查询用户已授权的App 和Role
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        [Statement(Id = "QueryUerAppRole")]
        Task<List<SysUserAppRole>> QueryUerAppRoleAsync([Param("userId")]string userId);

        /// <summary>
        /// 查询角色对应的权限映射
        /// </summary>
        /// <param name="groupId">群组id</param>
        /// <param name="roleIds">角色id</param>
        /// <returns></returns>
        [Statement(Id = "QueryRoleMap")]
        List<RoleMapDto> QueryRoleMap(string groupId, List<long> roleIds);

        /// <summary>
        /// 查询角色对应的权限映射
        /// </summary>
        /// <param name="groupId">群组id</param>
        /// <param name="roleIds">角色id集合</param>
        /// <returns></returns>
        [Statement(Id = "QueryRoleMap")]
        Task<List<RoleMapDto>> QueryRoleMapAsync(string groupId, List<long> roleIds);

    }
}

