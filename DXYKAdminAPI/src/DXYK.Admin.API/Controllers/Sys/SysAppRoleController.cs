//*******************************
// Create By Holy Guo
// Date 2019-10-03 09:12
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
using DXYK.Admin.API.Filters;
using DXYK.Admin.Common.EnumHelper;

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
        /// 角色授权表(sys_app_role_map) Service
        ///</summary>
        public SysAppRoleMapService _sysAppRoleMapService { get; }

        ///<summary>
        /// 菜单信息表(sys_app_menu) Service
        ///</summary>
        public SysAppMenuService _sysAppMenuService { get; }

        ///<summary>
        /// 功能信息表(sys_app_action) Service
        ///</summary>
        public SysAppActionService _sysAppActionService { get; }

        ///<summary>
        /// sys_app_roleController
        ///</summary>
        public SysAppRoleController(SysAppRoleService sysAppRoleService, ISysAppRoleRepository sysAppRoleRepository, SysAppRoleMapService sysAppRoleMapService, SysAppMenuService sysAppMenuService, 
            SysAppActionService sysAppActionService)
        {
            _sysAppRoleService = sysAppRoleService;
            _sysAppRoleRepository = sysAppRoleRepository;
            _sysAppRoleMapService = sysAppRoleMapService;
            _sysAppMenuService = sysAppMenuService;
            _sysAppActionService = sysAppActionService;
        }

        ///<summary>
        /// 新增角色信息表(sys_app_role)
        ///</summary>
        [HttpPost, ApiAuthorize(ActionCode = "Admin,Role_Manage,Role_Add", LogType = LogEnum.ADD)]
        public ResponseMessage<long> Insert([FromBody]SysAppRole sysAppRole)
        {
            sysAppRole.created_time = DateTime.Now;
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
        [HttpDelete, ApiAuthorize(ActionCode = "Admin,Role_Manage,Role_Delete", LogType = LogEnum.DELETE)]
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
        [HttpPut, ApiAuthorize(ActionCode = "Admin,Role_Manage,Role_Update", LogType = LogEnum.UPDATE)]
        public ResponseMessage<int> Update([FromBody]SysAppRole sysAppRole)
        {
            sysAppRole.created_time = DateTime.Now;
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

        ///<summary>
        /// 根据分页查询角色信息表(sys_app_role)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> GetAllByName([FromBody]QueryByPageRequest reqMsg)
        {
            List<object> reslst = new List<object>();
            var total = _sysAppRoleService.QueryDataRecord(reqMsg);
            var col1 = _sysAppRoleService.QueryDataByPage(reqMsg);
            foreach (var item in col1)
            {
                List<object> menuobj = new List<object>();
                List<object> actobj = new List<object>();
                //菜单权限
                var menus = _sysAppRoleMapService.QueryDataByRole(item.id, 1);
                foreach (var menuitem in menus)
                {
                    var menu = _sysAppMenuService.GetById(menuitem.map_id);
                    object tmpobj = new
                    {
                        id = menu.id,
                        name = menu.title,
                        pid = menu.parent_id
                    };
                    menuobj.Add(tmpobj);
                }
                //功能权限
                var actions = _sysAppRoleMapService.QueryDataByRole(item.id, 2);
                foreach (var actitem in actions)
                {
                    var menu = _sysAppActionService.GetById(actitem.map_id);
                    object tmpobj = new
                    {
                        id = menu.id,
                        name = menu.action_name,
                        pid = menu.parent_id
                    };
                    actobj.Add(tmpobj);
                }
                object roleobj = new
                {
                    id = item.id,
                    name = item.role_code,
                    menus = menuobj,
                    permissions = actobj,
                    createTime = item.created_time
                };
                reslst.Add(roleobj);
            }
            return new ResponseMessageWrap<object> { count = total, data = new{ content = reslst, totalElements = total } };
        }
    }
}

