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
        /// 角色授权菜单表
        ///</summary>
    public class SysAppRoleMenuService
    {

        ///<summary>
        ///SysAppRoleMenuService 仓储
        ///</summary>
        public ISysAppRoleMenuRepository SysAppRoleMenuRepository { get; }

        ///<summary>
        ///SysAppRoleMenuService 构造函数
        ///</summary>
        public SysAppRoleMenuService (ISysAppRoleMenuRepository sysAppRoleMenuRepository)
        {
            SysAppRoleMenuRepository = sysAppRoleMenuRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public long Insert(SysAppRoleMenu sysAppRoleMenu)
        {
            return SysAppRoleMenuRepository.Insert(sysAppRoleMenu);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<long> InsertAsync(SysAppRoleMenu sysAppRoleMenu)
        {
            return await SysAppRoleMenuRepository.InsertAsync(sysAppRoleMenu);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysAppRoleMenuRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(long id)
        {
            return await SysAppRoleMenuRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysAppRoleMenu sysAppRoleMenu)
        {
            return SysAppRoleMenuRepository.Update(sysAppRoleMenu);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysAppRoleMenu sysAppRoleMenu)
        {
            return await SysAppRoleMenuRepository.UpdateAsync(sysAppRoleMenu);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysAppRoleMenu GetById(long id)
        {
            return SysAppRoleMenuRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysAppRoleMenu> GetByIdAsync(long id)
        {
            return await SysAppRoleMenuRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysAppRoleMenuRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysAppRoleMenuRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysAppRoleMenuRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysAppRoleMenuRepository.QueryDataByPageAsync(param);
        }



    }
}

