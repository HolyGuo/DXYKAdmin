//*******************************
// Create By Holy Guo
// Date 2019-09-12 18:29
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
        /// 角色信息表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysAppRoleController : Controller
    {
        ///<summary>
        /// 角色信息表(sys_app_role) Service
        ///</summary>
        public SysAppRoleService _sysAppRoleService { get; }

        ///<summary>
        /// 角色信息表(sys_app_role) Repository
        ///</summary>
        public ISysAppRoleRepository _sysAppRoleRepository { get; }

        ///<summary>
        /// sys_app_roleController
        ///</summary>
        public SysAppRoleController(SysAppRoleService sysAppRoleService, ISysAppRoleRepository sysAppRoleRepository)
        {
            _sysAppRoleService = sysAppRoleService;
            _sysAppRoleRepository = sysAppRoleRepository;
        }

        ///<summary>
        /// 新增角色信息表(sys_app_role)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysAppRole sysAppRole)
        {
            return new ResponseMessage<long> { data = _sysAppRoleService.Insert(sysAppRole) }; 
        }

        ///<summary>
        /// 异步新增角色信息表(sys_app_role)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>>InsertAsync([FromBody]SysAppRole sysAppRole)
        {
            return new ResponseMessage<long> { data = await _sysAppRoleService.InsertAsync(sysAppRole) };
        }

        ///<summary>
        /// 删除角色信息表(sys_app_role)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data =  _sysAppRoleService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除角色信息表(sys_app_role)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await _sysAppRoleService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新角色信息表(sys_app_role)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysAppRole sysAppRole)
        {
            return new ResponseMessage<int> { data = _sysAppRoleService.Update(sysAppRole) };
        }

        ///<summary>
        /// 异步更新角色信息表(sys_app_role)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysAppRole sysAppRole)
        {
            //SysAppRole entity = await _sysAppRoleService.GetByIdAsync(sysAppRole.id);
            //Utils.CommmonUtils.EntityToEntity(sysAppRole, entity, null);
            //return new ResponseMessage<int> { data = await _sysAppRoleService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysAppRoleService.UpdateAsync(sysAppRole) };
        }

        ///<summary>
        /// 根据Id查询角色信息表(sys_app_role)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysAppRole> GetById(long id)
        {
            var sysAppRole = _sysAppRoleService.GetById(id);
            return new ResponseMessage<SysAppRole> {  data = sysAppRole };
        }

        ///<summary>
        /// 根据Id查询角色信息表(sys_app_role)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysAppRole>> GetByIdAsync(long id)
        {
            var sysAppRole =await _sysAppRoleService.GetByIdAsync(id);
            return new ResponseMessage<SysAppRole>{ data = sysAppRole};
        }

        ///<summary>
        /// 根据条件查询角色信息表(sys_app_role)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysAppRole>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysAppRoleRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysAppRole>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询角色信息表(sys_app_role)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysAppRole>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _sysAppRoleRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysAppRole>> { data = list };
        }

        ///<summary>
        /// 根据分页查询角色信息表(sys_app_role)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysAppRole>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _sysAppRoleRepository.GetRecord(reqMsg);
            var list = _sysAppRoleRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysAppRole>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询角色信息表(sys_app_role)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysAppRole>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _sysAppRoleRepository.GetRecordAsync(reqMsg);
            var list =await _sysAppRoleRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysAppRole>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询角色信息表(sys_app_role)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysAppRoleService.QueryDataRecord(reqMsg);
            var list = _sysAppRoleService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询角色信息表(sys_app_role)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppRoleService.QueryDataRecordAsync(reqMsg);
            var list = await _sysAppRoleService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

