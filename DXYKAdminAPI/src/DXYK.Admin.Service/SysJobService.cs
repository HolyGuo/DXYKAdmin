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
        /// 岗位信息表
        ///</summary>
    public class SysJobService
    {

        ///<summary>
        ///SysJobService 仓储
        ///</summary>
        public ISysJobRepository SysJobRepository { get; }

        ///<summary>
        ///SysJobService 构造函数
        ///</summary>
        public SysJobService (ISysJobRepository sysJobRepository)
        {
            SysJobRepository = sysJobRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public string Insert(SysJob sysJob)
        {
            return SysJobRepository.Insert(sysJob);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<string> InsertAsync(SysJob sysJob)
        {
            return await SysJobRepository.InsertAsync(sysJob);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(string id)
        {
            return SysJobRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(string id)
        {
            return await SysJobRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysJob sysJob)
        {
            return SysJobRepository.Update(sysJob);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysJob sysJob)
        {
            return await SysJobRepository.UpdateAsync(sysJob);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysJob GetById(string id)
        {
            return SysJobRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysJob> GetByIdAsync(string id)
        {
            return await SysJobRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysJobRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysJobRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysJobRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysJobRepository.QueryDataByPageAsync(param);
        }

        /// <summary>
        /// 根据名称和状态获取数据列
        /// </summary>
        public List<SysJob> QueryDataByNameAndTypeByPage(string name, string enable, string dept, string OrderBy, int limit, int offset)
        {
            return SysJobRepository.QueryDataByNameAndTypeByPage(name, enable, dept, OrderBy, limit, offset);
        }

        /// <summary>
        /// 根据名称和状态获取数据列总数
        /// </summary>
        public int QueryDataByNameAndType(string name, string enable, string dept)
        {
            return SysJobRepository.QueryDataByNameAndType(name, enable, dept);
        }



    }
}

