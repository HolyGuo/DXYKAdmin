//*******************************
// Create By Holy Guo
// Date 2019-10-06 22:21
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
        /// 功能信息表
        ///</summary>
    public class SysAppActionService
    {

        ///<summary>
        ///SysAppActionService 仓储
        ///</summary>
        public ISysAppActionRepository SysAppActionRepository { get; }

        ///<summary>
        ///SysAppActionService 构造函数
        ///</summary>
        public SysAppActionService (ISysAppActionRepository sysAppActionRepository)
        {
            SysAppActionRepository = sysAppActionRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public long Insert(SysAppAction sysAppAction)
        {
            return SysAppActionRepository.Insert(sysAppAction);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<long> InsertAsync(SysAppAction sysAppAction)
        {
            return await SysAppActionRepository.InsertAsync(sysAppAction);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(string id)
        {
            return SysAppActionRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(string id)
        {
            return await SysAppActionRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysAppAction sysAppAction)
        {
            return SysAppActionRepository.Update(sysAppAction);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysAppAction sysAppAction)
        {
            return await SysAppActionRepository.UpdateAsync(sysAppAction);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysAppAction GetById(string id)
        {
            return SysAppActionRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysAppAction> GetByIdAsync(string id)
        {
            return await SysAppActionRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysAppActionRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysAppActionRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysAppActionRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysAppActionRepository.QueryDataByPageAsync(param);
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        public List<SysAppAction> GetAll(string name)
        {
            return SysAppActionRepository.GetAll(name);
        }



    }
}

