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
using System.Linq;

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
        /// 角色信息表(sys_app_role) Service
        ///</summary>
        public SysAppRoleService _sysAppRoleService { get; }

        ///<summary>
        /// 单位信息表(sys_org) Service
        ///</summary>
        public SysOrgService _sysOrgService { get; }

        ///<summary>
        /// 岗位信息表(sys_job) Service
        ///</summary>
        public SysJobService _sysJobService { get; }

        ///<summary>
        /// 用户应用角色授权表(sys_user_app_role) Service
        ///</summary>
        public SysUserAppRoleService _sysUserAppRoleService { get; }

        ///<summary>
        /// sys_userController
        ///</summary>
        public SysUserController(SysUserService sysUserService, ISysUserRepository sysUserRepository, SysAppRoleService sysAppRoleService, SysOrgService sysOrgService,
            SysJobService sysJobService, SysUserAppRoleService sysUserAppRoleService)
        {
            _sysUserService = sysUserService;
            _sysUserRepository = sysUserRepository;
            _sysAppRoleService = sysAppRoleService;
            _sysOrgService = sysOrgService;
            _sysJobService = sysJobService;
            _sysUserAppRoleService = sysUserAppRoleService;
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
        public ResponseMessage<object> QueryDataByDept([FromBody]QueryByFilterRequest reqMsg)
        {
            List<object> reslst = new List<object>();
            var rolemaps = _sysUserAppRoleService.QueryDataByPage(new QueryByPageRequest()
            {
                limit = 10000,
                page = 1
            });
            var roles = _sysAppRoleService.QueryDataByPage(new QueryByPageRequest() { 
                limit = 10000,
                page = 1
            });
            var total = _sysUserService.QueryDataRecord(new QueryByPageRequest()
            {
                limit = 10000,
                page = 1
            });
            var list = _sysUserService.QueryDataByPage(new QueryByPageRequest()
            {
                limit = 10000,
                page = 1
            });
            if(reqMsg.dept != null)
            {
                long dept = long.Parse(reqMsg.dept);
                list = list.Where(t => t.org_id == dept).ToList();
            }
            foreach (var item in list)
            {
                var org = _sysOrgService.GetById((long)item.org_id);
                Object deptobj = new
                {
                    id = org.id,
                    name = org.org_name
                };
                var job = _sysJobService.GetById(item.job_id.ToString());
                Object jobobj = new
                {
                    id = job.id,
                    name = job.job_name
                };
                var approlemaps = rolemaps.Where(t => t.app_id == reqMsg.app && t.user_id == item.id).ToList();
                List<object> roleobjs = new List<object>();
                foreach (var rolemapitem in approlemaps)
                {
                    var rolename = roles.Where(t => t.id == rolemapitem.role_id).ToList()[0].role_code;
                    Object roleobj = new
                    {
                        id = rolemapitem.role_id,
                        name = rolename
                    };
                    roleobjs.Add(roleobj);
                }
                Object obj = new
                {
                    id = item.id,
                    username = item.nick_name,
                    email = item.email,
                    phone = item.telephone,
                    enabled = item.is_enable,
                    createTime = item.created_time.ToString(),
                    roles = roleobjs,
                    job = jobobj,
                    dept = deptobj
                };
                reslst.Add(obj);
            }
            return new ResponseMessage<object> { data = new { content = reslst, totalElements = 1 } };
        }

        /// <summary>
        /// 分页查询名称状态请求
        /// </summary>
        public class QueryByFilterRequest : QueryNameByPageRequest
        {
            /// <summary>
            /// 应用字段
            /// </summary>
            public string app { get; set; }
            /// <summary>
            /// 部门字段
            /// </summary>
            public string dept { get; set; }
        }
    }
}

