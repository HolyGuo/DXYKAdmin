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
        /// 邮件信息表
        ///</summary>
    public class OaMailService
    {

        ///<summary>
        ///OaMailService 仓储
        ///</summary>
        public IOaMailRepository OaMailRepository { get; }

        ///<summary>
        ///OaMailService 构造函数
        ///</summary>
        public OaMailService (IOaMailRepository oaMailRepository)
        {
            OaMailRepository = oaMailRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public string Insert(OaMail oaMail)
        {
            return OaMailRepository.Insert(oaMail);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<string> InsertAsync(OaMail oaMail)
        {
            return await OaMailRepository.InsertAsync(oaMail);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(string id)
        {
            return OaMailRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(string id)
        {
            return await OaMailRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(OaMail oaMail)
        {
            return OaMailRepository.Update(oaMail);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(OaMail oaMail)
        {
            return await OaMailRepository.UpdateAsync(oaMail);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public OaMail GetById(string id)
        {
            return OaMailRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<OaMail> GetByIdAsync(string id)
        {
            return await OaMailRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return OaMailRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await OaMailRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return OaMailRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await OaMailRepository.QueryDataByPageAsync(param);
        }

        ///<summary>
        ///查找雪花id
        ///</summary>
        public long QueryId(string title, DateTime publish_time, string group_id)
        {
            return OaMailRepository.QueryId(title, publish_time, group_id);
        }


    }
}

