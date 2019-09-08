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
    /// 系统管理-菜单信息表
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysMenuController : Controller
    {
        ///<summary>
        /// 系统管理-菜单信息表(sys_menu) Service
        ///</summary>
        public SysMenuService SysMenuService { get; }

        ///<summary>
        /// 系统管理-菜单信息表(sys_menu) Repository
        ///</summary>
        public ISysMenuRepository SysMenuRepository { get; }

        ///<summary>
        /// sys_menuController
        ///</summary>
        public SysMenuController(SysMenuService sysMenuService, ISysMenuRepository sysMenuRepository)
        {
            SysMenuService = sysMenuService;
            SysMenuRepository = sysMenuRepository;
        }

        ///<summary>
        /// 新增系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysMenu sysMenu)
        {
            return new ResponseMessage<long> { data = SysMenuService.Insert(sysMenu) };
        }

        ///<summary>
        /// 异步新增系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>> InsertAsync([FromBody]SysMenu sysMenu)
        {
            return new ResponseMessage<long> { data = await SysMenuService.InsertAsync(sysMenu) };
        }

        ///<summary>
        /// 删除系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data = SysMenuService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await SysMenuService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysMenu sysMenu)
        {
            //SysMenu entity = SysMenuService.GetById(sysMenu.id);
            //Utils.CommmonUtils.EntityToEntity(sysMenu, entity, null);
            //return new ResponseMessage<int>{ data = SysMenuService.Update(entity) };
            return new ResponseMessage<int> { data = SysMenuService.Update(sysMenu) };
        }

        ///<summary>
        /// 异步更新系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysMenu sysMenu)
        {
            //SysMenu entity = await SysMenuService.GetByIdAsync(sysMenu.id);
            //Utils.CommmonUtils.EntityToEntity(sysMenu, entity, null);
            //return new ResponseMessage<int>{ data = await SysMenuService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await SysMenuService.UpdateAsync(sysMenu) };
        }

        ///<summary>
        /// 根据Id查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysMenu> GetById(long id)
        {
            var sysMenu = SysMenuService.GetById(id);
            return new ResponseMessage<SysMenu> { data = sysMenu };
        }

        ///<summary>
        /// 根据Id查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysMenu>> GetByIdAsync(long id)
        {
            var sysMenu = await SysMenuService.GetByIdAsync(id);
            return new ResponseMessage<SysMenu> { data = sysMenu };
        }

        ///<summary>
        /// 根据条件查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysMenu>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = SysMenuRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysMenu>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysMenu>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list = await SysMenuRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysMenu>> { data = list };
        }

        ///<summary>
        /// 根据分页查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysMenu>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = SysMenuRepository.GetRecord(reqMsg);
            var list = SysMenuRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysMenu>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysMenu>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await SysMenuRepository.GetRecordAsync(reqMsg);
            var list = await SysMenuRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysMenu>>() { count = total, data = list };
        }

        ///<summary>
        /// 根据分页查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = SysMenuService.QueryDataRecord(reqMsg);
            var list = SysMenuService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await SysMenuService.QueryDataRecordAsync(reqMsg);
            var list = await SysMenuService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

