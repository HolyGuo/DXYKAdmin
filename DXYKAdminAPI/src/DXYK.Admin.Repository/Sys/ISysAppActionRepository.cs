//*******************************
// Create By Holy Guo
// Date 2019-10-06 22:21
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
    /// 功能信息表
    ///</summary>
    public interface ISysAppActionRepository : IRepository<SysAppAction, string>
        , IRepositoryAsync<SysAppAction, string>
    {

        ///<summary>
        /// 根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new SysAppAction GetById([Param("id")]string id);
        ///<summary>
        /// 异步根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new Task<SysAppAction> GetByIdAsync([Param("id")]string id);
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
        List<SysAppAction> GetAll([Param("action_name")]string name);
    }
}

