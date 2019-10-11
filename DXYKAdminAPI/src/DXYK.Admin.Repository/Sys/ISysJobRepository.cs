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
    /// 岗位信息表
    ///</summary>
    public interface ISysJobRepository : IRepository<SysJob, long>
        , IRepositoryAsync<SysJob, long>
    {

        ///<summary>
        /// 根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new SysJob GetById([Param("id")]string id);
        ///<summary>
        /// 异步根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new Task<SysJob> GetByIdAsync([Param("id")]long id);
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
        /// 根据名称和状态获取数据列
        ///</summary>
        [Statement(Id = "QueryDataByNameAndTypeByPage")]
        List<SysJob> QueryDataByNameAndTypeByPage([Param("job_name")]string job_name, [Param("is_enable")]string is_enable, [Param("OrderBy")]string OrderBy,
            [Param("limit")]int limit, [Param("offset")]int offset);
        ///<summary>
        /// 根据名称和状态获取数据列
        ///</summary>
        [Statement(Id = "QueryDataByNameAndType")]
        int QueryDataByNameAndType([Param("job_name")]string job_name, [Param("is_enable")]string is_enable);
    }
}

