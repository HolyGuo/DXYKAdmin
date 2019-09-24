//*******************************
// Create By Holy Guo
// Date 2019-09-12 15:48
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
        /// 群组信息表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysGroupController : Controller
    {
        ///<summary>
        /// 群组信息表(sys_group) Service
        ///</summary>
        public SysGroupService _sysGroupService { get; }

        ///<summary>
        /// 群组信息表(sys_group) Repository
        ///</summary>
        public ISysGroupRepository _sysGroupRepository { get; }

        ///<summary>
        /// sys_groupController
        ///</summary>
        public SysGroupController(SysGroupService sysGroupService, ISysGroupRepository sysGroupRepository)
        {
            _sysGroupService = sysGroupService;
            _sysGroupRepository = sysGroupRepository;
        }

        ///<summary>
        /// 新增群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysGroup sysGroup)
        {
            return new ResponseMessage<long> { data = _sysGroupService.Insert(sysGroup) }; 
        }

        ///<summary>
        /// 异步新增群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>>InsertAsync([FromBody]SysGroup sysGroup)
        {
            return new ResponseMessage<long> { data = await _sysGroupService.InsertAsync(sysGroup) };
        }

        ///<summary>
        /// 删除群组信息表(sys_group)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data =  _sysGroupService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除群组信息表(sys_group)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await _sysGroupService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新群组信息表(sys_group)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysGroup sysGroup)
        {
            return new ResponseMessage<int> { data = _sysGroupService.Update(sysGroup) };
        }

        ///<summary>
        /// 异步更新群组信息表(sys_group)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysGroup sysGroup)
        {
            //SysGroup entity = await _sysGroupService.GetByIdAsync(sysGroup.id);
            //Utils.CommmonUtils.EntityToEntity(sysGroup, entity, null);
            //return new ResponseMessage<int> { data = await _sysGroupService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysGroupService.UpdateAsync(sysGroup) };
        }

        ///<summary>
        /// 根据Id查询群组信息表(sys_group)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysGroup> GetById(long id)
        {
            var sysGroup = _sysGroupService.GetById(id);
            return new ResponseMessage<SysGroup> {  data = sysGroup };
        }

        ///<summary>
        /// 根据Id查询群组信息表(sys_group)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysGroup>> GetByIdAsync(long id)
        {
            var sysGroup =await _sysGroupService.GetByIdAsync(id);
            return new ResponseMessage<SysGroup>{ data = sysGroup};
        }

        ///<summary>
        /// 根据条件查询群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysGroup>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysGroupRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysGroup>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysGroup>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _sysGroupRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysGroup>> { data = list };
        }

        ///<summary>
        /// 根据分页查询群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysGroup>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _sysGroupRepository.GetRecord(reqMsg);
            var list = _sysGroupRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysGroup>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysGroup>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _sysGroupRepository.GetRecordAsync(reqMsg);
            var list =await _sysGroupRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysGroup>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysGroupService.QueryDataRecord(reqMsg);
            var list = _sysGroupService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysGroupService.QueryDataRecordAsync(reqMsg);
            var list = await _sysGroupService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

