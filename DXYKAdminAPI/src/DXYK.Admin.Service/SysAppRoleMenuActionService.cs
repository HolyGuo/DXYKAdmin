//*******************************
// Create By Holy Guo
// Date 2019-09-12 18:29
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
        /// 角色授权功能表
        ///</summary>
    public class SysAppRoleMenuActionService
    {

        ///<summary>
        ///SysAppRoleMenuActionService 仓储
        ///</summary>
        public ISysAppRoleMenuActionRepository SysAppRoleMenuActionRepository { get; }

        ///<summary>
        ///SysAppRoleMenuActionService 构造函数
        ///</summary>
        public SysAppRoleMenuActionService (ISysAppRoleMenuActionRepository sysAppRoleMenuActionRepository)
        {
            SysAppRoleMenuActionRepository = sysAppRoleMenuActionRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public long Insert(SysAppRoleMenuAction sysAppRoleMenuAction)
        {
            return SysAppRoleMenuActionRepository.Insert(sysAppRoleMenuAction);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<long> InsertAsync(SysAppRoleMenuAction sysAppRoleMenuAction)
        {
            return await SysAppRoleMenuActionRepository.InsertAsync(sysAppRoleMenuAction);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysAppRoleMenuActionRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(long id)
        {
            return await SysAppRoleMenuActionRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysAppRoleMenuAction sysAppRoleMenuAction)
        {
            return SysAppRoleMenuActionRepository.Update(sysAppRoleMenuAction);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysAppRoleMenuAction sysAppRoleMenuAction)
        {
            return await SysAppRoleMenuActionRepository.UpdateAsync(sysAppRoleMenuAction);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysAppRoleMenuAction GetById(long id)
        {
            return SysAppRoleMenuActionRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysAppRoleMenuAction> GetByIdAsync(long id)
        {
            return await SysAppRoleMenuActionRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysAppRoleMenuActionRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysAppRoleMenuActionRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysAppRoleMenuActionRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysAppRoleMenuActionRepository.QueryDataByPageAsync(param);
        }



    }
}

