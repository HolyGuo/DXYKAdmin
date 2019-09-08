//*******************************
// Create By Holy Guo
// Date 2019-09-08 16:47
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
    /// 系统管理-群组信息表
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysGroupController : Controller
    {
        ///<summary>
        /// 系统管理-群组信息表(sys_group) Service
        ///</summary>
        public SysGroupService SysGroupService { get; }

        ///<summary>
        /// 系统管理-群组信息表(sys_group) Repository
        ///</summary>
        public ISysGroupRepository SysGroupRepository { get; }

        ///<summary>
        /// sys_groupController
        ///</summary>
        public SysGroupController(SysGroupService sysGroupService, ISysGroupRepository sysGroupRepository)
        {
            SysGroupService = sysGroupService;
            SysGroupRepository = sysGroupRepository;
        }

        ///<summary>
        /// 新增系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysGroup sysGroup)
        {
            return new ResponseMessage<long> { success = true, code = 0, msg = "OK", data = SysGroupService.Insert(sysGroup) };
        }

        ///<summary>
        /// 异步新增系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>> InsertAsync([FromBody]SysGroup sysGroup)
        {
            return new ResponseMessage<long> { success = true, code = 0, msg = "OK", data = await SysGroupService.InsertAsync(sysGroup) };
        }

        ///<summary>
        /// 删除系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { success = true, code = 0, msg = "OK", data = SysGroupService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { success = true, code = 0, msg = "OK", data = await SysGroupService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysGroup sysGroup)
        {
            //SysGroup entity = SysGroupService.GetById(sysGroup.id);
            //Utils.CommmonUtils.EntityToEntity(sysGroup, entity, null);
            //return new ResponseMessage<int>{ success = true, code = 0, msg = "OK",data = SysGroupService.Update(entity) };
            return new ResponseMessage<int> { success = true, code = 0, msg = "OK", data = SysGroupService.Update(sysGroup) };
        }

        ///<summary>
        /// 异步更新系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysGroup sysGroup)
        {
            //SysGroup entity = await SysGroupService.GetByIdAsync(sysGroup.id);
            //Utils.CommmonUtils.EntityToEntity(sysGroup, entity, null);
            //return new ResponseMessage<int>{ success = true, code = 0, msg = "OK",data = await SysGroupService.UpdateAsync(entity) };
            return new ResponseMessage<int> { success = true, code = 0, msg = "OK", data = await SysGroupService.UpdateAsync(sysGroup) };
        }

        ///<summary>
        /// 根据Id查询系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysGroup> GetById(long id)
        {
            var sysGroup = SysGroupService.GetById(id);
            return new ResponseMessage<SysGroup> { success = true, code = 0, msg = "OK", data = sysGroup };
        }

        ///<summary>
        /// 根据Id查询系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysGroup>> GetByIdAsync(long id)
        {
            var sysGroup = await SysGroupService.GetByIdAsync(id);
            return new ResponseMessage<SysGroup> { success = true, code = 0, msg = "OK", data = sysGroup };
        }

        ///<summary>
        /// 根据条件查询系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysGroup>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = SysGroupRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysGroup>> { success = true, code = 0, msg = "OK", data = list };
        }

        ///<summary>
        /// 异步根据条件查询系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysGroup>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list = await SysGroupRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysGroup>> { success = true, code = 0, msg = "OK", data = list };
        }

        ///<summary>
        /// 根据分页查询系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysGroup>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = SysGroupRepository.GetRecord(reqMsg);
            var list = SysGroupRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysGroup>>() { success = true, code = 0, msg = "OK", count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysGroup>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await SysGroupRepository.GetRecordAsync(reqMsg);
            var list = await SysGroupRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysGroup>>() { success = true, code = 0, msg = "OK", count = total, data = list };
        }

        ///<summary>
        /// 根据分页查询系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = SysGroupService.QueryDataRecord(reqMsg);
            var list = SysGroupService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { success = true, code = 0, msg = "OK", count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统管理-群组信息表(sys_group)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await SysGroupService.QueryDataRecordAsync(reqMsg);
            var list = await SysGroupService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { success = true, code = 0, msg = "OK", count = total, data = list };
        }


    }
}

