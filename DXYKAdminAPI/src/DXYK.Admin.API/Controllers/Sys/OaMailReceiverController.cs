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
using DXYK.Admin.Extensions.JWT;

namespace DXYK.Admin.API.Controllers
{
    ///<summary>
    /// 收件人信息表
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OaMailReceiverController : Controller
    {
        ///<summary>
        /// 收件人信息表(oa_mail_receiver) Service
        ///</summary>
        public OaMailReceiverService _oaMailReceiverService { get; }

        ///<summary>
        /// 收件人信息表(oa_mail_receiver) Repository
        ///</summary>
        public IOaMailReceiverRepository _oaMailReceiverRepository { get; }

        ///<summary>
        /// oa_mail_receiverController
        ///</summary>
        public OaMailReceiverController(OaMailReceiverService oaMailReceiverService, IOaMailReceiverRepository oaMailReceiverRepository)
        {
            _oaMailReceiverService = oaMailReceiverService;
            _oaMailReceiverRepository = oaMailReceiverRepository;
        }

        ///<summary>
        /// 新增收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpPost]
        public ResponseMessage<string> Insert([FromBody]OaMailReceiver oaMailReceiver)
        {
            return new ResponseMessage<string> { data = _oaMailReceiverService.Insert(oaMailReceiver) };
        }

        ///<summary>
        /// 异步新增收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<string>> InsertAsync([FromBody]OaMailReceiver oaMailReceiver)
        {
            return new ResponseMessage<string> { data = await _oaMailReceiverService.InsertAsync(oaMailReceiver) };
        }

        ///<summary>
        /// 删除收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data = _oaMailReceiverService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await _oaMailReceiverService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]OaMailReceiver oaMailReceiver)
        {
            return new ResponseMessage<int> { data = _oaMailReceiverService.Update(oaMailReceiver) };
        }

        ///<summary>
        /// 异步更新收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]OaMailReceiver oaMailReceiver)
        {
            //OaMailReceiver entity = await _oaMailReceiverService.GetByIdAsync(oaMailReceiver.id);
            //Utils.CommmonUtils.EntityToEntity(oaMailReceiver, entity, null);
            //return new ResponseMessage<int> { data = await _oaMailReceiverService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _oaMailReceiverService.UpdateAsync(oaMailReceiver) };
        }

        ///<summary>
        /// 根据Id查询收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpGet]
        public ResponseMessage<OaMailReceiver> GetById(long id)
        {
            var oaMailReceiver = _oaMailReceiverService.GetById(id);
            return new ResponseMessage<OaMailReceiver> { data = oaMailReceiver };
        }

        ///<summary>
        /// 根据Id查询收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<OaMailReceiver>> GetByIdAsync(long id)
        {
            var oaMailReceiver = await _oaMailReceiverService.GetByIdAsync(id);
            return new ResponseMessage<OaMailReceiver> { data = oaMailReceiver };
        }

        ///<summary>
        /// 根据条件查询收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<OaMailReceiver>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _oaMailReceiverRepository.Query(reqMsg);
            return new ResponseMessage<IList<OaMailReceiver>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<OaMailReceiver>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list = await _oaMailReceiverRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<OaMailReceiver>> { data = list };
        }

        ///<summary>
        /// 根据分页查询收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<OaMailReceiver>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {

            var total = _oaMailReceiverRepository.GetRecord(reqMsg);
            var list = _oaMailReceiverRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<OaMailReceiver>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<OaMailReceiver>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _oaMailReceiverRepository.GetRecordAsync(reqMsg);
            var list = await _oaMailReceiverRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<OaMailReceiver>>() { count = total, data = list };
        }

        ///<summary>
        /// 根据分页查询收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _oaMailReceiverService.QueryDataRecord(reqMsg);
            var list = _oaMailReceiverService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询收件人信息表(oa_mail_receiver)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _oaMailReceiverService.QueryDataRecordAsync(reqMsg);
            var list = await _oaMailReceiverService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 根据条件查询收件信息
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryInByFilter([FromBody]OwnQueryByPageRequest reqMsg)
        {
            TokenModel jwtToken = new TokenModel();
            jwtToken = JwtHelper.SerializeJWT(reqMsg.token);
            reqMsg.userid = long.Parse(jwtToken.Uid);
            var total = _oaMailReceiverService.QueryInDataRecord(reqMsg);
            var list = _oaMailReceiverService.QueryInByFilter(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        /// <summary>
        /// 私人请求条件
        /// </summary>
        public class OwnQueryByPageRequest: QueryByPageRequest
        {
            public string token { get; set; }
            public long userid { get; set; }
        }

        ///<summary>
        /// 根据邮件Id查询收件人信息
        ///</summary>
        [HttpGet]
        public ResponseMessage<object> QueryByMailId(long mailid)
        {
            var Receivers = _oaMailReceiverService.QueryByMailId(mailid);
            return new ResponseMessage<object> { data = Receivers };
        }

    }
}

