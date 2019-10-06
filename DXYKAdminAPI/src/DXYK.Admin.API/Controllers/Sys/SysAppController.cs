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
        /// 应用信息表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysAppController : Controller
    {
        ///<summary>
        /// 应用信息表(sys_app) Service
        ///</summary>
        public SysAppService _sysAppService { get; }

        ///<summary>
        /// 应用信息表(sys_app) Repository
        ///</summary>
        public ISysAppRepository _sysAppRepository { get; }

        ///<summary>
        /// sys_appController
        ///</summary>
        public SysAppController(SysAppService sysAppService, ISysAppRepository sysAppRepository)
        {
            _sysAppService = sysAppService;
            _sysAppRepository = sysAppRepository;
        }

        ///<summary>
        /// 新增应用信息表(sys_app)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysApp sysApp)
        {
            return new ResponseMessage<long> { data = _sysAppService.Insert(sysApp) }; 
        }

        ///<summary>
        /// 异步新增应用信息表(sys_app)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>>InsertAsync([FromBody]SysApp sysApp)
        {
            return new ResponseMessage<long> { data = await _sysAppService.InsertAsync(sysApp) };
        }

        ///<summary>
        /// 删除应用信息表(sys_app)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(string id)
        {
            return new ResponseMessage<int> { data =  _sysAppService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除应用信息表(sys_app)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(string id)
        {
            return new ResponseMessage<int> { data = await _sysAppService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新应用信息表(sys_app)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysApp sysApp)
        {
            return new ResponseMessage<int> { data = _sysAppService.Update(sysApp) };
        }

        ///<summary>
        /// 异步更新应用信息表(sys_app)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysApp sysApp)
        {
            //SysApp entity = await _sysAppService.GetByIdAsync(sysApp.id);
            //Utils.CommmonUtils.EntityToEntity(sysApp, entity, null);
            //return new ResponseMessage<int> { data = await _sysAppService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysAppService.UpdateAsync(sysApp) };
        }

        ///<summary>
        /// 根据Id查询应用信息表(sys_app)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysApp> GetById(string id)
        {
            var sysApp = _sysAppService.GetById(id);
            return new ResponseMessage<SysApp> {  data = sysApp };
        }

        ///<summary>
        /// 根据Id查询应用信息表(sys_app)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysApp>> GetByIdAsync(string id)
        {
            var sysApp =await _sysAppService.GetByIdAsync(id);
            return new ResponseMessage<SysApp>{ data = sysApp};
        }

        ///<summary>
        /// 根据条件查询应用信息表(sys_app)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysApp>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysAppRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysApp>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询应用信息表(sys_app)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysApp>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _sysAppRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysApp>> { data = list };
        }

        ///<summary>
        /// 根据分页查询应用信息表(sys_app)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysApp>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _sysAppRepository.GetRecord(reqMsg);
            var list = _sysAppRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysApp>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询应用信息表(sys_app)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysApp>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _sysAppRepository.GetRecordAsync(reqMsg);
            var list =await _sysAppRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysApp>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询应用信息表(sys_app)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysAppService.QueryDataRecord(reqMsg);
            var list = _sysAppService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询应用信息表(sys_app)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppService.QueryDataRecordAsync(reqMsg);
            var list = await _sysAppService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

