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
        public List<RoleMapDto> QueryRoleMap(string groupId, List<long> roleIds)
        {
            return _authorizeRepository.QueryRoleMap(groupId, roleIds);
        }

        /// <summary>
        /// 查询角色对应的权限映射
        /// </summary>
        /// <param name="groupId">群组id</param>
        /// <param name="roleIds">角色id集合</param>
        /// <returns></returns>
        public async Task<List<RoleMapDto>> QueryRoleMapAsync(string groupId, List<long> roleIds)
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
            try
            {
                //查询用户授权的应用和对应的角色
                List<SysUserAppRole> sysUserAppRoleList = _authorizeRepository.QueryUerAppRole(userId);
                if (sysUserAppRoleList != null && sysUserAppRoleList.Count > 0)
                {
                    //获取已授权所有应用app
                    List<string> appIds = sysUserAppRoleList.Select(s => s.app_id).ToList().Distinct().ToList();
                    //获取已授权所有role
                    List<long> roleIds = sysUserAppRoleList.Select(s => s.role_id).ToList();
                    //查询role对应的权限
                    List<RoleMapDto> roleMapList = _authorizeRepository.QueryRoleMap(groupId, roleIds);
                    result = new List<Permission>();
                    foreach (string appid in appIds)
                    {
                        Permission p = new Permission();
                        p.AppId = appid;
                        List<long> roles = sysUserAppRoleList.Where(s => s.app_id == appid).Select(s => s.role_id).ToList();
                        //查询授权菜单
                        p.Menu = roleMapList.Where(s => roles.Contains(s.role_id) && s.type_code == 1).Select(s => new Menu
                        {
                            id = s.map_id,
                            menu_code = s.menu_code,
                            title = s.menu_title,
                            parent_id = s.menu_pid,
                            icon = s.menu_icon,
                            menu_type = s.menu_type,
                            jump = s.menu_jump
                        }).ToList();
                        if (p.Menu != null && p.Menu.Count == 0)
                        {
                            p.Menu = null;
                        }
                        //查询授权功能
                        p.Action = roleMapList.Where(s => roles.Contains(s.role_id) && s.type_code == 2).Select(s => new Action
                        {
                            id = s.map_id,
                            action_code = s.action_code,
                            action_name = s.action_name,
                            url = s.action_url,
                            parent_id = s.action_pid

                        }).ToList();
                        if (p.Action != null && p.Action.Count == 0)
                        {
                            p.Action = null;
                        }
                        result.Add(p);
                    }
                }
            }
            catch (System.Exception)
            {
                result = null;
            }
            return result;
        }

    }
}

