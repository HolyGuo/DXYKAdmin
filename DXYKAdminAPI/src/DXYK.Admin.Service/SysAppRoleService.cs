//*******************************
// Create By Holy Guo
// Date 2019-10-03 09:12
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
        /// 角色信息表
        ///</summary>
    public class SysAppRoleService
    {

        ///<summary>
        ///SysAppRoleService 仓储
        ///</summary>
        public ISysAppRoleRepository SysAppRoleRepository { get; }

        ///<summary>
        ///SysAppRoleService 构造函数
        ///</summary>
        public SysAppRoleService (ISysAppRoleRepository sysAppRoleRepository)
        {
            SysAppRoleRepository = sysAppRoleRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public string Insert(SysAppRole sysAppRole)
        {
            return SysAppRoleRepository.Insert(sysAppRole);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<string> InsertAsync(SysAppRole sysAppRole)
        {
            return await SysAppRoleRepository.InsertAsync(sysAppRole);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysAppRoleRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(long id)
        {
            return await SysAppRoleRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysAppRole sysAppRole)
        {
            return SysAppRoleRepository.Update(sysAppRole);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysAppRole sysAppRole)
        {
            return await SysAppRoleRepository.UpdateAsync(sysAppRole);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysAppRole GetById(long id)
        {
            return SysAppRoleRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysAppRole> GetByIdAsync(long id)
        {
            return await SysAppRoleRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysAppRoleRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysAppRoleRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<SysAppRole> QueryDataByPage(object param)
        {
            return SysAppRoleRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysAppRoleRepository.QueryDataByPageAsync(param);
        }



    }
}

