//*******************************
// Create By Holy Guo
// Date 2019-10-20 13:31
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
    /// 收件人信息表
    ///</summary>
    public interface IOaMailReceiverRepository : IRepository<OaMailReceiver, string>
        , IRepositoryAsync<OaMailReceiver, string>
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
        Task<string> InsertAsync(object param);

        ///<summary>
        /// 根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new OaMailReceiver GetById([Param("id")]string id);
        ///<summary>
        /// 异步根据Id查询数据
        ///</summary>
        [Statement(Id = "GetEntity")]
        new Task<OaMailReceiver> GetByIdAsync([Param("id")]string id);
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
        /// 根据条件查询收件总数
        ///</summary>
        [Statement(Id = "QueryInDataRecord")]
        int QueryInDataRecord(object param);
        ///<summary>
        /// 根据条件查询收件信息
        ///</summary>
        [Statement(Id = "QueryInByFilter")]
        List<object> QueryInByFilter(object param);
        ///<summary>
        /// 根据邮件Id查询收件人信息
        ///</summary>
        [Statement(Id = "QueryByMailId")]
        List<object> QueryByMailId([Param("mail_id")]long mailid);
    }
}

