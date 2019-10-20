//*******************************
// Create By Holy Guo
// Date 2019-10-20 01:08
//*******************************
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using DXYK.Admin.Entity;
using DXYK.Admin.Repository;

namespace DXYK.Admin.Service
{
    ///<summary>
        /// 收件人信息表
        ///</summary>
    public class OaMailReceiverService
    {

        ///<summary>
        ///OaMailReceiverService 仓储
        ///</summary>
        public IOaMailReceiverRepository OaMailReceiverRepository { get; }

        ///<summary>
        ///OaMailReceiverService 构造函数
        ///</summary>
        public OaMailReceiverService (IOaMailReceiverRepository oaMailReceiverRepository)
        {
            OaMailReceiverRepository = oaMailReceiverRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public string Insert(OaMailReceiver oaMailReceiver)
        {
            return OaMailReceiverRepository.Insert(oaMailReceiver);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<string> InsertAsync(OaMailReceiver oaMailReceiver)
        {
            return await OaMailReceiverRepository.InsertAsync(oaMailReceiver);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return OaMailReceiverRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(long id)
        {
            return await OaMailReceiverRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(OaMailReceiver oaMailReceiver)
        {
            return OaMailReceiverRepository.Update(oaMailReceiver);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(OaMailReceiver oaMailReceiver)
        {
            return await OaMailReceiverRepository.UpdateAsync(oaMailReceiver);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public OaMailReceiver GetById(long id)
        {
            return OaMailReceiverRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<OaMailReceiver> GetByIdAsync(long id)
        {
            return await OaMailReceiverRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return OaMailReceiverRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await OaMailReceiverRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return OaMailReceiverRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await OaMailReceiverRepository.QueryDataByPageAsync(param);
        }

        /// <summary>
        /// 根据条件查询收件总数
        /// </summary>
        public int QueryInDataRecord(object param)
        {
            return OaMailReceiverRepository.QueryInDataRecord(param);
        }

        /// <summary>
        /// 根据条件查询收件信息
        /// </summary>
        public List<object> QueryInByFilter(object param)
        {
            return OaMailReceiverRepository.QueryInByFilter(param);
        }

        /// <summary>
        /// 根据邮件Id查询收件人信息
        /// </summary>
        public List<object> QueryByMailId(long mailid)
        {
            return OaMailReceiverRepository.QueryByMailId(mailid);
        }
        

    }
}

