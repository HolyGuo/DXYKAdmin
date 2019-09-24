//*******************************
// Create By Holy Guo
// Date 2019-09-12 16:15
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
    public class SysAppMenuActionService
    {

        ///<summary>
        ///SysAppMenuActionService 仓储
        ///</summary>
        public ISysAppMenuActionRepository SysAppMenuActionRepository { get; }

        ///<summary>
        ///SysAppMenuActionService 构造函数
        ///</summary>
        public SysAppMenuActionService (ISysAppMenuActionRepository sysAppMenuActionRepository)
        {
            SysAppMenuActionRepository = sysAppMenuActionRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public long Insert(SysAppMenuAction sysAppMenuAction)
        {
            return SysAppMenuActionRepository.Insert(sysAppMenuAction);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<long> InsertAsync(SysAppMenuAction sysAppMenuAction)
        {
            return await SysAppMenuActionRepository.InsertAsync(sysAppMenuAction);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysAppMenuActionRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(long id)
        {
            return await SysAppMenuActionRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysAppMenuAction sysAppMenuAction)
        {
            return SysAppMenuActionRepository.Update(sysAppMenuAction);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysAppMenuAction sysAppMenuAction)
        {
            return await SysAppMenuActionRepository.UpdateAsync(sysAppMenuAction);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysAppMenuAction GetById(long id)
        {
            return SysAppMenuActionRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysAppMenuAction> GetByIdAsync(long id)
        {
            return await SysAppMenuActionRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysAppMenuActionRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysAppMenuActionRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysAppMenuActionRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysAppMenuActionRepository.QueryDataByPageAsync(param);
        }



    }
}

