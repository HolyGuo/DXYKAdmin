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
        /// 用户信息表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysUserController : Controller
    {
        ///<summary>
        /// 用户信息表(sys_user) Service
        ///</summary>
        public SysUserService _sysUserService { get; }

        ///<summary>
        /// 用户信息表(sys_user) Repository
        ///</summary>
        public ISysUserRepository _sysUserRepository { get; }

        ///<summary>
        /// sys_userController
        ///</summary>
        public SysUserController(SysUserService sysUserService, ISysUserRepository sysUserRepository)
        {
            _sysUserService = sysUserService;
            _sysUserRepository = sysUserRepository;
        }

        ///<summary>
        /// 新增用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysUser sysUser)
        {
            return new ResponseMessage<long> { data = _sysUserService.Insert(sysUser) }; 
        }

        ///<summary>
        /// 异步新增用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>>InsertAsync([FromBody]SysUser sysUser)
        {
            return new ResponseMessage<long> { data = await _sysUserService.InsertAsync(sysUser) };
        }

        ///<summary>
        /// 删除用户信息表(sys_user)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data =  _sysUserService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除用户信息表(sys_user)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await _sysUserService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新用户信息表(sys_user)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysUser sysUser)
        {
            return new ResponseMessage<int> { data = _sysUserService.Update(sysUser) };
        }

        ///<summary>
        /// 异步更新用户信息表(sys_user)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysUser sysUser)
        {
            //SysUser entity = await _sysUserService.GetByIdAsync(sysUser.id);
            //Utils.CommmonUtils.EntityToEntity(sysUser, entity, null);
            //return new ResponseMessage<int> { data = await _sysUserService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysUserService.UpdateAsync(sysUser) };
        }

        ///<summary>
        /// 根据Id查询用户信息表(sys_user)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysUser> GetById(long id)
        {
            var sysUser = _sysUserService.GetById(id);
            return new ResponseMessage<SysUser> {  data = sysUser };
        }

        ///<summary>
        /// 根据Id查询用户信息表(sys_user)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysUser>> GetByIdAsync(long id)
        {
            var sysUser =await _sysUserService.GetByIdAsync(id);
            return new ResponseMessage<SysUser>{ data = sysUser};
        }

        ///<summary>
        /// 根据条件查询用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysUser>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysUserRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysUser>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysUser>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _sysUserRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysUser>> { data = list };
        }

        ///<summary>
        /// 根据分页查询用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysUser>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _sysUserRepository.GetRecord(reqMsg);
            var list = _sysUserRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysUser>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysUser>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _sysUserRepository.GetRecordAsync(reqMsg);
            var list =await _sysUserRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysUser>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysUserService.QueryDataRecord(reqMsg);
            var list = _sysUserService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysUserService.QueryDataRecordAsync(reqMsg);
            var list = await _sysUserService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


        ///<summary>
        /// 根据部门、分页和名称状态查询岗位信息表(sys_job)
        ///</summary>
        [HttpPost]
        public ResponseMessage<object> QueryDataByDept([FromBody]QueryByDeptRequest reqMsg)
        {
            List<object> reslst = new List<object>();
            //var total = _sysUserService.QueryDataByDept(reqMsg.name, reqMsg.enabled, reqMsg.dept);
            //var list = _sysUserService.QueryDataByDeptByPage(reqMsg.name, reqMsg.enabled, reqMsg.dept, reqMsg.OrderBy, reqMsg.limit, reqMsg.offset);
            //foreach (var item in list)
            //{
            //    var org = _sysUserService.GetById(long.Parse(item.org_id));
            //    Object deptobj = new
            //    {
            //        id = org.id,
            //        name = org.org_name,
            //        enabled = org.dept_type,
            //        pid = (long)org.parent_id,
            //        createTime = org.created_time.ToString(),
            //        label = org.org_name
            //    };
            //    Object obj = new
            //    {
            //        id = item.id,
            //        sort = item.sort,
            //        name = item.job_name,
            //        enabled = item.is_enable,
            //        dept = deptobj,
            //        deptSuperiorName = org.org_name,
            //        createTime = item.created_time.ToString()
            //    };
            //    reslst.Add(obj);
            //}
            return new ResponseMessage<object> { data = new { content = reslst, totalElements = 1 } };
        }

    }
}

