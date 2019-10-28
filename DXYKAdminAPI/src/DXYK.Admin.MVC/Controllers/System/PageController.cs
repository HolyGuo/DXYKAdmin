using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DXYK.Admin.MVC.Controllers.System
{
    /// <summary>
    /// 系统管理页面控制（跳转）
    /// </summary>
    public class PageController : Controller
    {
        /// <summary>
        /// 用户管理页面
        /// </summary>
        /// <returns></returns>
        [Route("System/User")]
        public new IActionResult User()
        {
            return View("~/Views/System/User/Index.cshtml");
        }

        /// <summary>
        /// 用户管理页面
        /// </summary>
        /// <returns></returns>
        [Route("System/UserAdd")]
        public IActionResult UserAdd()
        {
            return View("~/Views/System/User/Form.cshtml");
        }
    }
}
