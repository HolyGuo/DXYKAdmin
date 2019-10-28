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
using System.Linq;
using DXYK.Admin.Extensions.JWT;

namespace DXYK.Admin.API.Controllers
{
    ///<summary>
        /// 邮件信息表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OaMailController : Controller
    {
        ///<summary>
        /// 邮件信息表(oa_mail) Service
        ///</summary>
        public OaMailService _oaMailService { get; }

        ///<summary>
        /// 邮件信息表(oa_mail) Repository
        ///</summary>
        public IOaMailRepository _oaMailRepository { get; }

        ///<summary>
        /// 附件信息表(oa_attachment) Service
        ///</summary>
        public OaAttachmentService _oaAttachmentService { get; }

        ///<summary>
        /// 收件人信息表(oa_mail_receiver) Service
        ///</summary>
        public OaMailReceiverService _oaMailReceiverService { get; }

        ///<summary>
        /// oa_mailController
        ///</summary>
        public OaMailController(OaMailService oaMailService, IOaMailRepository oaMailRepository, 
            OaAttachmentService oaAttachmentService, OaMailReceiverService oaMailReceiverService)
        {
            _oaMailService = oaMailService;
            _oaMailRepository = oaMailRepository;
            _oaAttachmentService = oaAttachmentService;
            _oaMailReceiverService = oaMailReceiverService;
        }

        ///<summary>
        /// 新增邮件信息表(oa_mail)
        ///</summary>
        [HttpPost]
        public ResponseMessage<string> Insert([FromBody]OaMail oaMail)
        {
            return new ResponseMessage<string> { data = _oaMailService.Insert(oaMail) }; 
        }

        ///<summary>
        /// 异步新增邮件信息表(oa_mail)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<string>>InsertAsync([FromBody]OaMail oaMail)
        {
            return new ResponseMessage<string> { data = await _oaMailService.InsertAsync(oaMail) };
        }

        ///<summary>
        /// 删除邮件信息表(oa_mail)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(string id)
        {
            return new ResponseMessage<int> { data =  _oaMailService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除邮件信息表(oa_mail)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(string id)
        {
            return new ResponseMessage<int> { data = await _oaMailService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新邮件信息表(oa_mail)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]OaMail oaMail)
        {
            return new ResponseMessage<int> { data = _oaMailService.Update(oaMail) };
        }

        ///<summary>
        /// 异步更新邮件信息表(oa_mail)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]OaMail oaMail)
        {
            //OaMail entity = await _oaMailService.GetByIdAsync(oaMail.id);
            //Utils.CommmonUtils.EntityToEntity(oaMail, entity, null);
            //return new ResponseMessage<int> { data = await _oaMailService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _oaMailService.UpdateAsync(oaMail) };
        }

        ///<summary>
        /// 根据Id查询邮件信息表(oa_mail)
        ///</summary>
        [HttpGet]
        public ResponseMessage<OaMail> GetById(string id)
        {
            var oaMail = _oaMailService.GetById(id);
            return new ResponseMessage<OaMail> {  data = oaMail };
        }

        ///<summary>
        /// 根据Id查询邮件信息表(oa_mail)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<OaMail>> GetByIdAsync(string id)
        {
            var oaMail =await _oaMailService.GetByIdAsync(id);
            return new ResponseMessage<OaMail>{ data = oaMail};
        }

        ///<summary>
        /// 根据条件查询邮件信息表(oa_mail)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<OaMail>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _oaMailRepository.Query(reqMsg);
            return new ResponseMessage<IList<OaMail>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询邮件信息表(oa_mail)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<OaMail>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _oaMailRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<OaMail>> { data = list };
        }

        ///<summary>
        /// 根据分页查询邮件信息表(oa_mail)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<OaMail>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _oaMailRepository.GetRecord(reqMsg);
            var list = _oaMailRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<OaMail>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询邮件信息表(oa_mail)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<OaMail>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _oaMailRepository.GetRecordAsync(reqMsg);
            var list =await _oaMailRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<OaMail>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询邮件信息表(oa_mail)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _oaMailService.QueryDataRecord(reqMsg);
            var list = _oaMailService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询邮件信息表(oa_mail)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _oaMailService.QueryDataRecordAsync(reqMsg);
            var list = await _oaMailService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 新增邮件信息(oa_mail)
        ///</summary>
        [HttpPost]
        public ResponseMessage<int> SendMail([FromBody]OwnQueryRequest reqMsg)
        {
            OaMail oaMail = new OaMail();
            oaMail.title = reqMsg.title;
            oaMail.content = reqMsg.content;
            oaMail.publish_time = DateTime.Now;
            oaMail.group_id = "GXBBWGKGLJ";
            var tf = _oaMailService.Insert(oaMail);
            var mailid = _oaMailService.QueryId(reqMsg.title, (DateTime)oaMail.publish_time, oaMail.group_id);
            var files = reqMsg.filenames.Split(',').ToList();
            for (int i = 0; i < files.Count; i++)
            {
                if (i == 0)
                {
                    files[i] = files[i] + "'";
                }
                else if (i == files.Count - 1)
                {
                    files[i] = "'" + files[i];
                }
                else
                {
                    files[i] = "'" + files[i] + "'";
                }
            }
            string attachids = _oaAttachmentService.QueryId(string.Join(',', files));
            foreach (var item in reqMsg.reciervers.Split(','))
            {
                OaMailReceiver oaMailReceiver = new OaMailReceiver();
                oaMailReceiver.mail_id = mailid;
                oaMailReceiver.mail_title = reqMsg.title;
                var idarr = item.Split('#');
                oaMailReceiver.receiver_id = long.Parse(idarr[0]);
                oaMailReceiver.receiver_name = idarr[1];
                TokenModel jwtToken = new TokenModel();
                jwtToken = JwtHelper.SerializeJWT(reqMsg.token);
                oaMailReceiver.sender_id = long.Parse(jwtToken.Uid);
                oaMailReceiver.sender_name = jwtToken.UserName;
                oaMailReceiver.attachment_ids = attachids;
                oaMailReceiver.send_time = DateTime.Now;
                _oaMailReceiverService.Insert(oaMailReceiver);
            }
            return new ResponseMessage<int> { data = int.Parse(tf) };
        }

        /// <summary>
        /// 私有查询请求
        /// </summary>
        public class OwnQueryRequest
        {
            /// <summary>
            /// title
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// content
            /// </summary>
            public string content { get; set; }
            /// <summary>
            /// reciervers
            /// </summary>
            public string reciervers { get; set; }
            /// <summary>
            /// filenames
            /// </summary>
            public string filenames { get; set; }
            /// <summary>
            /// token
            /// </summary>
            public string token { get; set; }
        }
    }
}

