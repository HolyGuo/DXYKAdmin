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
using DXYK.Admin.Entity.Dto;

namespace DXYK.Admin.API.Controllers
{
    ///<summary>
    /// 用户信息
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
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
            UserInfo user = _userService.LoginIn(reqLogin.loginname, reqLogin.password);
            var access_token = "";
            return new ResponseMessage<string> { code = user == null ? 1 : 0, msg = user == null ? "用户名或密码错误" : "登录成功", data = access_token };
        }

        ///<summary>
        /// 用户名、密码登录
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<string>> LoginInAsync([FromBody]UserLoginDto reqLogin)
        {
            UserInfo user = await _userService.LoginInAsync(reqLogin.loginname, reqLogin.password);
            var access_token = "";
            return new ResponseMessage<string> { data = access_token };
        }


    }
}

