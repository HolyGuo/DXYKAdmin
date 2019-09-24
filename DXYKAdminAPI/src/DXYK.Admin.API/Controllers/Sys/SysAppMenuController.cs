//*******************************
// Create By Holy Guo
// Date 2019-09-12 15:55
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
    /// 菜单信息表
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysAppMenuController : Controller
    {
        ///<summary>
        /// 菜单信息表(sys_app_menu) Service
        ///</summary>
        public SysAppMenuService _sysAppMenuService { get; }

        ///<summary>
        /// 菜单信息表(sys_app_menu) Repository
        ///</summary>
        public ISysAppMenuRepository _sysAppMenuRepository { get; }

        ///<summary>
        /// sys_app_menuController
        ///</summary>
        public SysAppMenuController(SysAppMenuService sysAppMenuService, ISysAppMenuRepository sysAppMenuRepository)
        {
            _sysAppMenuService = sysAppMenuService;
            _sysAppMenuRepository = sysAppMenuRepository;
        }

        ///<summary>
        /// 新增菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysAppMenu sysAppMenu)
        {
            return new ResponseMessage<long> { data = _sysAppMenuService.Insert(sysAppMenu) };
        }

        ///<summary>
        /// 异步新增菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>> InsertAsync([FromBody]SysAppMenu sysAppMenu)
        {
            return new ResponseMessage<long> { data = await _sysAppMenuService.InsertAsync(sysAppMenu) };
        }

        ///<summary>
        /// 删除菜单信息表(sys_app_menu)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data = _sysAppMenuService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除菜单信息表(sys_app_menu)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await _sysAppMenuService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysAppMenu sysAppMenu)
        {
            return new ResponseMessage<int> { data = _sysAppMenuService.Update(sysAppMenu) };
        }

        ///<summary>
        /// 异步更新菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysAppMenu sysAppMenu)
        {
            //SysAppMenu entity = await _sysAppMenuService.GetByIdAsync(sysAppMenu.id);
            //Utils.CommmonUtils.EntityToEntity(sysAppMenu, entity, null);
            //return new ResponseMessage<int> { data = await _sysAppMenuService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysAppMenuService.UpdateAsync(sysAppMenu) };
        }

        ///<summary>
        /// 根据Id查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysAppMenu> GetById(long id)
        {
            var sysAppMenu = _sysAppMenuService.GetById(id);
            return new ResponseMessage<SysAppMenu> { data = sysAppMenu };
        }

        ///<summary>
        /// 根据Id查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysAppMenu>> GetByIdAsync(long id)
        {
            var sysAppMenu = await _sysAppMenuService.GetByIdAsync(id);
            return new ResponseMessage<SysAppMenu> { data = sysAppMenu };
        }

        ///<summary>
        /// 根据条件查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysAppMenu>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysAppMenuRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysAppMenu>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysAppMenu>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list = await _sysAppMenuRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysAppMenu>> { data = list };
        }

        ///<summary>
        /// 根据分页查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysAppMenu>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {

            var total = _sysAppMenuRepository.GetRecord(reqMsg);
            var list = _sysAppMenuRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysAppMenu>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysAppMenu>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppMenuRepository.GetRecordAsync(reqMsg);
            var list = await _sysAppMenuRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysAppMenu>>() { count = total, data = list };
        }

        ///<summary>
        /// 根据分页查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysAppMenuService.QueryDataRecord(reqMsg);
            var list = _sysAppMenuService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppMenuService.QueryDataRecordAsync(reqMsg);
            var list = await _sysAppMenuService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

