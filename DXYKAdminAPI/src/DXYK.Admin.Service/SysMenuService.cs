//*******************************
// Create By Holy Guo
// Date 2019-09-08 14:52
//*******************************
using DXYK.Admin.Entity;
using DXYK.Admin.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DXYK.Admin.Service
{
    ///<summary>
    /// 系统管理-菜单信息表
    ///</summary>
    public class SysMenuService
    {

        ///<summary>
        ///SysMenuService 仓储
        ///</summary>
        public ISysMenuRepository SysMenuRepository { get; }

        ///<summary>
        ///SysMenuService 构造函数
        ///</summary>
        public SysMenuService(ISysMenuRepository sysMenuRepository)
        {
            SysMenuRepository = sysMenuRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public long Insert(SysMenu sysMenu)
        {
            return SysMenuRepository.Insert(sysMenu);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public async Task<long> InsertAsync(SysMenu sysMenu)
        {
            return await SysMenuRepository.InsertAsync(sysMenu);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysMenuRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public async Task<int> DeleteByIdAsync(long id)
        {
            return await SysMenuRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysMenu sysMenu)
        {
            return SysMenuRepository.Update(sysMenu);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysMenu sysMenu)
        {
            return await SysMenuRepository.UpdateAsync(sysMenu);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysMenu GetById(long id)
        {
            return SysMenuRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysMenu> GetByIdAsync(long id)
        {
            return await SysMenuRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysMenuRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysMenuRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysMenuRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysMenuRepository.QueryDataByPageAsync(param);
        }



    }
}

