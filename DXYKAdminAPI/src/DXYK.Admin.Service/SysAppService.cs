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
        /// 应用信息表
        ///</summary>
    public class SysAppService
    {

        ///<summary>
        ///SysAppService 仓储
        ///</summary>
        public ISysAppRepository SysAppRepository { get; }

        ///<summary>
        ///SysAppService 构造函数
        ///</summary>
        public SysAppService (ISysAppRepository sysAppRepository)
        {
            SysAppRepository = sysAppRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public string Insert(SysApp sysApp)
        {
            return SysAppRepository.Insert(sysApp);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<string> InsertAsync(SysApp sysApp)
        {
            return await SysAppRepository.InsertAsync(sysApp);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(string id)
        {
            return SysAppRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(string id)
        {
            return await SysAppRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysApp sysApp)
        {
            return SysAppRepository.Update(sysApp);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysApp sysApp)
        {
            return await SysAppRepository.UpdateAsync(sysApp);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysApp GetById(string id)
        {
            return SysAppRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysApp> GetByIdAsync(string id)
        {
            return await SysAppRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysAppRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysAppRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysAppRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysAppRepository.QueryDataByPageAsync(param);
        }


    }
}

