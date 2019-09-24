//*******************************
// Create By Holy Guo
// Date 2019-09-12 15:48
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
    /// 群组信息表
    ///</summary>
    public class SysGroupService
    {

        ///<summary>
        ///SysGroupService 仓储
        ///</summary>
        public ISysGroupRepository SysGroupRepository { get; }

        ///<summary>
        ///SysGroupService 构造函数
        ///</summary>
        public SysGroupService(ISysGroupRepository sysGroupRepository)
        {
            SysGroupRepository = sysGroupRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public long Insert(SysGroup sysGroup)
        {
            return SysGroupRepository.Insert(sysGroup);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public async Task<long> InsertAsync(SysGroup sysGroup)
        {
            return await SysGroupRepository.InsertAsync(sysGroup);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysGroupRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public async Task<int> DeleteByIdAsync(long id)
        {
            return await SysGroupRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysGroup sysGroup)
        {
            return SysGroupRepository.Update(sysGroup);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysGroup sysGroup)
        {
            return await SysGroupRepository.UpdateAsync(sysGroup);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysGroup GetById(long id)
        {
            return SysGroupRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysGroup> GetByIdAsync(long id)
        {
            return await SysGroupRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysGroupRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysGroupRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysGroupRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysGroupRepository.QueryDataByPageAsync(param);
        }



    }
}

