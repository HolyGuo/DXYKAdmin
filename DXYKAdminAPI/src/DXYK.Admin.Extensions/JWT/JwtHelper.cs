using DXYK.Admin.Extensions.JWT.Config;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DXYK.Admin.Extensions.JWT
{
    public class JwtHelper
    {
        /// <summary>
        /// 颁发JWT字符串 /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        public static string IssueJWT(TokenModel tokenModel)
        {
            var jwtConfig = new JwtAuthConfigModel();
            //过期时间（分钟）
            double exp = 0;
            switch (tokenModel.TokenType)
            {
                case "Web":
                    exp = jwtConfig.WebExp;
                    break;
                case "App":
                    exp = jwtConfig.AppExp;
                    break;
                case "Wx":
                    exp = jwtConfig.WxExp;
                    break;
                case "Other":
                    exp = jwtConfig.OtherExp;
                    break;
            }
            var dateTime = DateTime.UtcNow;
            var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, tokenModel.Uid),
                    new Claim("UserName", tokenModel.UserName.ToString()),//用户名
                    //new Claim("AppId", tokenModel.AppId.ToString()),//应用id
                    //new Claim("AppName", tokenModel.AppName.ToString()),//应用名称
                    //new Claim("TokenType", tokenModel.TokenType.ToString()),//TokenType
                    //new Claim("Role", tokenModel.Role.ToString()),//角色
                    new Claim(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                    new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") , 
                    //这个就是过期时间，目前是过期100秒，可自定义，注意JWT有自己的缓冲过期时间
                    new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddMinutes(exp)).ToUnixTimeSeconds()}"),
                    new Claim(JwtRegisteredClaimNames.Iss,jwtConfig.Issuer),
                    new Claim(JwtRegisteredClaimNames.Aud,jwtConfig.Audience),
                    //new Claim(ClaimTypes.Role,tokenModel.Role),
                    new Claim("GroupId", tokenModel.GroupId),//群组id
               };
            //秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.JWTSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: jwtConfig.Issuer,
                audience: jwtConfig.Audience,
                claims: claims,
                expires: dateTime.AddMinutes(exp),
                signingCredentials: creds);
            var jwtHandler = new JwtSecurityTokenHandler();
            var encodedJwt = jwtHandler.WriteToken(jwt);
            return encodedJwt;
        }


        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static TokenModel SerializeJWT(string jwtStr)
        {
            if (string.IsNullOrWhiteSpace(jwtStr))
            {
                return null;
            }
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);

            object userName = new object();
            //object appId = new object();
            //object appName = new object();
            //object role = new object();
            //object tokenType = new object();
            object groupId = new object();
            try
            {
                jwtToken.Payload.TryGetValue("UserName", out userName);
                //jwtToken.Payload.TryGetValue("AppId", out appId);
                //jwtToken.Payload.TryGetValue("AppName", out appName);
                //jwtToken.Payload.TryGetValue("Role", out role);
                //jwtToken.Payload.TryGetValue("TokenType", out tokenType); 
                jwtToken.Payload.TryGetValue("GroupId", out groupId);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            var tm = new TokenModel
            {
                Uid = jwtToken.Id,
                UserName = userName.ToString(),
                //AppId = appId.ToString(),
                //AppName = appName.ToString(),
                //TokenType = tokenType.ToString()
                //Role = role.ToString()
                GroupId = groupId.ToString()

            };
            return tm;
        }
    }
    /// <summary>
    /// 令牌
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 群组id
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// tokenType
        /// </summary>
        public string TokenType { get; set; }
    }
}
