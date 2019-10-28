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
        /// 系统日志表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysLogController : Controller
    {
        ///<summary>
        /// 系统日志表(sys_log) Service
        ///</summary>
        public SysLogService _sysLogService { get; }

        ///<summary>
        /// 系统日志表(sys_log) Repository
        ///</summary>
        public ISysLogRepository _sysLogRepository { get; }

        ///<summary>
        /// sys_logController
        ///</summary>
        public SysLogController(SysLogService sysLogService, ISysLogRepository sysLogRepository)
        {
            _sysLogService = sysLogService;
            _sysLogRepository = sysLogRepository;
        }

        ///<summary>
        /// 新增系统日志表(sys_log)
        ///</summary>
        [HttpPost]
        public ResponseMessage<string> Insert([FromBody]SysLog sysLog)
        {
            return new ResponseMessage<string> { data = _sysLogService.Insert(sysLog) }; 
        }

        ///<summary>
        /// 异步新增系统日志表(sys_log)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<string>>InsertAsync([FromBody]SysLog sysLog)
        {
            return new ResponseMessage<string> { data = await _sysLogService.InsertAsync(sysLog) };
        }

        ///<summary>
        /// 删除系统日志表(sys_log)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(string id)
        {
            return new ResponseMessage<int> { data =  _sysLogService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除系统日志表(sys_log)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(string id)
        {
            return new ResponseMessage<int> { data = await _sysLogService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新系统日志表(sys_log)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysLog sysLog)
        {
            return new ResponseMessage<int> { data = _sysLogService.Update(sysLog) };
        }

        ///<summary>
        /// 异步更新系统日志表(sys_log)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysLog sysLog)
        {
            //SysLog entity = await _sysLogService.GetByIdAsync(sysLog.id);
            //Utils.CommmonUtils.EntityToEntity(sysLog, entity, null);
            //return new ResponseMessage<int> { data = await _sysLogService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysLogService.UpdateAsync(sysLog) };
        }

        ///<summary>
        /// 根据Id查询系统日志表(sys_log)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysLog> GetById(string id)
        {
            var sysLog = _sysLogService.GetById(id);
            return new ResponseMessage<SysLog> {  data = sysLog };
        }

        ///<summary>
        /// 根据Id查询系统日志表(sys_log)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysLog>> GetByIdAsync(string id)
        {
            var sysLog =await _sysLogService.GetByIdAsync(id);
            return new ResponseMessage<SysLog>{ data = sysLog};
        }

        ///<summary>
        /// 根据条件查询系统日志表(sys_log)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysLog>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysLogRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysLog>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询系统日志表(sys_log)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysLog>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _sysLogRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysLog>> { data = list };
        }

        ///<summary>
        /// 根据分页查询系统日志表(sys_log)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysLog>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _sysLogRepository.GetRecord(reqMsg);
            var list = _sysLogRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysLog>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统日志表(sys_log)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysLog>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _sysLogRepository.GetRecordAsync(reqMsg);
            var list =await _sysLogRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysLog>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询系统日志表(sys_log)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysLogService.QueryDataRecord(reqMsg);
            var list = _sysLogService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询系统日志表(sys_log)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysLogService.QueryDataRecordAsync(reqMsg);
            var list = await _sysLogService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

