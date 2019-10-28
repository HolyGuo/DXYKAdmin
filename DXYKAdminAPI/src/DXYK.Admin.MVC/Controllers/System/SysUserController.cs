using DXYK.Admin.Common.EnumHelper;
using DXYK.Admin.Dto.Sys;
using DXYK.Admin.Entity;
using DXYK.Admin.MVC.Filters;
using DXYK.Admin.MVC.Messages;
using DXYK.Admin.MVC.Utils;
using DXYK.Admin.Repository;
using DXYK.Admin.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXYK.Admin.MVC.Controllers.System
{
    [Route("api/[controller]/[action]")]
    public class SysUserController : Controller
    {
        ///<summary>
        /// 用户信息表(sys_user) Service
        ///</summary>
        public SysUserService _sysUserService { get; }

        ///<summary>
        /// 用户信息表(sys_user) Repository
        ///</summary>
        public ISysUserRepository _sysUserRepository { get; }

        ///<summary>
        /// sys_userController
        ///</summary>
        public SysUserController(SysUserService sysUserService, ISysUserRepository sysUserRepository)
        {
            _sysUserService = sysUserService;
            _sysUserRepository = sysUserRepository;
        }


        ///<summary>
        /// 新增用户信息表(sys_user)
        ///</summary>
        [HttpPost, ApiAuthorize(ActionCode = "Admin,User_Manage,User_Add", LogType = LogEnum.ADD)]
        public ResponseMessage<string> Insert([FromBody]SysUser sysUser)
        {
            UserInfo user = GetCurrentUser.GetUserInfo(Request.HttpContext);
            sysUser.created_by = user.id;
            sysUser.created_time = DateTime.Now;
            return new ResponseMessage<string> { data = _sysUserService.Insert(sysUser) };
        }

        ///<summary>
        /// 删除用户信息表(sys_user)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data = _sysUserService.DeleteById(id) };
        }

        ///<summary>
        /// 更新用户信息表(sys_user)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysUser sysUser)
        {
            return new ResponseMessage<int> { data = _sysUserService.Update(sysUser) };
        }

        ///<summary>
        /// 根据Id查询用户信息表(sys_user)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysUser> GetById(long id)
        {
            var sysUser = _sysUserService.GetById(id);
            return new ResponseMessage<SysUser> { data = sysUser };
        }

        ///<summary>
        /// 根据分页查询用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysUserService.QueryDataRecord(reqMsg);
            var list = _sysUserService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

    }
}
