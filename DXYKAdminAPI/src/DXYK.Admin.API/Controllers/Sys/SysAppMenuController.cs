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
    /// 菜单信息表
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysAppMenuController : Controller
    {
        ///<summary>
        /// 菜单信息表(sys_app_menu) Service
        ///</summary>
        public SysAppMenuService _sysAppMenuService { get; }

        ///<summary>
        /// 菜单信息表(sys_app_menu) Repository
        ///</summary>
        public ISysAppMenuRepository _sysAppMenuRepository { get; }

        ///<summary>
        /// sys_app_menuController
        ///</summary>
        public SysAppMenuController(SysAppMenuService sysAppMenuService, ISysAppMenuRepository sysAppMenuRepository)
        {
            _sysAppMenuService = sysAppMenuService;
            _sysAppMenuRepository = sysAppMenuRepository;
        }

        ///<summary>
        /// 新增菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost, ApiAuthorize(ActionCode = "Admin,Menu_Manage,Menu_Add", LogType = LogEnum.ADD)]
        public ResponseMessage<long> Insert([FromBody]SysAppMenu sysAppMenu)
        {
            return new ResponseMessage<long> { data = _sysAppMenuService.Insert(sysAppMenu) };
        }

        ///<summary>
        /// 异步新增菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<long>> InsertAsync([FromBody]SysAppMenu sysAppMenu)
        {
            return new ResponseMessage<long> { data = await _sysAppMenuService.InsertAsync(sysAppMenu) };
        }

        ///<summary>
        /// 删除菜单信息表(sys_app_menu)
        ///</summary>
        [HttpDelete, ApiAuthorize(ActionCode = "Admin,Menu_Manage,Menu_Delete", LogType = LogEnum.DELETE)]
        public ResponseMessage<int> DeleteById(long id)
        {
            return new ResponseMessage<int> { data = _sysAppMenuService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除菜单信息表(sys_app_menu)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(long id)
        {
            return new ResponseMessage<int> { data = await _sysAppMenuService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPut, ApiAuthorize(ActionCode = "Admin,Menu_Manage,Menu_Update", LogType = LogEnum.UPDATE)]
        public ResponseMessage<int> Update([FromBody]SysAppMenu sysAppMenu)
        {
            return new ResponseMessage<int> { data = _sysAppMenuService.Update(sysAppMenu) };
        }

        ///<summary>
        /// 异步更新菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysAppMenu sysAppMenu)
        {
            //SysAppMenu entity = await _sysAppMenuService.GetByIdAsync(sysAppMenu.id);
            //Utils.CommmonUtils.EntityToEntity(sysAppMenu, entity, null);
            //return new ResponseMessage<int> { data = await _sysAppMenuService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysAppMenuService.UpdateAsync(sysAppMenu) };
        }

        ///<summary>
        /// 根据Id查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysAppMenu> GetById(long id)
        {
            var sysAppMenu = _sysAppMenuService.GetById(id);
            return new ResponseMessage<SysAppMenu> { data = sysAppMenu };
        }

        ///<summary>
        /// 根据Id查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysAppMenu>> GetByIdAsync(long id)
        {
            var sysAppMenu = await _sysAppMenuService.GetByIdAsync(id);
            return new ResponseMessage<SysAppMenu> { data = sysAppMenu };
        }

        ///<summary>
        /// 根据条件查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysAppMenu>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysAppMenuRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysAppMenu>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysAppMenu>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list = await _sysAppMenuRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysAppMenu>> { data = list };
        }

        ///<summary>
        /// 根据分页查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysAppMenu>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {

            var total = _sysAppMenuRepository.GetRecord(reqMsg);
            var list = _sysAppMenuRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysAppMenu>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysAppMenu>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppMenuRepository.GetRecordAsync(reqMsg);
            var list = await _sysAppMenuRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysAppMenu>>() { count = total, data = list };
        }

        ///<summary>
        /// 根据分页查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysAppMenuService.QueryDataRecord(reqMsg);
            var list = _sysAppMenuService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppMenuService.QueryDataRecordAsync(reqMsg);
            var list = await _sysAppMenuService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 获取所有菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessage<object> GetALL(string name)
        {
            List<object> reslst = new List<object>();
            List<SysAppMenu> col1 = _sysAppMenuService.GetAll("");
            List<SysAppMenu> col2 = _sysAppMenuService.GetAll(name);
            SysAppMenu[] arr = new SysAppMenu[col2.Count()];
            List<SysAppMenu> col3 = new List<SysAppMenu>();
            col2.CopyTo(arr);
            col3 = arr.ToList();
            foreach (var item in col2)
            {
                //补全树
                getTree(col1, col3, item);
            }

            //构建树结果
            foreach (SysAppMenu item in col3.Where(t => t.parent_id == 0))
            {
                treedata node = getNode(item, col3);

                reslst.Add(node);
            }

            return new ResponseMessage<object> { data = new { content = reslst } };
        }

        ///<summary>
        /// 获取所有菜单信息表(sys_app_menu)
        ///</summary>
        [HttpPost]
        public ResponseMessage<object> GetALLByName(string name)
        {
            List<object> reslst = new List<object>();
            List<SysAppMenu> col1 = _sysAppMenuService.GetAll("");
            List<SysAppMenu> col2 = _sysAppMenuService.GetAll(name);
            SysAppMenu[] arr = new SysAppMenu[col2.Count()];
            List<SysAppMenu> col3 = new List<SysAppMenu>();
            col2.CopyTo(arr);
            col3 = arr.ToList();
            foreach (var item in col2)
            {
                //补全树
                getTree(col1, col3, item);
            }

            //构建树结果
            foreach (SysAppMenu item in col3.Where(t => t.parent_id == 0))
            {
                treedata1 node = getNode1(item, col3);

                reslst.Add(node);
            }

            return new ResponseMessage<object> { data = new { content = reslst } };
        }

        ///<summary>
        /// 获取所有菜单信息表(sys_app_menu)
        ///</summary>
        [HttpGet]
        public ResponseMessage<object> GetTree()
        {
            List<object> reslst = new List<object>();
            List<SysAppMenu> col1 = _sysAppMenuService.GetAll("");
            //构建树结果
            foreach (SysAppMenu item in col1.Where(t => t.parent_id == 0))
            {
                treedata2 node = getNode2(item, col1);

                reslst.Add(node);
            }

            return new ResponseMessage<object> { data = new { content = reslst } };
        }

        private void getTree(List<SysAppMenu> col1, List<SysAppMenu> col2, SysAppMenu node)
        {
            if (node.parent_id != 0 && col2.Where(t => t.id == node.parent_id).Count() == 0)
            {
                SysAppMenu parent = col1.Where(t => t.id == node.parent_id).FirstOrDefault();
                col2.Add(parent);
                getTree(col1, col2, parent);
            }
        }

        private treedata getNode(SysAppMenu item, List<SysAppMenu> col3)
        {
            Object metaobj = new
            {
                title = item.title,
                icon = item.icon,
                noCache = true
            };
            treedata node = new treedata()
            {
                name = item.title,
                path = item.jump,
                component = item.parent_id == 0 ? "Layout" : string.Format("system/{0}/index", item.jump),
                meta = metaobj,
            };
            List<SysAppMenu> childs = col3.Where(t => t.parent_id == item.id).ToList();
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

        private treedata1 getNode1(SysAppMenu item, List<SysAppMenu> col3)
        {
            treedata1 node = new treedata1()
            {
                id = item.id,
                name = item.title,
                sort = item.sort.ToString(),
                path = item.jump,
                component = item.parent_id == 0 ? "Layout" : string.Format("system/{0}/index", item.jump),
                pid = (long)item.parent_id,
                cache = "false",
                hidden = "false",
                componentName = item.jump,
                icon = item.icon,
                createTime = item.created_time.ToString(),
                iframe = "false",
            };
            List<SysAppMenu> childs = col3.Where(t => t.parent_id == item.id).ToList();
            if (childs.Count() > 0)
            {
                List<treedata1> children = new List<treedata1>();
                foreach (var childitem in childs)
                {
                    treedata1 childnode = getNode1(childitem, col3);
                    children.Add(childnode);
                }
                node.children = children;
            }
            return node;
        }

        private treedata2 getNode2(SysAppMenu item, List<SysAppMenu> col3)
        {
            treedata2 node = new treedata2()
            {
                id = item.id,
                label = item.title,
                pid = (long)item.parent_id
            };
            List<SysAppMenu> childs = col3.Where(t => t.parent_id == item.id).ToList();
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

        private class treedata
        {
            public string name;
            public string path;
            public string component;
            public string hidden;
            public object meta;
            public List<treedata> children;
        }

        private class treedata1
        {
            public long id;
            public string name;
            public string sort;
            public string path;
            public string component;
            public long pid;
            public string cache;
            public string hidden;
            public string componentName;
            public string icon;
            public List<treedata1> children;
            public string createTime;
            public string iframe;
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

