//*******************************
// Create By Holy Guo
// Date 2019-10-06 17:28
//*******************************
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using DXYK.Admin.Entity;
using DXYK.Admin.Repository;

namespace DXYK.Admin.Service
{
    ///<summary>
        /// 用户应用角色授权表
        ///</summary>
    public class SysUserAppRoleService
    {

        ///<summary>
        ///SysUserAppRoleService 仓储
        ///</summary>
        public ISysUserAppRoleRepository SysUserAppRoleRepository { get; }

        ///<summary>
        ///SysUserAppRoleService 构造函数
        ///</summary>
        public SysUserAppRoleService (ISysUserAppRoleRepository sysUserAppRoleRepository)
        {
            SysUserAppRoleRepository = sysUserAppRoleRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public string Insert(SysUserAppRole sysUserAppRole)
        {
            return SysUserAppRoleRepository.Insert(sysUserAppRole);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<string> InsertAsync(SysUserAppRole sysUserAppRole)
        {
            return await SysUserAppRoleRepository.InsertAsync(sysUserAppRole);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysUserAppRoleRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(long id)
        {
            return await SysUserAppRoleRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysUserAppRole sysUserAppRole)
        {
            return SysUserAppRoleRepository.Update(sysUserAppRole);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysUserAppRole sysUserAppRole)
        {
            return await SysUserAppRoleRepository.UpdateAsync(sysUserAppRole);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysUserAppRole GetById(long id)
        {
            return SysUserAppRoleRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysUserAppRole> GetByIdAsync(long id)
        {
            return await SysUserAppRoleRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysUserAppRoleRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysUserAppRoleRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<SysUserAppRole> QueryDataByPage(object param)
        {
            return SysUserAppRoleRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysUserAppRoleRepository.QueryDataByPageAsync(param);
        }



    }
}

