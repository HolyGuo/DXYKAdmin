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
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        public static UserInfo GetUser(HttpContext context)
        {
            UserInfo user = new UserInfo();
            TokenModel jwtToken = new TokenModel();
            //检测是否包含'Authorization'请求头，如果不包含则直接放行
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var tokenHeader = context.Request.Headers["Authorization"];
                //tokenHeader = tokenHeader.ToString().Substring("Bearer ".Length).Trim();
                var tm = JwtHelper.SerializeJWT(tokenHeader);
                user.id = Convert.ToInt64(tm.Uid);
                user.true_name = tm.UserName;
            }
            return user;
        }
    }
}
