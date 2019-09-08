//*******************************
// Create By Holy Guo
// Date 2019-09-08 14:52
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
    public class SysUserController : Controller
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
        public SysUserController(SysUserService sysUserService, ISysUserRepository sysUserRepository)
        {
            SysUserService = sysUserService;
            SysUserRepository = sysUserRepository;
        }

        ///<summary>
        /// 新增系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysUser sysUser)
        {
            return new ResponseMessage<long> { data = SysUserService.Insert(sysUser) };
        }

        ///<summary>
        /// 异步新增系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>> InsertAsync([FromBody]SysUser sysUser)
        {
            return new ResponseMessage<long> { data = await SysUserService.InsertAsync(sysUser) };
        }

        ///<summary>
        /// 删除系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data = SysUserService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await SysUserService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysUser sysUser)
        {
            //SysUser entity = SysUserService.GetById(sysUser.id);
            //Utils.CommmonUtils.EntityToEntity(sysUser, entity, null);
            //return new ResponseMessage<int>{ data = SysUserService.Update(entity) };
            return new ResponseMessage<int> { data = SysUserService.Update(sysUser) };
        }

        ///<summary>
        /// 异步更新系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysUser sysUser)
        {
            //SysUser entity = await SysUserService.GetByIdAsync(sysUser.id);
            //Utils.CommmonUtils.EntityToEntity(sysUser, entity, null);
            //return new ResponseMessage<int>{ data = await SysUserService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await SysUserService.UpdateAsync(sysUser) };
        }

        ///<summary>
        /// 根据Id查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysUser> GetById(long id)
        {
            var sysUser = SysUserService.GetById(id);
            return new ResponseMessage<SysUser> { data = sysUser };
        }

        ///<summary>
        /// 根据Id查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysUser>> GetByIdAsync(long id)
        {
            var sysUser = await SysUserService.GetByIdAsync(id);
            return new ResponseMessage<SysUser> { data = sysUser };
        }

        ///<summary>
        /// 根据条件查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysUser>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = SysUserRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysUser>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysUser>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list = await SysUserRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysUser>> { data = list };
        }

        ///<summary>
        /// 根据分页查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysUser>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = SysUserRepository.GetRecord(reqMsg);
            var list = SysUserRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysUser>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysUser>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await SysUserRepository.GetRecordAsync(reqMsg);
            var list = await SysUserRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysUser>>() { count = total, data = list };
        }

        ///<summary>
        /// 根据分页查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = SysUserService.QueryDataRecord(reqMsg);
            var list = SysUserService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await SysUserService.QueryDataRecordAsync(reqMsg);
            var list = await SysUserService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

