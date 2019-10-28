﻿using DXYK.Admin.Common;
using DXYK.Admin.Common.Cache;
using DXYK.Admin.Common.ConfigHelper;
using DXYK.Admin.Common.EnumHelper;
using DXYK.Admin.Dto.Sys;
using DXYK.Admin.Extensions.JWT;
using DXYK.Admin.MVC.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DXYK.Admin.MVC.Models
{
    public class AuthFilter : IActionFilter
    {
        /// <summary>
        /// Stopwatch
        /// </summary>
        private Stopwatch Stopwatch { get; set; }

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
        /// 应用id
        /// </summary>
        private string AppId { get; set; }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var description = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            //添加有允许匿名的Action，可以不用登录访问，如Login/Index   [AllowAnonymous]
            var anonymous = description.MethodInfo.GetCustomAttribute(typeof(AllowAnonymousAttribute));
            if (anonymous != null)
            {
                return;
            }
            if (IsLog)
            {
                ActionArguments = JsonConvert.SerializeObject(context.HttpContext.Request.QueryString);
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
            }
            //获得权限
            //在缓存中 获得权限
            var cacheSaveType = ConfigExtensions.Configuration[AppSettingKeyHelper.LOGINAUTHORIZE];
            UserDto userDto = cacheSaveType == "Redis" ? RedisHelper.Get<UserDto>(jwtToken.Uid) : MemoryCacheService.Default.GetCache<UserDto>(jwtToken.Uid);
            if (userDto == null)
            {
                context.Result = new RedirectResult("/Login");
                return;
            }
            var Controllername = description.ControllerName.ToLower();
            var Actionname = description.ActionName.ToLower();


            //List<string> actions = ActionCode.Split(',').ToList();
            //if (userDto.Permissions != null && userDto.Permissions.Count > 0)
            //{
            //    Permission p = userDto.Permissions.Find(s => s.AppId == AppId);
            //    if (p == null)
            //    {
            //        ContextReturn(context, "您没有操作权限，请联系系统管理员！");
            //        return;
            //    }
            //    //判断是否有功能权限
            //    //DXYK.Admin.Dto.Sys.Action action = p.Action.Find(s => s.action_code == ActionCode);
            //    List<DXYK.Admin.Dto.Sys.Action> action = p.Action.Where(s => actions.Contains(s.action_code)).ToList();
            //    if (action == null || action.Count < 1)
            //    {
            //        ContextReturn(context, "您没有操作权限，请联系系统管理员！");
            //        return;
            //    }
            //    if (actions == null || actions.Count < 1)
            //    {
            //        ContextReturn(context, "您没有操作权限，请联系系统管理员！");
            //        return;
            //    }
            //    //有功能权限  继续执行
            //    return;
            //}
            //else
            //{
            //    ContextReturn(context, "您没有操作权限，请联系系统管理员！");
            //    return;
            //}
            return;
        }

        /// <summary>
        /// 返回API的信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="msg"></param>
        private static void ContextReturn(ActionExecutedContext context, string msg)
        {
            //var resp = new ResponseMessage<object>
            //{
            //    success = false,
            //    code = 1,
            //    status = (int)ApiStatusEnum.Unauthorized,
            //    msg = msg,
            //    data = null
            //};
            //var result = new JsonResult(resp);
            context.Result = new RedirectResult("Login");
        }

        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            return;
        }
    }
}
