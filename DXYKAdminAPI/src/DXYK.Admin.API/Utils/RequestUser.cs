using DXYK.Admin.Common.Cache;
using DXYK.Admin.Dto.Sys;
using DXYK.Admin.Extensions.JWT;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXYK.Admin.API.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCurrentUser
    {
        /// <summary>
        /// 获取当前用户信息(包括权限)
        /// </summary>
        /// <returns></returns>
        public static UserDto GetUserDto(HttpContext context)
        {
            UserDto user = new UserDto();
            TokenModel jwtToken = new TokenModel();
            string appId = string.Empty;
            string userId = string.Empty;
            //检测是否包含'Authorization'请求头，如果不包含则直接放行
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var tokenHeader = context.Request.Headers["Authorization"];
                tokenHeader = tokenHeader.ToString().Substring("Bearer ".Length).Trim();
                var tm = JwtHelper.SerializeJWT(tokenHeader);
                //user.User.id = Convert.ToInt64(tm.Uid);
                //user.User.true_name = tm.UserName;
                //appId = tm.AppId;
                userId = tm.Uid;
            }
            else
            {

            }
            user = MemoryCacheService.Default.GetCache<UserDto>(userId);
            return user;
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        public static UserInfo GetUserInfo(HttpContext context)
        {
            UserDto user = new UserDto();
            TokenModel jwtToken = new TokenModel();
            //string appId = string.Empty;
            string userId = string.Empty;
            //检测是否包含'Authorization'请求头，如果不包含则直接放行
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var tokenHeader = context.Request.Headers["Authorization"];
                tokenHeader = tokenHeader.ToString().Substring("Bearer ".Length).Trim();
                var tm = JwtHelper.SerializeJWT(tokenHeader);
                //appId = tm.AppId;
                userId = tm.Uid;
            }
            else
            {

            }
            UserInfo info = new UserInfo();
            user = MemoryCacheService.Default.GetCache<UserDto>(userId);
            info = user.User;
            return info;
        }
    }

}
