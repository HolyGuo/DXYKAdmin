//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System;
using System.Linq;
using System.Threading.Tasks;
using DXYK.Admin.Entity;
using DXYK.Admin.Repository;

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



    }
}

