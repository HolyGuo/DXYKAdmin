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
    /// 单位信息表
    ///</summary>
    public interface ISysOrgRepository : IRepository<SysOrg, long>
        , IRepositoryAsync<SysOrg, long>
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
        SysOrg GetById([Param("id")]string id);
        ///<summary>
        /// 异步根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        Task<SysOrg> GetByIdAsync([Param("id")]string id);
        ///<summary>
        /// 删除数据
        ///</summary>
        [Statement(Id = "Delete")]
        int DeleteById([Param("id")]string id);
        ///<summary>
        /// 异步删除数据
        ///</summary>
        [Statement(Id = "Delete")]
        Task<int> DeleteByIdAsync([Param("id")]string id);
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
        /// 获取所有信息
        ///</summary>
        [Statement(Id = "QueryAll")]
        List<SysOrg> GetAll();
        ///<summary>
        /// 根据名称和状态获取数据列
        ///</summary>
        [Statement(Id = "QueryDataByNameAndType")]
        List<SysOrg> QueryDataByNameAndType([Param("org_name")]string org_name, [Param("dept_type")]string dept_type);
    }
}

