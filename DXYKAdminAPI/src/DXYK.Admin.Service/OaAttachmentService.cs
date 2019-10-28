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
        /// 附件信息表
        ///</summary>
    public class OaAttachmentService
    {

        ///<summary>
        ///OaAttachmentService 仓储
        ///</summary>
        public IOaAttachmentRepository OaAttachmentRepository { get; }

        ///<summary>
        ///OaAttachmentService 构造函数
        ///</summary>
        public OaAttachmentService (IOaAttachmentRepository oaAttachmentRepository)
        {
            OaAttachmentRepository = oaAttachmentRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public string Insert(OaAttachment oaAttachment)
        {
            return OaAttachmentRepository.Insert(oaAttachment);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<string> InsertAsync(OaAttachment oaAttachment)
        {
            return await OaAttachmentRepository.InsertAsync(oaAttachment);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(string id)
        {
            return OaAttachmentRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(string id)
        {
            return await OaAttachmentRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(OaAttachment oaAttachment)
        {
            return OaAttachmentRepository.Update(oaAttachment);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(OaAttachment oaAttachment)
        {
            return await OaAttachmentRepository.UpdateAsync(oaAttachment);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public OaAttachment GetById(string id)
        {
            return OaAttachmentRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<OaAttachment> GetByIdAsync(string id)
        {
            return await OaAttachmentRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return OaAttachmentRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await OaAttachmentRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return OaAttachmentRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await OaAttachmentRepository.QueryDataByPageAsync(param);
        }

        ///<summary>
        ///查找雪花id
        ///</summary>
        public string QueryId(string filenames)
        {
            var aa = OaAttachmentRepository.QueryId(filenames);
            return aa.ToString();
        }

        /// <summary>
        /// 根据Ids查询附件信息
        /// </summary>
        public List<object> QueryByIds(string ids)
        {
            return OaAttachmentRepository.QueryByIds(ids);
        }


    }
}

