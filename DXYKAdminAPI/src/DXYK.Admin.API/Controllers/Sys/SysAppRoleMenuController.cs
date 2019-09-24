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
        /// 角色授权菜单表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysAppRoleMenuController : Controller
    {
        ///<summary>
        /// 角色授权菜单表(sys_app_role_menu) Service
        ///</summary>
        public SysAppRoleMenuService _sysAppRoleMenuService { get; }

        ///<summary>
        /// 角色授权菜单表(sys_app_role_menu) Repository
        ///</summary>
        public ISysAppRoleMenuRepository _sysAppRoleMenuRepository { get; }

        ///<summary>
        /// sys_app_role_menuController
        ///</summary>
        public SysAppRoleMenuController(SysAppRoleMenuService sysAppRoleMenuService, ISysAppRoleMenuRepository sysAppRoleMenuRepository)
        {
            _sysAppRoleMenuService = sysAppRoleMenuService;
            _sysAppRoleMenuRepository = sysAppRoleMenuRepository;
        }

        ///<summary>
        /// 新增角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysAppRoleMenu sysAppRoleMenu)
        {
            return new ResponseMessage<long> { data = _sysAppRoleMenuService.Insert(sysAppRoleMenu) }; 
        }

        ///<summary>
        /// 异步新增角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>>InsertAsync([FromBody]SysAppRoleMenu sysAppRoleMenu)
        {
            return new ResponseMessage<long> { data = await _sysAppRoleMenuService.InsertAsync(sysAppRoleMenu) };
        }

        ///<summary>
        /// 删除角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data =  _sysAppRoleMenuService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await _sysAppRoleMenuService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysAppRoleMenu sysAppRoleMenu)
        {
            return new ResponseMessage<int> { data = _sysAppRoleMenuService.Update(sysAppRoleMenu) };
        }

        ///<summary>
        /// 异步更新角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysAppRoleMenu sysAppRoleMenu)
        {
            //SysAppRoleMenu entity = await _sysAppRoleMenuService.GetByIdAsync(sysAppRoleMenu.id);
            //Utils.CommmonUtils.EntityToEntity(sysAppRoleMenu, entity, null);
            //return new ResponseMessage<int> { data = await _sysAppRoleMenuService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysAppRoleMenuService.UpdateAsync(sysAppRoleMenu) };
        }

        ///<summary>
        /// 根据Id查询角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysAppRoleMenu> GetById(long id)
        {
            var sysAppRoleMenu = _sysAppRoleMenuService.GetById(id);
            return new ResponseMessage<SysAppRoleMenu> {  data = sysAppRoleMenu };
        }

        ///<summary>
        /// 根据Id查询角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysAppRoleMenu>> GetByIdAsync(long id)
        {
            var sysAppRoleMenu =await _sysAppRoleMenuService.GetByIdAsync(id);
            return new ResponseMessage<SysAppRoleMenu>{ data = sysAppRoleMenu};
        }

        ///<summary>
        /// 根据条件查询角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysAppRoleMenu>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysAppRoleMenuRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysAppRoleMenu>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysAppRoleMenu>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _sysAppRoleMenuRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysAppRoleMenu>> { data = list };
        }

        ///<summary>
        /// 根据分页查询角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysAppRoleMenu>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _sysAppRoleMenuRepository.GetRecord(reqMsg);
            var list = _sysAppRoleMenuRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysAppRoleMenu>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysAppRoleMenu>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _sysAppRoleMenuRepository.GetRecordAsync(reqMsg);
            var list =await _sysAppRoleMenuRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysAppRoleMenu>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysAppRoleMenuService.QueryDataRecord(reqMsg);
            var list = _sysAppRoleMenuService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询角色授权菜单表(sys_app_role_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppRoleMenuService.QueryDataRecordAsync(reqMsg);
            var list = await _sysAppRoleMenuService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

