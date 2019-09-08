//*******************************
// Create By Holy Guo
// Date 2019-09-08 14:52
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
    /// 系统管理-单位信息表
    ///</summary>
    public class SysDeptService
    {

        ///<summary>
        ///SysDeptService 仓储
        ///</summary>
        public ISysDeptRepository SysDeptRepository { get; }

        ///<summary>
        ///SysDeptService 构造函数
        ///</summary>
        public SysDeptService(ISysDeptRepository sysDeptRepository)
        {
            SysDeptRepository = sysDeptRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public long Insert(SysDept sysDept)
        {
            return SysDeptRepository.Insert(sysDept);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public async Task<long> InsertAsync(SysDept sysDept)
        {
            return await SysDeptRepository.InsertAsync(sysDept);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysDeptRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public async Task<int> DeleteByIdAsync(long id)
        {
            return await SysDeptRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysDept sysDept)
        {
            return SysDeptRepository.Update(sysDept);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysDept sysDept)
        {
            return await SysDeptRepository.UpdateAsync(sysDept);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysDept GetById(long id)
        {
            return SysDeptRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysDept> GetByIdAsync(long id)
        {
            return await SysDeptRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysDeptRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysDeptRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysDeptRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysDeptRepository.QueryDataByPageAsync(param);
        }



    }
}

