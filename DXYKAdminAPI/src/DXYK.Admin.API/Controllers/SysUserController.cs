//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
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
        /// 系统管理-用户信息表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysUserController : Controller
    {
        ///<summary>
        /// 系统管理-用户信息表(sys_user) Service
        ///</summary>
        public SysUserService SysUserService { get; }

        ///<summary>
        /// 系统管理-用户信息表(sys_user) Repository
        ///</summary>
        public ISysUserRepository SysUserRepository { get; }

        ///<summary>
        /// sys_userController
        ///</summary>
        public SysUserController(SysUserService sysUserService, ISysUserRepository sysUserRepository)
        {
            SysUserService = sysUserService;
            SysUserRepository = sysUserRepository;
        }

        ///<summary>
        /// 新增系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<long> Insert([FromBody]SysUser sysUser)
        {
            return new ResponseMessageWrap<long>{ data = SysUserService.Insert(sysUser) };
        }

        ///<summary>
        /// 异步新增系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<long>> InsertAsync([FromBody]SysUser sysUser)
        {
            return new ResponseMessageWrap<long>{ data = await SysUserService.InsertAsync(sysUser) };
        }

        ///<summary>
        /// 删除系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpDelete]
        public ResponseMessageWrap<int> DeleteById(long id)
        {
            return new ResponseMessageWrap<int>{ data = SysUserService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessageWrap<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessageWrap<int>{ data = await SysUserService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPut]
        public ResponseMessageWrap<int> Update([FromBody]SysUser sysUser)
        {
            return new ResponseMessageWrap<int>{ data = SysUserService.Update(sysUser) };
        }

        ///<summary>
        /// 异步更新系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessageWrap<int>> UpdateAsync([FromBody]SysUser sysUser)
        {
            return new ResponseMessageWrap<int>{ data =await SysUserService.UpdateAsync(sysUser) };
        }

        ///<summary>
        /// 根据Id查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpGet]
        public ResponseMessageWrap<SysUser> GetById(long id)
        {
            var sysUser = SysUserService.GetById(id);
            return new ResponseMessageWrap<SysUser>{ data = sysUser };
        }

        ///<summary>
        /// 根据Id查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessageWrap<SysUser>> GetByIdAsync(long id)
        {
            var sysUser =await SysUserService.GetByIdAsync(id);
            return new ResponseMessageWrap<SysUser>{data = sysUser};
        }

        ///<summary>
        /// 根据条件查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysUser>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = SysUserRepository.Query(reqMsg);
            return new ResponseMessageWrap<IList<SysUser>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysUser>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await SysUserRepository.QueryAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysUser>> { data = list };
        }

        ///<summary>
        /// 根据分页查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysUser>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = SysUserRepository.GetRecord(reqMsg);
            var list = SysUserRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysUser>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysUser>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await SysUserRepository.GetRecordAsync(reqMsg);
            var list =await SysUserRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysUser>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = SysUserRepository.QueryDataRecord(reqMsg);
            var list = SysUserRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询系统管理-用户信息表(sys_user)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await SysUserRepository.QueryDataRecordAsync(reqMsg);
            var list = await SysUserRepository.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }


    }
}

