//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using DXYK.Admin.API.Messages;
using DXYK.Admin.API.Utils;
using DXYK.Admin.Common;
using DXYK.Admin.Common.Cache;
using DXYK.Admin.Common.ConfigHelper;
using DXYK.Admin.Common.EnumHelper;
using DXYK.Admin.Dto.Sys;
using DXYK.Admin.Extensions.JWT;
using DXYK.Admin.Repository;
using DXYK.Admin.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DXYK.Admin.API.Controllers
{
    ///<summary>
    /// 用户信息
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorizeController : Controller
    {
        ///<summary>
        /// 用户信息UserService
        ///</summary>
        public AuthorizeService _authorizeService { get; }

        ///<summary>
        /// 用户信息IUserRepository
        ///</summary>
        public IAuthorizeRepository _uthorizeRepository { get; }

        ///<summary>
        /// sys_userController
        ///</summary>
        public AuthorizeController(AuthorizeService authorizeService, IAuthorizeRepository authorizeRepository)
        {
            _authorizeService = authorizeService;
            _uthorizeRepository = authorizeRepository;
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="token"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseMessage<UserAppPermission> Authorize(string token, string appId)
        {
            ResponseMessage<UserAppPermission> resp = new ResponseMessage<UserAppPermission>() { success = false, status = (int)ApiStatusEnum.Error };
            UserAppPermission result = null;
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    resp.data = null;
                    resp.msg = "token不能为空";
                }
                else
                {
                    TokenModel tm = JwtHelper.SerializeJWT(token);
                    UserDto userCache = MemoryCacheService.Default.GetCache<UserDto>(tm.Uid);
                    if (userCache != null && userCache.User != null)
                    {
                        result = new UserAppPermission();
                        result.User = userCache.User;
                        Permission p = null;
                        //查找与请求appId匹配的权限
                        if (userCache.Permissions != null && userCache.Permissions.Count > 0)
                        {
                            p = userCache.Permissions.Find(s => s.AppId == appId);
                        }
                        if (p != null)
                        {
                            result.Permission = p;
                        }
                    }
                    resp.success = true;
                    resp.status = (int)ApiStatusEnum.Status;
                    resp.data = result;
                }
            }
            catch 
            {
                resp.success = false;
                resp.status = (int)ApiStatusEnum.Error;
                resp.data = null;
                resp.msg = "验证失败";
            }
            return resp;
        }

    }
}

