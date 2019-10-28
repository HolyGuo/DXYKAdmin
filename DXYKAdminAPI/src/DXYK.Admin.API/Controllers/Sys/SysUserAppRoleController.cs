//*******************************
// Create By Holy Guo
// Date 2019-10-06 17:28
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
    /// 用户应用角色授权表
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysUserAppRoleController : Controller
    {
        ///<summary>
        /// 用户应用角色授权表(sys_user_app_role) Service
        ///</summary>
        public SysUserAppRoleService _sysUserAppRoleService { get; }

        ///<summary>
        /// 用户应用角色授权表(sys_user_app_role) Repository
        ///</summary>
        public ISysUserAppRoleRepository _sysUserAppRoleRepository { get; }

        ///<summary>
        /// sys_user_app_roleController
        ///</summary>
        public SysUserAppRoleController(SysUserAppRoleService sysUserAppRoleService, ISysUserAppRoleRepository sysUserAppRoleRepository)
        {
            _sysUserAppRoleService = sysUserAppRoleService;
            _sysUserAppRoleRepository = sysUserAppRoleRepository;
        }

        ///<summary>
        /// 新增用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpPost]
        public ResponseMessage<string> Insert([FromBody]SysUserAppRole sysUserAppRole)
        {
            return new ResponseMessage<string> { data = _sysUserAppRoleService.Insert(sysUserAppRole) };
        }

        ///<summary>
        /// 异步新增用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<string>> InsertAsync([FromBody]SysUserAppRole sysUserAppRole)
        {
            return new ResponseMessage<string> { data = await _sysUserAppRoleService.InsertAsync(sysUserAppRole) };
        }

        ///<summary>
        /// 删除用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(string id)
        {
            return new ResponseMessage<int> { data = _sysUserAppRoleService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(string id)
        {
            return new ResponseMessage<int> { data = await _sysUserAppRoleService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysUserAppRole sysUserAppRole)
        {
            return new ResponseMessage<int> { data = _sysUserAppRoleService.Update(sysUserAppRole) };
        }

        ///<summary>
        /// 异步更新用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysUserAppRole sysUserAppRole)
        {
            //SysUserAppRole entity = await _sysUserAppRoleService.GetByIdAsync(sysUserAppRole.id);
            //Utils.CommmonUtils.EntityToEntity(sysUserAppRole, entity, null);
            //return new ResponseMessage<int> { data = await _sysUserAppRoleService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysUserAppRoleService.UpdateAsync(sysUserAppRole) };
        }

        ///<summary>
        /// 根据Id查询用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysUserAppRole> GetById(string id)
        {
            var sysUserAppRole = _sysUserAppRoleService.GetById(id);
            return new ResponseMessage<SysUserAppRole> { data = sysUserAppRole };
        }

        ///<summary>
        /// 根据Id查询用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysUserAppRole>> GetByIdAsync(string id)
        {
            var sysUserAppRole = await _sysUserAppRoleService.GetByIdAsync(id);
            return new ResponseMessage<SysUserAppRole> { data = sysUserAppRole };
        }

        ///<summary>
        /// 根据条件查询用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysUserAppRole>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysUserAppRoleRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysUserAppRole>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysUserAppRole>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list = await _sysUserAppRoleRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysUserAppRole>> { data = list };
        }

        ///<summary>
        /// 根据分页查询用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysUserAppRole>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {

            var total = _sysUserAppRoleRepository.GetRecord(reqMsg);
            var list = _sysUserAppRoleRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysUserAppRole>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysUserAppRole>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysUserAppRoleRepository.GetRecordAsync(reqMsg);
            var list = await _sysUserAppRoleRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysUserAppRole>>() { count = total, data = list };
        }

        ///<summary>
        /// 根据分页查询用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysUserAppRoleService.QueryDataRecord(reqMsg);
            var list = _sysUserAppRoleService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询用户应用角色授权表(sys_user_app_role)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysUserAppRoleService.QueryDataRecordAsync(reqMsg);
            var list = await _sysUserAppRoleService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }
    }
}

