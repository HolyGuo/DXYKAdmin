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
    /// 角色信息表
    ///</summary>
    public interface ISysAppRoleRepository : IRepository<SysAppRole, long>
        , IRepositoryAsync<SysAppRole, long>
    {

        ///<summary>
        /// 根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new SysAppRole GetById([Param("id")]long id);
        ///<summary>
        /// 异步根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new Task<SysAppRole> GetByIdAsync([Param("id")]long id);
        ///<summary>
        /// 删除数据
        ///</summary>
        [Statement(Id = "Delete")]
        new int DeleteById([Param("id")]long id);
        ///<summary>
        /// 异步删除数据
        ///</summary>
        [Statement(Id = "Delete")]
        new Task<int> DeleteByIdAsync([Param("id")]long id);
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
        List<SysAppRole> QueryDataByPage(object param);
        ///<summary>
        /// 异步根据条件进行分页查询
        ///</summary>
        [Statement(Id = "QueryDataByPage")]
        Task<List<object>> QueryDataByPageAsync(object param);
    }
}

