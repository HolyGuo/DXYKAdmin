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
        /// 单位信息表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysOrgController : Controller
    {
        ///<summary>
        /// 单位信息表(sys_org) Service
        ///</summary>
        public SysOrgService _sysOrgService { get; }

        ///<summary>
        /// 单位信息表(sys_org) Repository
        ///</summary>
        public ISysOrgRepository _sysOrgRepository { get; }

        ///<summary>
        /// sys_orgController
        ///</summary>
        public SysOrgController(SysOrgService sysOrgService, ISysOrgRepository sysOrgRepository)
        {
            _sysOrgService = sysOrgService;
            _sysOrgRepository = sysOrgRepository;
        }

        ///<summary>
        /// 新增单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysOrg sysOrg)
        {
            return new ResponseMessage<long> { data = _sysOrgService.Insert(sysOrg) }; 
        }

        ///<summary>
        /// 异步新增单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>>InsertAsync([FromBody]SysOrg sysOrg)
        {
            return new ResponseMessage<long> { data = await _sysOrgService.InsertAsync(sysOrg) };
        }

        ///<summary>
        /// 删除单位信息表(sys_org)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data =  _sysOrgService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除单位信息表(sys_org)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await _sysOrgService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新单位信息表(sys_org)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysOrg sysOrg)
        {
            return new ResponseMessage<int> { data = _sysOrgService.Update(sysOrg) };
        }

        ///<summary>
        /// 异步更新单位信息表(sys_org)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysOrg sysOrg)
        {
            //SysOrg entity = await _sysOrgService.GetByIdAsync(sysOrg.id);
            //Utils.CommmonUtils.EntityToEntity(sysOrg, entity, null);
            //return new ResponseMessage<int> { data = await _sysOrgService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysOrgService.UpdateAsync(sysOrg) };
        }

        ///<summary>
        /// 根据Id查询单位信息表(sys_org)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysOrg> GetById(long id)
        {
            var sysOrg = _sysOrgService.GetById(id);
            return new ResponseMessage<SysOrg> {  data = sysOrg };
        }

        ///<summary>
        /// 根据Id查询单位信息表(sys_org)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysOrg>> GetByIdAsync(long id)
        {
            var sysOrg =await _sysOrgService.GetByIdAsync(id);
            return new ResponseMessage<SysOrg>{ data = sysOrg};
        }

        ///<summary>
        /// 根据条件查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysOrg>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysOrgRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysOrg>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysOrg>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _sysOrgRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysOrg>> { data = list };
        }

        ///<summary>
        /// 根据分页查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysOrg>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _sysOrgRepository.GetRecord(reqMsg);
            var list = _sysOrgRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysOrg>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysOrg>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _sysOrgRepository.GetRecordAsync(reqMsg);
            var list =await _sysOrgRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysOrg>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysOrgService.QueryDataRecord(reqMsg);
            var list = _sysOrgService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysOrgService.QueryDataRecordAsync(reqMsg);
            var list = await _sysOrgService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

