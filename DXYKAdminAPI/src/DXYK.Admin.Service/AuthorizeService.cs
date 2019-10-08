//*******************************
// Create By Holy Guo
// Date 2019-09-08 14:52
//*******************************
using DXYK.Admin.Dto.Sys;
using DXYK.Admin.Entity;
using DXYK.Admin.Repository;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// 查询用户已授权的App 和Role
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public List<SysUserAppRole> QueryUerAppRole(long userId)
        {
            return _authorizeRepository.QueryUerAppRole(userId);
        }

        /// <summary>
        /// 查询用户已授权的App 和Role
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public async Task<List<SysUserAppRole>> QueryUerAppRoleAsync(string userId)
        {
            return await _authorizeRepository.QueryUerAppRoleAsync(userId);
        }

        /// <summary>
        /// 查询角色对应的权限映射
        /// </summary>
        /// <param name="groupId">群组id</param>
        /// <param name="roleIds">角色id集合</param>
        /// <returns></returns>
        public List<SysAppRoleMap> QueryRoleMap(string groupId, List<long> roleIds)
        {
            return _authorizeRepository.QueryRoleMap(groupId, roleIds);
        }

        /// <summary>
        /// 查询角色对应的权限映射
        /// </summary>
        /// <param name="groupId">群组id</param>
        /// <param name="roleIds">角色id集合</param>
        /// <returns></returns>
        public async Task<List<SysAppRoleMap>> QueryRoleMapAsync(string groupId, List<long> roleIds)
        {
            return await _authorizeRepository.QueryRoleMapAsync(groupId, roleIds);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Permission> GetPermission(string groupId, long userId)
        {
            List<Permission> result = null;
            //查询用户授权的应用和对应的角色
            List<SysUserAppRole> sysUserAppRoleList = _authorizeRepository.QueryUerAppRole(userId);
            if (sysUserAppRoleList != null && sysUserAppRoleList.Count > 0)
            {
                var appIds = sysUserAppRoleList.Select(s =>s.app_id).ToList().Distinct().ToList();

                result = new List<Permission>();
                List<long> roleIds = new List<long>();
                foreach (SysUserAppRole item in sysUserAppRoleList)
                {
                    Permission p = new Permission();
                    if (result.FindIndex(s => s.AppId == item.app_id) < 0)
                    {
                        p.AppId = item.app_id;
                    }
                    roleIds.Add(item.role_id);
                }


                List<SysAppRoleMap> roleMapList = _authorizeRepository.QueryRoleMap(groupId, roleIds);
            }
            return result;
        }

    }
}

