﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DXYK.Admin.Common;
using DXYK.Admin.Common.Cache;
using DXYK.Admin.Common.ConfigHelper;
using DXYK.Admin.Common.EnumHelper;
using DXYK.Admin.Dto.Sys;
using DXYK.Admin.Extensions.JWT;
using DXYK.Admin.MVC.Messages;
using DXYK.Admin.MVC.Utils;
using DXYK.Admin.Repository;
using DXYK.Admin.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXYK.Admin.MVC.Controllers
{
    ///<summary>
    /// 用户信息
    ///</summary>
    //[ApiController]
    [Route("api/[controller]/[action]")]

    public class LoginController : Controller
    {
        /// <summary>
        /// 验证码在内存中默认保存Key  登录时使用
        /// </summary>
        //private readonly string _captchaCodeSessionNameFroLogin = "DXYKCaptchaCodeForLogin";
        ///<summary>
        /// 用户信息UserService
        ///</summary>
        public AuthorizeService _authorizeService { get; }

        ///<summary>
        /// 用户信息IUserRepository
        ///</summary>
        public IAuthorizeRepository _uthorizeRepository { get; }

        ///<summary>
        /// LoginController
        ///</summary>
        public LoginController(AuthorizeService authorizeService, IAuthorizeRepository authorizeRepository)
        {
            _authorizeService = authorizeService;
            _uthorizeRepository = authorizeRepository;
        }

        ///<summary>
        /// 用户名、密码登录、 验证码登录
        ///</summary>
        [AllowAnonymous]
        [HttpGet]
        public ResponseMessage<string> LoginIn([FromBody]UserLoginDto reqLogin)
        {
            //var access_token = "";
            ResponseMessage<string> resp = new ResponseMessage<string>() { success = false, status = (int)ApiStatusEnum.Error };

            return resp;
        }

        ///<summary>
        /// 用户名、密码登录
        ///</summary>
        [AllowAnonymous]
        [HttpPost]
        //[Route("api/Login/SignIn")]
        public ResponseMessage<string> SignIn([FromBody]UserSingInDto reqLogin)
        {
            var access_token = "";
            ResponseMessage<string> resp = new ResponseMessage<string>() { success = false, status = (int)ApiStatusEnum.Error };
            try
            {

                //获得公钥私钥，解密
                //var rsaKey = MemoryCacheService.Default.GetCache<List<string>>("LOGINKEY");
                //if (rsaKey == null)
                //{
                //    resp.msg = "登录失败，请刷新浏览器再次登录";
                //    return resp;
                //}
                ////Ras解密密码
                //var ras = new RSACrypt(rsaKey[0], rsaKey[1]);
                //reqLogin.password = ras.Decrypt(reqLogin.password);

                //获得用户登录限制次数
                var configLoginCount = Convert.ToInt32(ConfigExtensions.Configuration[AppSettingKeyHelper.LOGINCOUNT]);
                //获得登录次数和过期时间
                var loginConfig = MemoryCacheService.Default.GetCache<UserLoginConfigDto>(AppSettingKeyHelper.LOGINCOUNT) ?? new UserLoginConfigDto();
                if (loginConfig.Count != 0 && loginConfig.DelayMinute != null)
                {
                    //说明存在过期时间，需要判断
                    if (DateTime.Now <= loginConfig.DelayMinute)
                    {
                        resp.msg = "您的登录以超过设定次数，请稍后再次登录~";
                        return resp;
                    }
                    else
                    {
                        //已经过了登录的预设时间，重置登录配置参数
                        loginConfig.Count = 0;
                        loginConfig.DelayMinute = null;
                    }
                }
                //查询登录结果
                UserInfo user = _authorizeService.LoginIn(reqLogin.loginname);
                if (user == null)//用户名错误
                {
                    //增加登录次数
                    loginConfig.Count += 1;
                    //登录的次数大于配置的次数，则提示过期时间
                    if (loginConfig.Count == configLoginCount)
                    {
                        var configDelayMinute = Convert.ToInt32(ConfigExtensions.Configuration[AppSettingKeyHelper.LOGINDELAYMINUTE]);
                        //记录过期时间
                        loginConfig.DelayMinute = DateTime.Now.AddMinutes(configDelayMinute);
                        resp.msg = "登录次数超过" + configLoginCount + "次，请" + configDelayMinute + "分钟后再次登录";
                        return resp;
                    }
                    //记录登录次数，保存到session
                    MemoryCacheService.Default.SetCache(AppSettingKeyHelper.LOGINCOUNT, loginConfig);//Login:Count  用户登录-保存登录次数
                    //提示用户错误和登录次数信息
                    resp.msg = "用户名错误,您还剩余" + (configLoginCount - loginConfig.Count) + "登录次数";
                    return resp;
                }
                else
                {
                    if (!user.login_pwd.Equals(reqLogin.password))
                    {
                        //增加登录次数
                        loginConfig.Count += 1;
                        //登录的次数大于配置的次数，则提示过期时间
                        if (loginConfig.Count == configLoginCount)
                        {
                            var configDelayMinute = Convert.ToInt32(ConfigExtensions.Configuration[AppSettingKeyHelper.LOGINDELAYMINUTE]);
                            //记录过期时间
                            loginConfig.DelayMinute = DateTime.Now.AddMinutes(configDelayMinute);
                            resp.msg = "登录次数超过" + configLoginCount + "次，请" + configDelayMinute + "分钟后再次登录";
                            return resp;
                        }
                        //记录登录次数，保存到session
                        MemoryCacheService.Default.SetCache(AppSettingKeyHelper.LOGINCOUNT, loginConfig);//Login:Count  用户登录-保存登录次数
                        resp.msg = "密码错误，您还剩余" + (configLoginCount - loginConfig.Count) + "登录次数";
                        return resp;
                    }
                }
                var identity = new ClaimsPrincipal(
                 new ClaimsIdentity(new[]
                     {
                              new Claim(ClaimTypes.Sid,user.id.ToString()),
                              new Claim(ClaimTypes.Role,user.login_name.ToString()),
                              new Claim(ClaimTypes.Thumbprint,user.login_name),
                              new Claim(ClaimTypes.Name,user.true_name),
                              new Claim(ClaimTypes.WindowsAccountName,user.login_name),
                              new Claim(ClaimTypes.UserData,user.login_name.ToString())
                     }, CookieAuthenticationDefaults.AuthenticationScheme)
                );
                //如果保存用户类型是Session，则默认设置cookie退出浏览器 清空
                if (ConfigExtensions.Configuration[AppSettingKeyHelper.LOGINSAVEUSER] == "Session")
                {
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, identity, new AuthenticationProperties
                    {
                        AllowRefresh = false
                    });
                }
                else
                {
                    //根据配置保存浏览器用户信息，小时单位
                    var hours = int.Parse(ConfigExtensions.Configuration[AppSettingKeyHelper.LOGINCOOKIEEXPIRES]);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, identity, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddHours(hours),
                        IsPersistent = true,
                        AllowRefresh = false
                    });
                }
                //把权限存到缓存里
                var menuSaveType = ConfigExtensions.Configuration[AppSettingKeyHelper.LOGINAUTHORIZE];
                UserDto userDto = new UserDto();
                user.login_pwd = null;//不暴露密码，此处设置密码为null
                userDto.User = user;
                userDto.Permissions = _authorizeService.GetPermission(user.group_id, user.id);
                if (menuSaveType == "Redis")
                {
                    //RedisHelper.Set(reqLogin.appid + "_" + user.id, userDto);
                    RedisHelper.Set(user.id.ToString(), userDto);
                }
                else
                {
                    //保存权限
                    MemoryCacheService.Default.RemoveCache(user.id.ToString());//先移除之前的缓存
                    MemoryCacheService.Default.SetCache(user.id.ToString(), userDto, 600);//保存
                }
                access_token = JwtHelper.IssueJWT(new TokenModel()
                {
                    Uid = user.id.ToString(),
                    UserName = user.login_name,
                    //Role = string.IsNullOrEmpty(user.user_type) ? "user" : user.user_type,
                    TokenType = "Web",
                    //AppId = reqLogin.appid,
                    GroupId = user.group_id
                });
                MemoryCacheService.Default.RemoveCache("LOGINKEY");
                MemoryCacheService.Default.RemoveCache(AppSettingKeyHelper.LOGINCOUNT);
                #region 保存日志   暂未开发
                //var agent = HttpContext.Request.Headers["User-Agent"];
                //var log = new SysLog()
                //{
                //    Guid = Guid.NewGuid().ToString(),
                //    Logged = DateTime.Now,
                //    Logger = LogEnum.LOGIN.GetEnumText(),
                //    Level = "Info",
                //    Message = "登录",
                //    Callsite = "/fytadmin/login",
                //    IP = Utils.GetIp(),
                //    User = parm.loginname,
                //    Browser = agent.ToString()
                //};
                //_logService.AddAsync(log);
                #endregion
            }
            catch (Exception ex)
            {
                resp.status = (int)ApiStatusEnum.Error;
                resp.code = (int)ApiStatusEnum.Error;
                resp.msg = ex.Message;
                #region 保存日志   暂未开发
                //var agent = HttpContext.Request.Headers["User-Agent"];
                //var log = new SysLog()
                //{
                //    Guid = Guid.NewGuid().ToString(),
                //    Logged = DateTime.Now,
                //    Logger = LogEnum.LOGIN.GetEnumText(),
                //    Level = "Error",
                //    Message = "登录失败！" + ex.Message,
                //    Exception = ex.Message,
                //    Callsite = "/fytadmin/login",
                //    IP = Utils.GetIp(),
                //    User = parm.loginname,
                //    Browser = agent.ToString()
                //};
                //_logService.AddAsync(log);
                #endregion
            }
            Response.Cookies.Append("Cookies", access_token);
            Response.Cookies.Append("AppId", reqLogin.appid);
            resp.status = (int)ApiStatusEnum.Status;
            resp.code = 0;
            resp.success = true;
            resp.data = access_token;
            return resp;
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ResponseMessage<string> LogOut(string token)
        {
            ResponseMessage<string> resp = new ResponseMessage<string>() { success = false, status = (int)ApiStatusEnum.Error };
            try
            {
                TokenModel jwtToken = new TokenModel();
                jwtToken = JwtHelper.SerializeJWT(token);

                SignOut("Cookies");
                SignOut("AppId");
                MemoryCacheService.Default.RemoveCache(jwtToken.Uid);//先移除之前的缓存
                resp.code = 0;
                resp.status = (int)ApiStatusEnum.Status;
                resp.success = true;
                resp.data = "退出成功";
                resp.msg = "LogOut退出成功";
                return resp;
            }
            catch (Exception)
            {
                resp.data = null;
                resp.msg = "LogOut退出失败";
                return resp;
            }
        }


        /// <summary>
        /// 获取微信验证码
        /// </summary>
        /// <returns>二维码Guid</returns>
        [HttpGet]
        [AllowAnonymous]
        public ResponseMessage<string> GetWeChatCode()
        {
            ResponseMessage<string> resp = new ResponseMessage<string>() { success = false, status = (int)ApiStatusEnum.Error };
            try
            {
                resp.success = true;
                resp.data = Guid.NewGuid().ToString();
                resp.msg = "二维码返回成功";
                resp.status = (int)ApiStatusEnum.Status;
                return resp;
            }
            catch (Exception)
            {
                resp.data = null;
                resp.msg = "二维码返回失败";
                return resp;
            }
        }

        /// <summary>
        /// 验证码图片
        /// </summary>
        /// <param name="key">保存在缓存中对应的key</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public object GetCaptchaImage(string key)
        {
            string captchaCode = CaptchaHelper.GenerateCaptchaCode();
            var result = CaptchaHelper.GetImage(116, 36, captchaCode);
            MemoryCacheService.Default.SetCache(key, captchaCode, 5);
            return new FileStreamResult(new MemoryStream(result.CaptchaByteData), "image/png");
        }

        /// <summary>
        /// 验证码 验证
        /// </summary>
        /// <param name="userInputCaptcha">验证码内容</param>
        /// <param name="key">保存在缓存中对应的key</param>
        /// <returns></returns>
        private bool ValidateCaptchaCode(string userInputCaptcha, string key)
        {
            string old = MemoryCacheService.Default.GetCache<string>(key);
            var isValid = userInputCaptcha.Equals(old, StringComparison.OrdinalIgnoreCase);
            MemoryCacheService.Default.RemoveCache(key);
            return isValid;
        }


    }
}
