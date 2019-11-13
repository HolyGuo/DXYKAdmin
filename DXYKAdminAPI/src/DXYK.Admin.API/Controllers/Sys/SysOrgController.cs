//*******************************
// Create By Holy Guo
// Date 2019-10-03 09:12
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
using DXYK.Admin.API.Filters;
using DXYK.Admin.Common.EnumHelper;

namespace DXYK.Admin.API.Controllers
{
    ///<summary>
        /// 单位信息表
        ///</summary>
    [ApiController]
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
        [HttpPost, ApiAuthorize(ActionCode = "Admin,Org_Manage,Org_Add", LogType = LogEnum.ADD)]
        public ResponseMessage<string> Insert([FromBody]SysOrg sysOrg)
        {
            return new ResponseMessage<string> { data = _sysOrgService.Insert(sysOrg) }; 
        }

        ///<summary>
        /// 异步新增单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<string>>InsertAsync([FromBody]SysOrg sysOrg)
        {
            return new ResponseMessage<string> { data = await _sysOrgService.InsertAsync(sysOrg) };
        }

        ///<summary>
        /// 删除单位信息表(sys_org)
        ///</summary>
        [HttpDelete, ApiAuthorize(ActionCode = "Admin,Org_Manage,Org_Delete", LogType = LogEnum.DELETE)]
        public ResponseMessage<int> DeleteById(string id)
        {
            return new ResponseMessage<int> { data =  _sysOrgService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除单位信息表(sys_org)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(string id)
        {
            return new ResponseMessage<int> { data = await _sysOrgService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新单位信息表(sys_org)
        ///</summary>
        [HttpPut, ApiAuthorize(ActionCode = "Admin,Org_Manage,Org_Update", LogType = LogEnum.UPDATE)]
        public ResponseMessage<int> Update([FromBody]SysOrg sysOrg)
        {
            SysOrg entity = _sysOrgService.GetById(sysOrg.id);
            Utils.CommmonUtils.EntityToEntity(sysOrg, entity, null);
            return new ResponseMessage<int> { data = _sysOrgService.Update(entity) };
            //return new ResponseMessage<int> { data = _sysOrgService.Update(sysOrg) };
        }

        ///<summary>
        /// 异步更新单位信息表(sys_org)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysOrg sysOrg)
        {
            //SysOrg entity = await _sysOrgService.GetByIdAsync(sysOrg.id);
            //Utils.CommmonUtils.EntityToEntity(sysOrg, entity, null);
            //return new ResponseMessage<int> { data = await _sysOrgService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysOrgService.UpdateAsync(sysOrg) };
        }

        ///<summary>
        /// 根据Id查询单位信息表(sys_org)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysOrg> GetById(string id)
        {
            var sysOrg = _sysOrgService.GetById(id);
            return new ResponseMessage<SysOrg> {  data = sysOrg };
        }

        ///<summary>
        /// 根据Id查询单位信息表(sys_org)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysOrg>> GetByIdAsync(string id)
        {
            var sysOrg =await _sysOrgService.GetByIdAsync(id);
            return new ResponseMessage<SysOrg>{ data = sysOrg};
        }

        ///<summary>
        /// 根据条件查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysOrg>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysOrgRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysOrg>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysOrg>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _sysOrgRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysOrg>> { data = list };
        }

        ///<summary>
        /// 根据分页查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysOrg>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _sysOrgRepository.GetRecord(reqMsg);
            var list = _sysOrgRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysOrg>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysOrg>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _sysOrgRepository.GetRecordAsync(reqMsg);
            var list =await _sysOrgRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysOrg>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysOrgService.QueryDataRecord(reqMsg);
            var list = _sysOrgService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询单位信息表(sys_org)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysOrgService.QueryDataRecordAsync(reqMsg);
            var list = await _sysOrgService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 获取所有单位信息表(sys_org)
        ///</summary>
        [HttpGet]
        public ResponseMessage<object> GetALL()
        {
            List<object> reslst = new List<object>();
            List<SysOrg> col1 = _sysOrgService.GetAll();
            var col2 = col1.Where(t => t.parent_id == "0");

            foreach (SysOrg item in col2)
            {
                List<SysOrg> childcols = col1.Where(t => t.parent_id == item.id).OrderBy(t => t.id).ToList();
                List<object> childlst = new List<object>();
                foreach (var child in childcols)
                {
                    Object childobj = new
                    {
                        id = child.id,
                        name = child.org_name,
                        enabled = true,
                        pid = child.parent_id,
                        createTime = child.created_time,
                        label = child.org_name
                    };
                    childlst.Add(childobj);
                }
                Object obj = new
                {
                    id = item.id,
                    name = item.org_name,
                    enabled = true,
                    pid = item.parent_id,
                    children = childlst,
                    createTime = item.created_time,
                    label = item.org_name
                };
                reslst.Add(obj);
            }
            return new ResponseMessage<object> { data = new { content = reslst, totalElements = col1.Count } };
        }


        /// <summary>
        /// 根据名称和状态获取数据列
        /// </summary>
        [HttpPost]
        public ResponseMessage<object> QueryDataByNameAndType([FromBody]QueryByPageRequest reqMsg)
        {
            List<treedata> reslst = new List<treedata>();
            List<SysOrg> col1 = _sysOrgService.GetAll();
            List<SysOrg> col2 = _sysOrgService.QueryDataByNameAndType(reqMsg.keyWords, reqMsg.status);
            SysOrg[] arr = new SysOrg[col2.Count()];
            List<SysOrg> col3 = new List<SysOrg>();
            col2.CopyTo(arr);
            col3 = arr.ToList();
            foreach (var item in col2)
            {
                //补全树
                getTree(col1, col3, item);
            }
            //构建树结果
            foreach (SysOrg item in col3.Where(t=>t.parent_id == "0"))
            {
                treedata node = getNode(item, col3);
                
                reslst.Add(node);
            }
            return new ResponseMessage<object> { data = new { content = reslst, totalElements = col3.Count } };
        }

        private void getTree(List<SysOrg> col1 , List<SysOrg> col2, SysOrg node)
        {
            if(node.parent_id != "0" && col2.Where(t=>t.id == node.parent_id).Count() == 0)
            {
                SysOrg parent = col1.Where(t => t.id == node.parent_id).FirstOrDefault();
                col2.Add(parent);
                getTree(col1, col2, parent);
            }
        }

        private treedata getNode(SysOrg item, List<SysOrg> col3)
        {
            treedata node = new treedata() {
                id = item.id,
                name = item.org_name,
                enabled = item.dept_type,
                pid = item.parent_id,
                createTime = item.created_time.ToString(),
                label = item.org_name
            };
            List<SysOrg> childs = col3.Where(t => t.parent_id == item.id).ToList();
            if (childs.Count() > 0)
            {
                List<treedata> children = new List<treedata>();
                foreach (var childitem in childs)
                {
                    treedata childnode = getNode(childitem, col3);
                    children.Add(childnode);
                }
                node.children = children;
            }
            return node;
        }

        private class treedata
        {
            public string id;
            public string name;
            public string enabled;
            public string pid;
            public List<treedata> children;
            public string createTime;
            public string label;
        }
    }
}

