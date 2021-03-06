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
using DXYK.Admin.API.Filters;
using DXYK.Admin.Common.EnumHelper;

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
        [HttpPost, ApiAuthorize(ActionCode = "Admin,User_Manage,User_Add", LogType = LogEnum.ADD)]
        public ResponseMessage<string> Insert([FromBody]SysUser sysUser)
        {
            return new ResponseMessage<string> { data = _sysUserService.Insert(sysUser) }; 
        }

        ///<summary>
        /// 异步新增用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<string>>InsertAsync([FromBody]SysUser sysUser)
        {
            return new ResponseMessage<string> { data = await _sysUserService.InsertAsync(sysUser) };
        }

        ///<summary>
        /// 删除用户信息表(sys_user)
        ///</summary>
        [HttpDelete, ApiAuthorize(ActionCode = "Admin,User_Manage,User_Delete", LogType = LogEnum.DELETE)]
        public ResponseMessage<int> DeleteById(string id)
        {
            return new ResponseMessage<int> { data =  _sysUserService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除用户信息表(sys_user)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(string id)
        {
            return new ResponseMessage<int> { data = await _sysUserService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新用户信息表(sys_user)
        ///</summary>
        [HttpPut, ApiAuthorize(ActionCode = "Admin,User_Manage,User_Update", LogType = LogEnum.UPDATE)]
        public ResponseMessage<int> Update([FromBody]SysUser sysUser)
        {
            SysUser entity = _sysUserService.GetById(sysUser.id);
            Utils.CommmonUtils.EntityToEntity(sysUser, entity, null);
            return new ResponseMessage<int> { data = _sysUserService.Update(entity) };
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
        public ResponseMessage<SysUser> GetById(string id)
        {
            var sysUser = _sysUserService.GetById(id);
            return new ResponseMessage<SysUser> {  data = sysUser };
        }

        ///<summary>
        /// 根据Id查询用户信息表(sys_user)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysUser>> GetByIdAsync(string id)
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
        public ResponseMessage<object> QueryDataByDept([FromBody]QueryByPageWithDeptRequest reqMsg)
        {
            List<UserInfoResult> reslst = new List<UserInfoResult>();
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
                keyWords = reqMsg.keyWords,
                limit = reqMsg.limit,
                page = reqMsg.page
            });
            var list = _sysUserService.QueryDataByPage(new QueryByPageRequest()
            {
                keyWords = reqMsg.keyWords,
                limit = reqMsg.limit,
                page = reqMsg.page
            });
            if(reqMsg.dept != null)
            {
                string dept = reqMsg.dept;
                list = list.Where(t => t.org_id == dept).ToList();
            }
            foreach (var item in list)
            {
                var deptobj = new
                {
                    id = "",
                    name = ""
                };
                if (!string.IsNullOrEmpty(item.org_id))
                {
                    var org = _sysOrgService.GetById(item.org_id);
                    deptobj = new
                    {
                        id = org.id,
                        name = org.org_name
                    };
                }
                var jobobj = new
                {
                    id = "",
                    name = ""
                };
                if (!string.IsNullOrEmpty(item.job_id))
                {
                    var job = _sysJobService.GetById(item.job_id);
                    jobobj = new
                    {
                        id = job.id,
                        name = job.job_name
                    };
                }
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
                UserInfoResult resitem = new UserInfoResult
                {
                    user = item,
                    dept = deptobj,
                    job = jobobj,
                    role = roleobjs
                };
                reslst.Add(resitem);
            }
            return new ResponseMessage<object> { data = new { content = reslst, totalElements = total } };
        }

        ///<summary>
        /// 根据Id查询用户信息表(sys_user)
        ///</summary>
        [HttpGet]
        public ResponseMessage<object> QueryContacts()
        {
            List<object> reslst = new List<object>();
            var userlst = _sysUserService.GetAll();
            foreach (var item in userlst)
            {
                object obj = new
                {
                    show = item.nick_name + "<" + item.email + ">",
                    id = item.id + "#" + item.nick_name
                };
                reslst.Add(obj);
            }
            return new ResponseMessage<object> { data = new { contacts = reslst }};
        }

        ///<summary>
        /// 修改密码
        ///</summary>
        [HttpPost]
        public ResponseMessage<object> updatePass([FromBody]UpdatePassRequest reqMsg)
        {
            var sysUser = _sysUserService.GetById(reqMsg.id);
            if (reqMsg.oldPass != sysUser.login_pwd)
            {
                return new ResponseMessage<object> { data = new { result = "false", content = "旧密码错误" } };
            }
            else
            {
                sysUser.login_pwd = reqMsg.newPass;
                _sysUserService.Update(sysUser);
                return new ResponseMessage<object> { data = new { result = "true", content = "旧密码错误" } };
            }
        }

        /// <summary>
        /// 用户概要信息
        /// </summary>
        public class UserInfoResult
        {
            /// <summary>
            /// 用户
            /// </summary>
            public SysUser user { get; set; }
            /// <summary>
            /// 部门
            /// </summary>
            public object dept { get; set; }
            /// <summary>
            /// 岗位
            /// </summary>
            public object job { get; set; }
            /// <summary>
            /// 角色
            /// </summary>
            public object role { get; set; }
        }

        /// <summary>
        /// 分页查询请求带查询参数
        /// </summary>
        public class QueryByPageWithDeptRequest : QueryByPageRequest
        {
            /// <summary>
            /// 应用
            /// </summary>
            public string app { get; set; }
            /// <summary>
            /// 部门
            /// </summary>
            public string dept { get; set; }
        }

        /// <summary>
        /// 改密参数
        /// </summary>
        public class UpdatePassRequest
        {
            /// <summary>
            /// id
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 旧密码
            /// </summary>
            public string oldPass { get; set; }
            /// <summary>
            /// 新密码
            /// </summary>
            public string newPass { get; set; }
        }

    }
}

