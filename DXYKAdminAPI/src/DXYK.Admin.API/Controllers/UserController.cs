//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using DXYK.Admin.API.Messages;
using DXYK.Admin.API.Utils;
using DXYK.Admin.Common;
using DXYK.Admin.Common.Cache;
using DXYK.Admin.Common.ConfigHelper;
using DXYK.Admin.Entity.Dto;
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
    public class UserController : Controller
    {
        private readonly string CaptchaCodeSessionName = "DXYKCaptchaCode";
        ///<summary>
        /// 用户信息UserService
        ///</summary>
        public UserService _userService { get; }

        ///<summary>
        /// 用户信息IUserRepository
        ///</summary>
        public IUserRepository _userRepository { get; }

        ///<summary>
        /// sys_userController
        ///</summary>
        public UserController(UserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        ///<summary>
        /// 用户名、密码登录
        ///</summary>
        [HttpPost]
        public ResponseMessage<string> LoginIn([FromBody]UserLoginDto reqLogin)
        {
            var access_token = "";
            ResponseMessage<string> resp = new ResponseMessage<string>() { success = false, status = (int)ApiStatusEnum.Error };
            try
            {
                if (!ValidateCaptchaCode(reqLogin.vercode))
                {
                    //MemoryCacheService.Default.RemoveCache(CaptchaCodeSessionName);
                    resp.msg = "验证码输入错误";
                    return resp;
                }

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
                UserInfo user = _userService.LoginIn(reqLogin.loginname);
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
                List<MenuDto> menu = new List<MenuDto>() { new MenuDto() { title = "title" } };
                if (menuSaveType == "Redis")
                {
                    RedisHelper.Set(AppSettingKeyHelper.ADMINMENU + "_" + user.id, menu);
                    //RedisHelper.Set(AppSettingKeyHelper.NOWSITE, site);
                }
                else
                {
                    //MemoryCacheService.Default.SetCache(AppSettingKeyHelper.NOWSITE, site);
                    MemoryCacheService.Default.SetCache(AppSettingKeyHelper.ADMINMENU + "_" + user.id, menu, 600);
                }
                access_token = JwtHelper.IssueJWT(new TokenModel()
                {
                    Uid = user.id.ToString(),
                    UserName = user.login_name,
                    Role = "Admin",
                    TokenType = "Web"
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
            resp.status = (int)ApiStatusEnum.Status;
            resp.success = true;
            resp.data = access_token;
            return resp;
        }

        ///<summary>
        /// 用户名、密码登录
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<string>> LoginInAsync([FromBody]UserLoginDto reqLogin)
        {
            UserInfo user = await _userService.LoginInAsync(reqLogin.loginname);
            var access_token = "";
            return new ResponseMessage<string> { data = access_token };
        }

        /// <summary>
        /// 验证码图片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCaptchaImage()
        {
            string captchaCode = CaptchaHelper.GenerateCaptchaCode();
            var result = CaptchaHelper.GetImage(116, 36, captchaCode);
            MemoryCacheService.Default.SetCache(CaptchaCodeSessionName, captchaCode, 5);
            return new FileStreamResult(new MemoryStream(result.CaptchaByteData), "image/png");
        }

        private bool ValidateCaptchaCode(string userInputCaptcha)
        {
            string old = MemoryCacheService.Default.GetCache<string>(CaptchaCodeSessionName);
            var isValid = userInputCaptcha.Equals(old, StringComparison.OrdinalIgnoreCase);
            MemoryCacheService.Default.RemoveCache(CaptchaCodeSessionName);
            return isValid;
        }


    }
}

