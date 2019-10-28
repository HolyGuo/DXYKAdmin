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
using DXYK.Admin.API.Filters;
using DXYK.Admin.Common.EnumHelper;
using DXYK.Admin.Dto.Sys;
using DXYK.Admin.API.Utils;

namespace DXYK.Admin.API.Controllers
{
    ///<summary>
    /// 岗位信息表
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysJobController : Controller
    {
        ///<summary>
        /// 岗位信息表(sys_job) Service
        ///</summary>
        public SysJobService _sysJobService { get; }

        ///<summary>
        /// 单位信息表(sys_org) Service
        ///</summary>
        public SysOrgService _sysOrgService { get; }

        ///<summary>
        /// 岗位信息表(sys_job) Repository
        ///</summary>
        public ISysJobRepository _sysJobRepository { get; }

        ///<summary>
        /// sys_jobController
        ///</summary>
        public SysJobController(SysJobService sysJobService, SysOrgService sysOrgService, ISysJobRepository sysJobRepository)
        {
            _sysJobService = sysJobService;
            _sysOrgService = sysOrgService;
            _sysJobRepository = sysJobRepository;
        }

        ///<summary>
        /// 新增岗位信息表(sys_job)
        ///</summary>
        [HttpPost, ApiAuthorize(ActionCode = "Admin,Job_Manage,Job_Add", LogType = LogEnum.ADD)]
        public ResponseMessage<long> Insert([FromBody]SysJob sysJob)
        {
            UserInfo user = GetCurrentUser.GetUserInfo(HttpContext);
            sysJob.created_by = user.id;
            sysJob.created_time = DateTime.Now;
            return new ResponseMessage<long> { data = _sysJobService.Insert(sysJob) };
        }

        ///<summary>
        /// 异步新增岗位信息表(sys_job)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>> InsertAsync([FromBody]SysJob sysJob)
        {
            return new ResponseMessage<long> { data = await _sysJobService.InsertAsync(sysJob) };
        }

        ///<summary>
        /// 删除岗位信息表(sys_job)
        ///</summary>
        [HttpDelete, ApiAuthorize(ActionCode = "Admin,Job_Manage,Job_Delete", LogType = LogEnum.DELETE)]
        public ResponseMessage<int> DeleteById(string id)
        {
            return new ResponseMessage<int> { data = _sysJobService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除岗位信息表(sys_job)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(string id)
        {
            return new ResponseMessage<int> { data = await _sysJobService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新岗位信息表(sys_job)
        ///</summary>
        [HttpPut, ApiAuthorize(ActionCode = "Admin,Job_Manage,Job_Update", LogType = LogEnum.UPDATE)]
        public ResponseMessage<int> Update([FromBody]SysJob sysJob)
        {
            return new ResponseMessage<int> { data = _sysJobService.Update(sysJob) };
        }

        ///<summary>
        /// 异步更新岗位信息表(sys_job)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysJob sysJob)
        {
            //SysJob entity = await _sysJobService.GetByIdAsync(sysJob.id);
            //Utils.CommmonUtils.EntityToEntity(sysJob, entity, null);
            //return new ResponseMessage<int> { data = await _sysJobService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysJobService.UpdateAsync(sysJob) };
        }

        ///<summary>
        /// 根据Id查询岗位信息表(sys_job)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysJob> GetById(long id)
        {
            var sysJob = _sysJobService.GetById(id.ToString());
            return new ResponseMessage<SysJob> { data = sysJob };
        }

        ///<summary>
        /// 根据Id查询岗位信息表(sys_job)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysJob>> GetByIdAsync(string id)
        {
            var sysJob = await _sysJobService.GetByIdAsync(id);
            return new ResponseMessage<SysJob> { data = sysJob };
        }

        ///<summary>
        /// 根据条件查询岗位信息表(sys_job)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysJob>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysJobRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysJob>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询岗位信息表(sys_job)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysJob>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list = await _sysJobRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysJob>> { data = list };
        }

        ///<summary>
        /// 根据分页查询岗位信息表(sys_job)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysJob>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {

            var total = _sysJobRepository.GetRecord(reqMsg);
            var list = _sysJobRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysJob>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询岗位信息表(sys_job)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysJob>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysJobRepository.GetRecordAsync(reqMsg);
            var list = await _sysJobRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysJob>>() { count = total, data = list };
        }

        ///<summary>
        /// 根据分页查询岗位信息表(sys_job)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysJobService.QueryDataRecord(reqMsg);
            var list = _sysJobService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询岗位信息表(sys_job)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysJobService.QueryDataRecordAsync(reqMsg);
            var list = await _sysJobService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 根据分页和名称状态查询岗位信息表(sys_job)
        ///</summary>
        [HttpPost]
        public ResponseMessage<object> QueryDataByNameAndTypeByPage([FromBody]QueryNameByPageRequest reqMsg)
        {
            List<object> reslst = new List<object>();
            var total = _sysJobService.QueryDataByNameAndType(reqMsg.name, reqMsg.enabled);
            var list = _sysJobService.QueryDataByNameAndTypeByPage(reqMsg.name, reqMsg.enabled, reqMsg.OrderBy, reqMsg.limit, reqMsg.offset);
            foreach (var item in list)
            {
                var org = _sysOrgService.GetById(item.org_id);
                Object deptobj = new
                {
                    id = org.id,
                    name = org.org_name,
                    enabled = org.dept_type,
                    pid = (long)org.parent_id,
                    createTime = org.created_time.ToString(),
                    label = org.org_name
                };
                Object obj = new
                {
                    id = item.id,
                    sort = item.sort,
                    name = item.job_name,
                    enabled = item.is_enable,
                    dept = deptobj,
                    deptSuperiorName = org.org_name,
                    createTime = item.created_time.ToString()
                };
                reslst.Add(obj);
            }
            return new ResponseMessage<object> { data = new { content = reslst, totalElements = total } };
        }


    }
}

