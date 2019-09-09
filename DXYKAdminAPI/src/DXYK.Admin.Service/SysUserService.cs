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
    /// 系统管理-用户信息表
    ///</summary>
    public class SysUserService
    {

        ///<summary>
        ///SysUserService 仓储
        ///</summary>
        public ISysUserRepository SysUserRepository { get; }

        ///<summary>
        ///SysUserService 构造函数
        ///</summary>
        public SysUserService(ISysUserRepository sysUserRepository)
        {
            SysUserRepository = sysUserRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public long Insert(SysUser sysUser)
        {
            return SysUserRepository.Insert(sysUser);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public async Task<long> InsertAsync(SysUser sysUser)
        {
            return await SysUserRepository.InsertAsync(sysUser);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysUserRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public async Task<int> DeleteByIdAsync(long id)
        {
            return await SysUserRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysUser sysUser)
        {
            return SysUserRepository.Update(sysUser);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysUser sysUser)
        {
            return await SysUserRepository.UpdateAsync(sysUser);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysUser GetById(long id)
        {
            return SysUserRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysUser> GetByIdAsync(long id)
        {
            return await SysUserRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysUserRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysUserRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysUserRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysUserRepository.QueryDataByPageAsync(param);
        }



    }
}

