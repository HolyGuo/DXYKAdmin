using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXYK.Admin.Dto.Cmomon;
using DXYK.Admin.Dto.Sys;
using DXYK.Admin.Entity;
using DXYK.Admin.MVC.Messages;
using DXYK.Admin.MVC.Utils;
using DXYK.Admin.Repository;
using DXYK.Admin.Service;
using Microsoft.AspNetCore.Mvc;

namespace DXYK.Admin.MVC.Controllers.System
{
    [Route("api/[controller]/[action]")]
    public class SysOrgController : Controller
    {
        ///<summary>
        /// 单位信息表(sys_org) Service
        ///</summary>
        public SysOrgService _sysOrgService { get; }

        ///<summary>
        /// 单位信息表(sys_org) Repository
        ///</summary>
        public ISysOrgRepository _sysOrgRepository { get; }

        ///<summary>
        /// sys_orgController
        ///</summary>
        public SysOrgController(SysOrgService sysOrgService, ISysOrgRepository sysOrgRepository)
        {
            _sysOrgService = sysOrgService;
            _sysOrgRepository = sysOrgRepository;
        }

        ///<summary>
        /// 新增单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public ResponseMessage<string> Insert([FromBody]SysOrg sysOrg)
        {
            return new ResponseMessage<string> { data = _sysOrgService.Insert(sysOrg) };
        }

        ///<summary>
        /// 删除单位信息表(sys_org)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(string id)
        {
            return new ResponseMessage<int> { data = _sysOrgService.DeleteById(id) };
        }

        ///<summary>
        /// 更新单位信息表(sys_org)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysOrg sysOrg)
        {
            return new ResponseMessage<int> { data = _sysOrgService.Update(sysOrg) };
        }

        ///<summary>
        /// 根据Id查询单位信息表(sys_org)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysOrg> GetById(string id)
        {
            var sysOrg = _sysOrgService.GetById(id);
            return new ResponseMessage<SysOrg> { data = sysOrg };
        }

        ///<summary>
        /// 根据分页查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysOrgService.QueryDataRecord(reqMsg);
            var list = _sysOrgService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 根据分页查询单位信息表(sys_org)
        ///</summary>
        [HttpGet]
        public ResponseMessageWrap<List<ZTreeDto>> QueryDataByAuthorize()
        {
            UserInfo user = GetCurrentUser.GetUserInfo(Request.HttpContext);
            List<SysOrg> listOrg = _sysOrgService.QueryDataByAuthorize(user.org_id, user.group_id);
            List<ZTreeDto> tree = null;
            if (listOrg != null && listOrg.Count > 0)
            {
                tree = new List<ZTreeDto>();
                foreach (SysOrg item in listOrg)
                {
                    ZTreeDto t = new ZTreeDto();
                    t.id = item.id;
                    t.name = item.org_name;
                    //t.open = false;
                    t.pId = item.parent_id;
                    t.obj = item;
                    t.objId = item.id;
                    tree.Add(t);
                }
            }
            return new ResponseMessageWrap<List<ZTreeDto>> { data = tree };
        }



    }
}