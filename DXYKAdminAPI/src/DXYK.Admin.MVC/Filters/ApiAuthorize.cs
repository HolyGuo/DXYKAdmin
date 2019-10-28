using DXYK.Admin.Common;
using DXYK.Admin.Common.Cache;
using DXYK.Admin.Common.ConfigHelper;
using DXYK.Admin.Common.EnumHelper;
using DXYK.Admin.Dto.Sys;
using DXYK.Admin.Extensions.JWT;
using DXYK.Admin.MVC.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DXYK.Admin.MVC.Filters
{
    /// <summary>
    /// Api鉴权
    /// </summary>
    public class ApiAuthorize : ActionFilterAttribute
    {
        #region 字段和属性
        /// <summary>
        /// 模块别名，可配置更改
        /// </summary>
        public string Modules { get; set; }

        /// <summary>
        /// Action编码
        /// </summary>
        public string ActionCode { get; set; }

        /// <summary>
        /// 权限访问控制器参数
        /// </summary>
        private string Sign { get; set; }

        /// <summary>
        /// 是否保存日志
        /// </summary>
        public bool IsLog { get; set; } = true;

        /// <summary>
        /// 操作类型CRUD
        /// </summary>
        public LogEnum LogType { get; set; }

        /// <summary>
        /// ActionArguments
        /// </summary>
        private string ActionArguments { get; set; }

        /// <summary>
        /// Stopwatch
        /// </summary>
        private Stopwatch Stopwatch { get; set; }

        /// <summary>
        /// 应用id
        /// </summary>
        private string AppId { get; set; }


        #endregion
        /// <summary>
        ///OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (IsLog)
            {
                ActionArguments = JsonConvert.SerializeObject(context.ActionArguments);
                Stopwatch = new Stopwatch();
                Stopwatch.Start();
            }
            TokenModel jwtToken = new TokenModel();
            var getCookie = "";
            context.HttpContext.Request.Cookies.TryGetValue("Cookies", out getCookie);
            //检测是否包含'Authorization'请求头，如果不包含则直接放行
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                var tokenHeader = context.HttpContext.Request.Headers["Authorization"];
                //tokenHeader = tokenHeader.ToString().Substring("Bearer ".Length).Trim();
                jwtToken = JwtHelper.SerializeJWT(tokenHeader);
            }
            else if (!string.IsNullOrWhiteSpace(getCookie))
            {
                jwtToken = JwtHelper.SerializeJWT(getCookie);
            }
            else if (!string.IsNullOrEmpty(context.HttpContext.Request.Query["Authorization"]))
            {
                var token = context.HttpContext.Request.Query["Authorization"];
                jwtToken = JwtHelper.SerializeJWT(token);
            }
            else
            {
                ContextReturn(context, "未验证请求！");
                return;
            }
            //根据AppId验证当前应用
            var getAppId = "";
            context.HttpContext.Request.Cookies.TryGetValue("AppId", out getAppId);
            if (context.HttpContext.Request.Headers.ContainsKey("AppId"))
            {
                AppId = context.HttpContext.Request.Headers["AppId"];
            }
            else if (!string.IsNullOrWhiteSpace(getAppId))
            {
                AppId = getAppId;
            }
            else
            {
                ContextReturn(context, "AppId丢失！");
                return;
            }
            //获得权限
            //在缓存中 获得权限
            var cacheSaveType = ConfigExtensions.Configuration[AppSettingKeyHelper.LOGINAUTHORIZE];
            UserDto userDto = cacheSaveType == "Redis" ? RedisHelper.Get<UserDto>(jwtToken.Uid) : MemoryCacheService.Default.GetCache<UserDto>(jwtToken.Uid);
            if (userDto == null)
            {
                ContextReturn(context, "登录已过期，请退出重新登录！");
                return;
            }
            List<string> actions = ActionCode.Split(',').ToList();
            if (userDto.Permissions != null && userDto.Permissions.Count > 0)
            {
                Permission p = userDto.Permissions.Find(s => s.AppId == AppId);
                if (p == null)
                {
                    ContextReturn(context, "您没有操作权限，请联系系统管理员！");
                    return;
                }
                //判断是否有功能权限
                //DXYK.Admin.Dto.Sys.Action action = p.Action.Find(s => s.action_code == ActionCode);
                List<DXYK.Admin.Dto.Sys.Action> action = p.Action.Where(s=> actions.Contains(s.action_code)).ToList();
                if (action == null || action.Count < 1)
                {
                    ContextReturn(context, "您没有操作权限，请联系系统管理员！");
                    return;
                }
                if (actions == null || actions.Count < 1)
                {
                    ContextReturn(context, "您没有操作权限，请联系系统管理员！");
                    return;
                }
                //有功能权限  继续执行
                base.OnActionExecuting(context);
                return;
            }
            else
            {
                ContextReturn(context, "您没有操作权限，请联系系统管理员！");
                return;
            }
        }

        /// <summary>
        /// 返回API的信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="msg"></param>
        private static void ContextReturn(ActionExecutingContext context, string msg)
        {
            var resp = new ResponseMessage<object>
            {
                success = false,
                code = 1,
                status = (int)ApiStatusEnum.Unauthorized,
                msg = msg,
                data = null
            };
            var result = new JsonResult(resp);
            context.Result = result;
        }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            if (!IsLog) return;
            Stopwatch.Stop();

            var url = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
            var method = context.HttpContext.Request.Method;

            var qs = ActionArguments;

            var user = "";
            //检测是否包含'Authorization'请求头，如果不包含则直接放行
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                var tokenHeader = context.HttpContext.Request.Headers["Authorization"];
                //tokenHeader = tokenHeader.ToString().Substring("Bearer ".Length).Trim();

                var tm = JwtHelper.SerializeJWT(tokenHeader);
                user = tm.UserName;
            }

            //var str = $"\n 方法：{Modules}：{Methods} \n " +
            //          $"地址：{url} \n " +
            //          $"方式：{method} \n " +
            //          $"参数：{qs}\n " +
            //          //$"结果：{res}\n " +
            //          $"耗时：{Stopwatch.Elapsed.TotalMilliseconds} 毫秒";
            //Logger.Default.Process(user, LogType.GetEnumText(), str);
        }

    }
}
