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
        /// 角色授权表
        ///</summary>
    public class SysAppRoleMapService
    {

        ///<summary>
        ///SysAppRoleMapService 仓储
        ///</summary>
        public ISysAppRoleMapRepository SysAppRoleMapRepository { get; }

        ///<summary>
        ///SysAppRoleMapService 构造函数
        ///</summary>
        public SysAppRoleMapService (ISysAppRoleMapRepository sysAppRoleMapRepository)
        {
            SysAppRoleMapRepository = sysAppRoleMapRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public string Insert(SysAppRoleMap sysAppRoleMap)
        {
            return SysAppRoleMapRepository.Insert(sysAppRoleMap);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<string> InsertAsync(SysAppRoleMap sysAppRoleMap)
        {
            return await SysAppRoleMapRepository.InsertAsync(sysAppRoleMap);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(string id)
        {
            return SysAppRoleMapRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(string id)
        {
            return await SysAppRoleMapRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysAppRoleMap sysAppRoleMap)
        {
            return SysAppRoleMapRepository.Update(sysAppRoleMap);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysAppRoleMap sysAppRoleMap)
        {
            return await SysAppRoleMapRepository.UpdateAsync(sysAppRoleMap);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysAppRoleMap GetById(string id)
        {
            return SysAppRoleMapRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysAppRoleMap> GetByIdAsync(string id)
        {
            return await SysAppRoleMapRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysAppRoleMapRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysAppRoleMapRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysAppRoleMapRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysAppRoleMapRepository.QueryDataByPageAsync(param);
        }

        /// <summary>
        /// 根据角色id查询
        /// </summary>
        public List<SysAppRoleMap> QueryDataByRole(string roleid, int type)
        {
            return SysAppRoleMapRepository.QueryDataByRole(roleid, type);
        }

        /// <summary>
        /// 根据roleid,mapid,type查询
        /// </summary>
        public List<SysAppRoleMap> GetByFilter(string roleid, string mapid, int type)
        {
            return SysAppRoleMapRepository.GetByFilter(roleid, mapid, type);
        }

    }
}

