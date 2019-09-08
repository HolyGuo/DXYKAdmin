//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DXYK.Admin.Entity;
using DXYK.Admin.Repository;
using DXYK.Admin.Service;
using DXYK.Admin.API.Messages;
using System.Threading.Tasks;

namespace DXYK.Admin.API.Controllers
{
    ///<summary>
    /// 系统管理-用户信息表
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        ///<summary>
        /// 系统管理-用户信息表(sys_user) Service
        ///</summary>
        public SysUserService SysUserService { get; }

        ///<summary>
        /// 系统管理-用户信息表(sys_user) Repository
        ///</summary>
        public ISysUserRepository SysUserRepository { get; }

        ///<summary>
        /// sys_userController
        ///</summary>
        public LoginController(SysUserService sysUserService, ISysUserRepository sysUserRepository)
        {
            SysUserService = sysUserService;
            SysUserRepository = sysUserRepository;
        }


        ///<summary>
        /// 根据分页查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = SysUserRepository.QueryDataRecord(reqMsg);
            var list = SysUserRepository.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await SysUserRepository.QueryDataRecordAsync(reqMsg);
            var list = await SysUserRepository.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

