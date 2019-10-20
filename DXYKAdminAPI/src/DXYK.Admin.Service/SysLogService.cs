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
        /// 系统日志表
        ///</summary>
    public class SysLogService
    {

        ///<summary>
        ///SysLogService 仓储
        ///</summary>
        public ISysLogRepository SysLogRepository { get; }

        ///<summary>
        ///SysLogService 构造函数
        ///</summary>
        public SysLogService (ISysLogRepository sysLogRepository)
        {
            SysLogRepository = sysLogRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public string Insert(SysLog sysLog)
        {
            return SysLogRepository.Insert(sysLog);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<string> InsertAsync(SysLog sysLog)
        {
            return await SysLogRepository.InsertAsync(sysLog);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysLogRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(long id)
        {
            return await SysLogRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysLog sysLog)
        {
            return SysLogRepository.Update(sysLog);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysLog sysLog)
        {
            return await SysLogRepository.UpdateAsync(sysLog);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysLog GetById(long id)
        {
            return SysLogRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysLog> GetByIdAsync(long id)
        {
            return await SysLogRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysLogRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysLogRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysLogRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysLogRepository.QueryDataByPageAsync(param);
        }



    }
}

