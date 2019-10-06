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

namespace DXYK.Admin.API.Controllers
{
    ///<summary>
        /// 功能信息表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysAppMenuActionController : Controller
    {
        ///<summary>
        /// 功能信息表(sys_app_menu_action) Service
        ///</summary>
        public SysAppMenuActionService _sysAppMenuActionService { get; }

        ///<summary>
        /// 功能信息表(sys_app_menu_action) Repository
        ///</summary>
        public ISysAppMenuActionRepository _sysAppMenuActionRepository { get; }

        ///<summary>
        /// sys_app_menu_actionController
        ///</summary>
        public SysAppMenuActionController(SysAppMenuActionService sysAppMenuActionService, ISysAppMenuActionRepository sysAppMenuActionRepository)
        {
            _sysAppMenuActionService = sysAppMenuActionService;
            _sysAppMenuActionRepository = sysAppMenuActionRepository;
        }

        ///<summary>
        /// 新增功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysAppMenuAction sysAppMenuAction)
        {
            return new ResponseMessage<long> { data = _sysAppMenuActionService.Insert(sysAppMenuAction) }; 
        }

        ///<summary>
        /// 异步新增功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>>InsertAsync([FromBody]SysAppMenuAction sysAppMenuAction)
        {
            return new ResponseMessage<long> { data = await _sysAppMenuActionService.InsertAsync(sysAppMenuAction) };
        }

        ///<summary>
        /// 删除功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data =  _sysAppMenuActionService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await _sysAppMenuActionService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysAppMenuAction sysAppMenuAction)
        {
            return new ResponseMessage<int> { data = _sysAppMenuActionService.Update(sysAppMenuAction) };
        }

        ///<summary>
        /// 异步更新功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysAppMenuAction sysAppMenuAction)
        {
            //SysAppMenuAction entity = await _sysAppMenuActionService.GetByIdAsync(sysAppMenuAction.id);
            //Utils.CommmonUtils.EntityToEntity(sysAppMenuAction, entity, null);
            //return new ResponseMessage<int> { data = await _sysAppMenuActionService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysAppMenuActionService.UpdateAsync(sysAppMenuAction) };
        }

        ///<summary>
        /// 根据Id查询功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysAppMenuAction> GetById(long id)
        {
            var sysAppMenuAction = _sysAppMenuActionService.GetById(id);
            return new ResponseMessage<SysAppMenuAction> {  data = sysAppMenuAction };
        }

        ///<summary>
        /// 根据Id查询功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysAppMenuAction>> GetByIdAsync(long id)
        {
            var sysAppMenuAction =await _sysAppMenuActionService.GetByIdAsync(id);
            return new ResponseMessage<SysAppMenuAction>{ data = sysAppMenuAction};
        }

        ///<summary>
        /// 根据条件查询功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysAppMenuAction>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysAppMenuActionRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysAppMenuAction>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysAppMenuAction>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _sysAppMenuActionRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysAppMenuAction>> { data = list };
        }

        ///<summary>
        /// 根据分页查询功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysAppMenuAction>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _sysAppMenuActionRepository.GetRecord(reqMsg);
            var list = _sysAppMenuActionRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysAppMenuAction>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysAppMenuAction>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _sysAppMenuActionRepository.GetRecordAsync(reqMsg);
            var list =await _sysAppMenuActionRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysAppMenuAction>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysAppMenuActionService.QueryDataRecord(reqMsg);
            var list = _sysAppMenuActionService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询功能信息表(sys_app_menu_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppMenuActionService.QueryDataRecordAsync(reqMsg);
            var list = await _sysAppMenuActionService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

