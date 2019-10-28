using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DXYK.Admin.MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace DXYK.Admin.MVC.Controllers
{
    //[Route("[controller]/[action]")]//特性配置路由
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View("~/Views/Index.cshtml");
        }
        [Route("Console")]
        public IActionResult Console()
        {

            return View();
        }
        [Route("HomePage1")]
        public IActionResult HomePage1()
        {
            return View();
        }
        [Route("HomePage2")]
        public IActionResult HomePage2()
        {
            return View();
        }
        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        [Route("Reg")]
        [AllowAnonymous]
        public IActionResult Reg()
        {
            return View("~/Views/Reg.cshtml");
        }
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("~/Views/Login.cshtml");
        }
        /// <summary>
        /// 忘记密码页面
        /// </summary>
        /// <returns></returns>
        [Route("Forget")]
        [AllowAnonymous]
        public IActionResult Forget()
        {
            return View("~/Views/Forget.cshtml");
        }

    }
}
