//*******************************
// Create By Holy Guo
// Date 2019-10-03 09:12
//*******************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using SmartSql.DyRepository;
using SmartSql.DyRepository.Annotations;
using DXYK.Admin.Entity;

namespace DXYK.Admin.Repository
{
    ///<summary>
    /// 用户信息表
    ///</summary>
    public interface ISysUserRepository : IRepository<SysUser, string>
        , IRepositoryAsync<SysUser, string>
    {
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <returns></returns>
        [Statement(Id = "Insert")]
        new string Insert(SysUser sysUser);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <returns></returns>
        [Statement(Id = "Insert")]
        new Task<string> InsertAsync(SysUser sysUser);

        ///<summary>
        /// 根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new SysUser GetById([Param("id")]string id);
        ///<summary>
        /// 异步根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new Task<SysUser> GetByIdAsync([Param("id")]string id);
        ///<summary>
        /// 删除数据
        ///</summary>
        [Statement(Id = "Delete")]
        new int DeleteById([Param("id")]string id);
        ///<summary>
        /// 异步删除数据
        ///</summary>
        [Statement(Id = "Delete")]
        new Task<int> DeleteByIdAsync([Param("id")]string id);
        ///<summary>
        /// 根据条件查询总数
        ///</summary>
        [Statement(Id = "GetDataRecord")]
        int QueryDataRecord(object param);
        ///<summary>
        /// 异步根据条件查询总数
        ///</summary>
        [Statement(Id = "GetDataRecord")]
        Task<int> QueryDataRecordAsync(object param);
        ///<summary>
        /// 根据条件进行分页查询
        ///</summary>
        [Statement(Id = "QueryDataByPage")]
        List<SysUser> QueryDataByPage(object param);
        ///<summary>
        /// 异步根据条件进行分页查询
        ///</summary>
        [Statement(Id = "QueryDataByPage")]
        Task<List<object>> QueryDataByPageAsync(object param);
        /// <summary>
        /// 查询所有
        /// </summary>
        [Statement(Id = "GetAll")]
        List<SysUser> GetAll();
    }
}

