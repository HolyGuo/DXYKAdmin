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
        public ResponseMessageWrap<long> Insert([FromBody]SysMenu sysMenu)
        {
            return new ResponseMessageWrap<long> { data = SysMenuService.Insert(sysMenu) };
        }

        ///<summary>
        /// 异步新增系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<long>> InsertAsync([FromBody]SysMenu sysMenu)
        {
            return new ResponseMessageWrap<long> { data = await SysMenuService.InsertAsync(sysMenu) };
        }

        ///<summary>
        /// 删除系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpDelete]
        public ResponseMessageWrap<int> DeleteById(long id)
        {
            return new ResponseMessageWrap<int> { data = SysMenuService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessageWrap<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessageWrap<int> { data = await SysMenuService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPut]
        public ResponseMessageWrap<int> Update([FromBody]SysMenu sysMenu)
        {
            return new ResponseMessageWrap<int> { data = SysMenuService.Update(sysMenu) };
        }

        ///<summary>
        /// 异步更新系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessageWrap<int>> UpdateAsync([FromBody]SysMenu sysMenu)
        {
            return new ResponseMessageWrap<int> { data = await SysMenuService.UpdateAsync(sysMenu) };
        }

        ///<summary>
        /// 根据Id查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpGet]
        public ResponseMessageWrap<SysMenu> GetById(long id)
        {
            var sysMenu = SysMenuService.GetById(id);
            return new ResponseMessageWrap<SysMenu> { data = sysMenu };
        }

        ///<summary>
        /// 根据Id查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessageWrap<SysMenu>> GetByIdAsync(long id)
        {
            var sysMenu = await SysMenuService.GetByIdAsync(id);
            return new ResponseMessageWrap<SysMenu> { data = sysMenu };
        }

        ///<summary>
        /// 根据条件查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysMenu>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = SysMenuRepository.Query(reqMsg);
            return new ResponseMessageWrap<IList<SysMenu>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysMenu>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list = await SysMenuRepository.QueryAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysMenu>> { data = list };
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
            var total = SysMenuRepository.QueryDataRecord(reqMsg);
            var list = SysMenuRepository.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统管理-菜单信息表(sys_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await SysMenuRepository.QueryDataRecordAsync(reqMsg);
            var list = await SysMenuRepository.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

