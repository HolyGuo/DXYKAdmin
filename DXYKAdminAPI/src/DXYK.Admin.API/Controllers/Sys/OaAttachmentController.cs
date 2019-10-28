//*******************************
// Create By Holy Guo
// Date 2019-10-20 01:08
//*******************************
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DXYK.Admin.Entity;
using DXYK.Admin.Repository;
using DXYK.Admin.Service;
using DXYK.Admin.API.Messages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DXYK.Admin.API.Controllers
{
    ///<summary>
        /// 附件信息表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OaAttachmentController : Controller
    {
        ///<summary>
        /// 附件信息表(oa_attachment) Service
        ///</summary>
        public OaAttachmentService _oaAttachmentService { get; }

        ///<summary>
        /// 附件信息表(oa_attachment) Repository
        ///</summary>
        public IOaAttachmentRepository _oaAttachmentRepository { get; }

        ///<summary>
        /// oa_attachmentController
        ///</summary>
        public OaAttachmentController(OaAttachmentService oaAttachmentService, IOaAttachmentRepository oaAttachmentRepository)
        {
            _oaAttachmentService = oaAttachmentService;
            _oaAttachmentRepository = oaAttachmentRepository;
        }

        ///<summary>
        /// 新增附件信息表(oa_attachment)
        ///</summary>
        [HttpPost]
        public ResponseMessage<string> Insert([FromBody]OaAttachment oaAttachment)
        {
            return new ResponseMessage<string> { data = _oaAttachmentService.Insert(oaAttachment) }; 
        }

        ///<summary>
        /// 异步新增附件信息表(oa_attachment)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<string>>InsertAsync([FromBody]OaAttachment oaAttachment)
        {
            return new ResponseMessage<string> { data = await _oaAttachmentService.InsertAsync(oaAttachment) };
        }

        ///<summary>
        /// 删除附件信息表(oa_attachment)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(string id)
        {
            return new ResponseMessage<int> { data =  _oaAttachmentService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除附件信息表(oa_attachment)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(string id)
        {
            return new ResponseMessage<int> { data = await _oaAttachmentService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新附件信息表(oa_attachment)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]OaAttachment oaAttachment)
        {
            return new ResponseMessage<int> { data = _oaAttachmentService.Update(oaAttachment) };
        }

        ///<summary>
        /// 异步更新附件信息表(oa_attachment)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]OaAttachment oaAttachment)
        {
            //OaAttachment entity = await _oaAttachmentService.GetByIdAsync(oaAttachment.id);
            //Utils.CommmonUtils.EntityToEntity(oaAttachment, entity, null);
            //return new ResponseMessage<int> { data = await _oaAttachmentService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _oaAttachmentService.UpdateAsync(oaAttachment) };
        }

        ///<summary>
        /// 根据Id查询附件信息表(oa_attachment)
        ///</summary>
        [HttpGet]
        public ResponseMessage<OaAttachment> GetById(string id)
        {
            var oaAttachment = _oaAttachmentService.GetById(id);
            return new ResponseMessage<OaAttachment> {  data = oaAttachment };
        }

        ///<summary>
        /// 根据Id查询附件信息表(oa_attachment)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<OaAttachment>> GetByIdAsync(string id)
        {
            var oaAttachment =await _oaAttachmentService.GetByIdAsync(id);
            return new ResponseMessage<OaAttachment>{ data = oaAttachment};
        }

        ///<summary>
        /// 根据条件查询附件信息表(oa_attachment)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<OaAttachment>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _oaAttachmentRepository.Query(reqMsg);
            return new ResponseMessage<IList<OaAttachment>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询附件信息表(oa_attachment)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<OaAttachment>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _oaAttachmentRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<OaAttachment>> { data = list };
        }

        ///<summary>
        /// 根据分页查询附件信息表(oa_attachment)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<OaAttachment>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _oaAttachmentRepository.GetRecord(reqMsg);
            var list = _oaAttachmentRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<OaAttachment>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询附件信息表(oa_attachment)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<OaAttachment>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _oaAttachmentRepository.GetRecordAsync(reqMsg);
            var list =await _oaAttachmentRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<OaAttachment>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询附件信息表(oa_attachment)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _oaAttachmentService.QueryDataRecord(reqMsg);
            var list = _oaAttachmentService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询附件信息表(oa_attachment)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _oaAttachmentService.QueryDataRecordAsync(reqMsg);
            var list = await _oaAttachmentService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadFile(IFormFile file)
        {
            string userId = Request.Form["userId"];
            if (file != null)
            {
                var fileDir = "D:\\wopi\\files";
                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }
                //文件名称
                string projectFileName = file.FileName;

                //上传的文件的路径
                string filePath = fileDir + $@"\{projectFileName}";
                if (!System.IO.File.Exists(filePath))
                {
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                    OaAttachment oaAttachment = new OaAttachment();
                    oaAttachment.file_name = file.FileName;
                    var namearr = file.FileName.Split('.');
                    oaAttachment.file_ext = namearr[namearr.Length - 1];
                    oaAttachment.file_size = file.Length.ToString();
                    oaAttachment.publish_path = string.Format("D:\\wopi\\files\\{0}", file.FileName);
                    oaAttachment.group_id = "GXBBWGKGLJ";
                    _oaAttachmentService.Insert(oaAttachment);
                }
            }
            else
            {
                return Json("no");
            }
            return Json("ok");
        }

        ///<summary>
        /// 根据Ids查询附件信息
        ///</summary>
        [HttpGet]
        public ResponseMessage<object> QueryByIds(string ids)
        {
            var res = new List<OaAttachment>();
            if (!string.IsNullOrEmpty(ids))
            {
                var idarr = ids.Split(',');
                foreach (var item in idarr)
                {
                    OaAttachment attach = _oaAttachmentService.GetById(item);
                    res.Add(attach);
                }
            }
            //var res = _oaAttachmentService.QueryByIds(ids);
            return new ResponseMessage<object> { data = res };
        }

    }
}

