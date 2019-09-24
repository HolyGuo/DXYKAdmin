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
        /// 角色授权功能表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysAppRoleMenuActionController : Controller
    {
        ///<summary>
        /// 角色授权功能表(sys_app_role_menu_action) Service
        ///</summary>
        public SysAppRoleMenuActionService _sysAppRoleMenuActionService { get; }

        ///<summary>
        /// 角色授权功能表(sys_app_role_menu_action) Repository
        ///</summary>
        public ISysAppRoleMenuActionRepository _sysAppRoleMenuActionRepository { get; }

        ///<summary>
        /// sys_app_role_menu_actionController
        ///</summary>
        public SysAppRoleMenuActionController(SysAppRoleMenuActionService sysAppRoleMenuActionService, ISysAppRoleMenuActionRepository sysAppRoleMenuActionRepository)
        {
            _sysAppRoleMenuActionService = sysAppRoleMenuActionService;
            _sysAppRoleMenuActionRepository = sysAppRoleMenuActionRepository;
        }

        ///<summary>
        /// 新增角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysAppRoleMenuAction sysAppRoleMenuAction)
        {
            return new ResponseMessage<long> { data = _sysAppRoleMenuActionService.Insert(sysAppRoleMenuAction) }; 
        }

        ///<summary>
        /// 异步新增角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>>InsertAsync([FromBody]SysAppRoleMenuAction sysAppRoleMenuAction)
        {
            return new ResponseMessage<long> { data = await _sysAppRoleMenuActionService.InsertAsync(sysAppRoleMenuAction) };
        }

        ///<summary>
        /// 删除角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data =  _sysAppRoleMenuActionService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await _sysAppRoleMenuActionService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysAppRoleMenuAction sysAppRoleMenuAction)
        {
            return new ResponseMessage<int> { data = _sysAppRoleMenuActionService.Update(sysAppRoleMenuAction) };
        }

        ///<summary>
        /// 异步更新角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysAppRoleMenuAction sysAppRoleMenuAction)
        {
            //SysAppRoleMenuAction entity = await _sysAppRoleMenuActionService.GetByIdAsync(sysAppRoleMenuAction.id);
            //Utils.CommmonUtils.EntityToEntity(sysAppRoleMenuAction, entity, null);
            //return new ResponseMessage<int> { data = await _sysAppRoleMenuActionService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysAppRoleMenuActionService.UpdateAsync(sysAppRoleMenuAction) };
        }

        ///<summary>
        /// 根据Id查询角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysAppRoleMenuAction> GetById(long id)
        {
            var sysAppRoleMenuAction = _sysAppRoleMenuActionService.GetById(id);
            return new ResponseMessage<SysAppRoleMenuAction> {  data = sysAppRoleMenuAction };
        }

        ///<summary>
        /// 根据Id查询角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysAppRoleMenuAction>> GetByIdAsync(long id)
        {
            var sysAppRoleMenuAction =await _sysAppRoleMenuActionService.GetByIdAsync(id);
            return new ResponseMessage<SysAppRoleMenuAction>{ data = sysAppRoleMenuAction};
        }

        ///<summary>
        /// 根据条件查询角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysAppRoleMenuAction>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysAppRoleMenuActionRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysAppRoleMenuAction>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysAppRoleMenuAction>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _sysAppRoleMenuActionRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysAppRoleMenuAction>> { data = list };
        }

        ///<summary>
        /// 根据分页查询角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysAppRoleMenuAction>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _sysAppRoleMenuActionRepository.GetRecord(reqMsg);
            var list = _sysAppRoleMenuActionRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysAppRoleMenuAction>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysAppRoleMenuAction>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _sysAppRoleMenuActionRepository.GetRecordAsync(reqMsg);
            var list =await _sysAppRoleMenuActionRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysAppRoleMenuAction>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysAppRoleMenuActionService.QueryDataRecord(reqMsg);
            var list = _sysAppRoleMenuActionService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询角色授权功能表(sys_app_role_menu_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppRoleMenuActionService.QueryDataRecordAsync(reqMsg);
            var list = await _sysAppRoleMenuActionService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

