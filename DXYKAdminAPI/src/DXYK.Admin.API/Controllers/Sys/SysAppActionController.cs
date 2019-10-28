//*******************************
// Create By Holy Guo
// Date 2019-10-06 22:21
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

namespace DXYK.Admin.API.Controllers
{
    ///<summary>
        /// 功能信息表
        ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysAppActionController : Controller
    {
        ///<summary>
        /// 功能信息表(sys_app_action) Service
        ///</summary>
        public SysAppActionService _sysAppActionService { get; }

        ///<summary>
        /// 功能信息表(sys_app_action) Repository
        ///</summary>
        public ISysAppActionRepository _sysAppActionRepository { get; }

        ///<summary>
        /// sys_app_actionController
        ///</summary>
        public SysAppActionController(SysAppActionService sysAppActionService, ISysAppActionRepository sysAppActionRepository)
        {
            _sysAppActionService = sysAppActionService;
            _sysAppActionRepository = sysAppActionRepository;
        }

        ///<summary>
        /// 新增功能信息表(sys_app_action)
        ///</summary>
        [HttpPost]
        public ResponseMessage<long> Insert([FromBody]SysAppAction sysAppAction)
        {
            return new ResponseMessage<long> { data = _sysAppActionService.Insert(sysAppAction) }; 
        }

        ///<summary>
        /// 异步新增功能信息表(sys_app_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>>InsertAsync([FromBody]SysAppAction sysAppAction)
        {
            return new ResponseMessage<long> { data = await _sysAppActionService.InsertAsync(sysAppAction) };
        }

        ///<summary>
        /// 删除功能信息表(sys_app_action)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(string id)
        {
            return new ResponseMessage<int> { data =  _sysAppActionService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除功能信息表(sys_app_action)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(string id)
        {
            return new ResponseMessage<int> { data = await _sysAppActionService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新功能信息表(sys_app_action)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysAppAction sysAppAction)
        {
            return new ResponseMessage<int> { data = _sysAppActionService.Update(sysAppAction) };
        }

        ///<summary>
        /// 异步更新功能信息表(sys_app_action)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysAppAction sysAppAction)
        {
            //SysAppAction entity = await _sysAppActionService.GetByIdAsync(sysAppAction.id);
            //Utils.CommmonUtils.EntityToEntity(sysAppAction, entity, null);
            //return new ResponseMessage<int> { data = await _sysAppActionService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysAppActionService.UpdateAsync(sysAppAction) };
        }

        ///<summary>
        /// 根据Id查询功能信息表(sys_app_action)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysAppAction> GetById(string id)
        {
            var sysAppAction = _sysAppActionService.GetById(id);
            return new ResponseMessage<SysAppAction> {  data = sysAppAction };
        }

        ///<summary>
        /// 根据Id查询功能信息表(sys_app_action)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysAppAction>> GetByIdAsync(string id)
        {
            var sysAppAction =await _sysAppActionService.GetByIdAsync(id);
            return new ResponseMessage<SysAppAction>{ data = sysAppAction};
        }

        ///<summary>
        /// 根据条件查询功能信息表(sys_app_action)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysAppAction>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysAppActionRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysAppAction>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询功能信息表(sys_app_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysAppAction>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list =await _sysAppActionRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysAppAction>> { data = list };
        }

        ///<summary>
        /// 根据分页查询功能信息表(sys_app_action)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysAppAction>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {
            
            var total = _sysAppActionRepository.GetRecord(reqMsg);
            var list = _sysAppActionRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysAppAction>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询功能信息表(sys_app_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysAppAction>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total =await _sysAppActionRepository.GetRecordAsync(reqMsg);
            var list =await _sysAppActionRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysAppAction>>() { count = total, data = list };
        }
        
        ///<summary>
        /// 根据分页查询功能信息表(sys_app_action)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysAppActionService.QueryDataRecord(reqMsg);
            var list = _sysAppActionService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> {count = total, data = list };
        }
        
        ///<summary>
        /// 异步根据分页查询功能信息表(sys_app_action)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppActionService.QueryDataRecordAsync(reqMsg);
            var list = await _sysAppActionService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 获取所有菜单信息表(sys_app_menu)
        ///</summary>
        [HttpGet]
        public ResponseMessage<object> GetTree()
        {
            List<object> reslst = new List<object>();
            List<SysAppAction> col1 = _sysAppActionService.GetAll("");
            //构建树结果
            foreach (SysAppAction item in col1.Where(t => t.parent_id == 0))
            {
                treedata2 node = getNode2(item, col1);

                reslst.Add(node);
            }

            return new ResponseMessage<object> { data = new { content = reslst } };
        }

        private treedata2 getNode2(SysAppAction item, List<SysAppAction> col3)
        {
            treedata2 node = new treedata2()
            {
                id = item.id,
                label = item.action_name,
                pid = (long)item.parent_id
            };
            List<SysAppAction> childs = col3.Where(t => t.parent_id == item.id).ToList();
            if (childs.Count() > 0)
            {
                List<treedata2> children = new List<treedata2>();
                foreach (var childitem in childs)
                {
                    treedata2 childnode = getNode2(childitem, col3);
                    children.Add(childnode);
                }
                node.children = children;
            }
            return node;
        }

        private class treedata2
        {
            public long id;
            public string label;
            public long pid;
            public List<treedata2> children;
        }

    }
}

