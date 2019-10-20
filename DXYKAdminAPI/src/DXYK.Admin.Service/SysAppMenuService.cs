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
    /// 菜单信息表
    ///</summary>
    public class SysAppMenuService
    {

        ///<summary>
        ///SysAppMenuService 仓储
        ///</summary>
        public ISysAppMenuRepository SysAppMenuRepository { get; }

        ///<summary>
        ///SysAppMenuService 构造函数
        ///</summary>
        public SysAppMenuService(ISysAppMenuRepository sysAppMenuRepository)
        {
            SysAppMenuRepository = sysAppMenuRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public string Insert(SysAppMenu sysAppMenu)
        {
            return SysAppMenuRepository.Insert(sysAppMenu);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public async Task<string> InsertAsync(SysAppMenu sysAppMenu)
        {
            return await SysAppMenuRepository.InsertAsync(sysAppMenu);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysAppMenuRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public async Task<int> DeleteByIdAsync(long id)
        {
            return await SysAppMenuRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysAppMenu sysAppMenu)
        {
            return SysAppMenuRepository.Update(sysAppMenu);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysAppMenu sysAppMenu)
        {
            return await SysAppMenuRepository.UpdateAsync(sysAppMenu);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysAppMenu GetById(long id)
        {
            return SysAppMenuRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysAppMenu> GetByIdAsync(long id)
        {
            return await SysAppMenuRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysAppMenuRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysAppMenuRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysAppMenuRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysAppMenuRepository.QueryDataByPageAsync(param);
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        public List<SysAppMenu> GetAll(string name)
        {
            return SysAppMenuRepository.GetAll(name);
        }

    }
}

