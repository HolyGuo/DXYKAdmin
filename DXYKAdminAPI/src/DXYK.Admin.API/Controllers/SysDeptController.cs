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
    /// 系统管理-单位信息表
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysDeptController : Controller
    {
        ///<summary>
        /// 系统管理-单位信息表(sys_dept) Service
        ///</summary>
        public SysDeptService SysDeptService { get; }

        ///<summary>
        /// 系统管理-单位信息表(sys_dept) Repository
        ///</summary>
        public ISysDeptRepository SysDeptRepository { get; }

        ///<summary>
        /// sys_deptController
        ///</summary>
        public SysDeptController(SysDeptService sysDeptService, ISysDeptRepository sysDeptRepository)
        {
            SysDeptService = sysDeptService;
            SysDeptRepository = sysDeptRepository;
        }

        ///<summary>
        /// 新增系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysDept sysDept)
        {
            return new ResponseMessage<long> { data = SysDeptService.Insert(sysDept) };
        }

        ///<summary>
        /// 异步新增系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>> InsertAsync([FromBody]SysDept sysDept)
        {
            return new ResponseMessage<long> { data = await SysDeptService.InsertAsync(sysDept) };
        }

        ///<summary>
        /// 删除系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data = SysDeptService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await SysDeptService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysDept sysDept)
        {
            //SysDept entity = SysDeptService.GetById(sysDept.id);
            //Utils.CommmonUtils.EntityToEntity(sysDept, entity, null);
            //return new ResponseMessage<int>{ data = SysDeptService.Update(entity) };
            return new ResponseMessage<int> { data = SysDeptService.Update(sysDept) };
        }

        ///<summary>
        /// 异步更新系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysDept sysDept)
        {
            //SysDept entity = await SysDeptService.GetByIdAsync(sysDept.id);
            //Utils.CommmonUtils.EntityToEntity(sysDept, entity, null);
            //return new ResponseMessage<int>{ data = await SysDeptService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await SysDeptService.UpdateAsync(sysDept) };
        }

        ///<summary>
        /// 根据Id查询系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysDept> GetById(long id)
        {
            var sysDept = SysDeptService.GetById(id);
            return new ResponseMessage<SysDept> { data = sysDept };
        }

        ///<summary>
        /// 根据Id查询系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysDept>> GetByIdAsync(long id)
        {
            var sysDept = await SysDeptService.GetByIdAsync(id);
            return new ResponseMessage<SysDept> { data = sysDept };
        }

        ///<summary>
        /// 根据条件查询系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysDept>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = SysDeptRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysDept>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysDept>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list = await SysDeptRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysDept>> { data = list };
        }

        ///<summary>
        /// 根据分页查询系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysDept>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = SysDeptRepository.GetRecord(reqMsg);
            var list = SysDeptRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysDept>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysDept>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await SysDeptRepository.GetRecordAsync(reqMsg);
            var list = await SysDeptRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysDept>>() { count = total, data = list };
        }

        ///<summary>
        /// 根据分页查询系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = SysDeptService.QueryDataRecord(reqMsg);
            var list = SysDeptService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统管理-单位信息表(sys_dept)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await SysDeptService.QueryDataRecordAsync(reqMsg);
            var list = await SysDeptService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

