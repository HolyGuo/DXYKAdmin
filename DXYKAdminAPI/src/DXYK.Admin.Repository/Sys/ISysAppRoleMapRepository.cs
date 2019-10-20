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
    /// 角色授权表
    ///</summary>
    public interface ISysAppRoleMapRepository : IRepository<SysAppRoleMap, long>
        , IRepositoryAsync<SysAppRoleMap, long>
    {
        ///<summary>
        /// 新增
        ///</summary>
        [Statement(Id = "Insert")]
        string Insert(object param);

        ///<summary>
        /// 异步新增
        ///</summary>
        [Statement(Id = "Insert")]
        new Task<string> InsertAsync(object param);

        ///<summary>
        /// 根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new SysAppRoleMap GetById([Param("id")]long id);
        ///<summary>
        /// 异步根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new Task<SysAppRoleMap> GetByIdAsync([Param("id")]long id);
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
        List<object> QueryDataByPage(object param);
        ///<summary>
        /// 异步根据条件进行分页查询
        ///</summary>
        [Statement(Id = "QueryDataByPage")]
        Task<List<object>> QueryDataByPageAsync(object param);
        ///<summary>
        /// 根据角色id查询
        ///</summary>
        [Statement(Id = "QueryDataByRole")]
        List<SysAppRoleMap> QueryDataByRole([Param("role_id")]long role_id, [Param("type_code")]int type_code);
        ///<summary>
        /// 根据roleid,mapid,type查询
        ///</summary>
        [Statement(Id = "GetByFilter")]
        List<SysAppRoleMap> GetByFilter([Param("role_id")]long role_id, [Param("map_id")]long map_id, [Param("type_code")]int type_code);
    }
}

