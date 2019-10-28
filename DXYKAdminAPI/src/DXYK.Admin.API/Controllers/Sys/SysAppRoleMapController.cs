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
using Newtonsoft.Json;

namespace DXYK.Admin.API.Controllers
{
    ///<summary>
    /// 角色授权表
    ///</summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SysAppRoleMapController : Controller
    {
        ///<summary>
        /// 角色授权表(sys_app_role_map) Service
        ///</summary>
        public SysAppRoleMapService _sysAppRoleMapService { get; }

        ///<summary>
        /// 角色授权表(sys_app_role_map) Repository
        ///</summary>
        public ISysAppRoleMapRepository _sysAppRoleMapRepository { get; }

        ///<summary>
        /// sys_app_role_mapController
        ///</summary>
        public SysAppRoleMapController(SysAppRoleMapService sysAppRoleMapService, ISysAppRoleMapRepository sysAppRoleMapRepository)
        {
            _sysAppRoleMapService = sysAppRoleMapService;
            _sysAppRoleMapRepository = sysAppRoleMapRepository;
        }

        ///<summary>
        /// 新增角色授权表(sys_app_role_map)
        ///</summary>
        [HttpPost]
        public ResponseMessage<string> Insert([FromBody]SysAppRoleMap sysAppRoleMap)
        {
            return new ResponseMessage<string> { data = _sysAppRoleMapService.Insert(sysAppRoleMap) };
        }

        ///<summary>
        /// 异步新增角色授权表(sys_app_role_map)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<string>> InsertAsync([FromBody]SysAppRoleMap sysAppRoleMap)
        {
            return new ResponseMessage<string> { data = await _sysAppRoleMapService.InsertAsync(sysAppRoleMap) };
        }

        ///<summary>
        /// 删除角色授权表(sys_app_role_map)
        ///</summary>
        [HttpDelete]
        public ResponseMessage<int> DeleteById(string id)
        {
            return new ResponseMessage<int> { data = _sysAppRoleMapService.DeleteById(id) };
        }

        ///<summary>
        /// 异步删除角色授权表(sys_app_role_map)
        ///</summary>
        [HttpDelete]
        public async Task<ResponseMessage<int>> DeleteByIdAsync(string id)
        {
            return new ResponseMessage<int> { data = await _sysAppRoleMapService.DeleteByIdAsync(id) };
        }

        ///<summary>
        /// 更新角色授权表(sys_app_role_map)
        ///</summary>
        [HttpPut]
        public ResponseMessage<int> Update([FromBody]SysAppRoleMap sysAppRoleMap)
        {
            return new ResponseMessage<int> { data = _sysAppRoleMapService.Update(sysAppRoleMap) };
        }

        ///<summary>
        /// 异步更新角色授权表(sys_app_role_map)
        ///</summary>
        [HttpPut]
        public async Task<ResponseMessage<int>> UpdateAsync([FromBody]SysAppRoleMap sysAppRoleMap)
        {
            //SysAppRoleMap entity = await _sysAppRoleMapService.GetByIdAsync(sysAppRoleMap.id);
            //Utils.CommmonUtils.EntityToEntity(sysAppRoleMap, entity, null);
            //return new ResponseMessage<int> { data = await _sysAppRoleMapService.UpdateAsync(entity) };
            return new ResponseMessage<int> { data = await _sysAppRoleMapService.UpdateAsync(sysAppRoleMap) };
        }

        ///<summary>
        /// 根据Id查询角色授权表(sys_app_role_map)
        ///</summary>
        [HttpGet]
        public ResponseMessage<SysAppRoleMap> GetById(string id)
        {
            var sysAppRoleMap = _sysAppRoleMapService.GetById(id);
            return new ResponseMessage<SysAppRoleMap> { data = sysAppRoleMap };
        }

        ///<summary>
        /// 根据Id查询角色授权表(sys_app_role_map)
        ///</summary>
        [HttpGet]
        public async Task<ResponseMessage<SysAppRoleMap>> GetByIdAsync(string id)
        {
            var sysAppRoleMap = await _sysAppRoleMapService.GetByIdAsync(id);
            return new ResponseMessage<SysAppRoleMap> { data = sysAppRoleMap };
        }

        ///<summary>
        /// 根据条件查询角色授权表(sys_app_role_map)
        ///</summary>
        [HttpPost]
        public ResponseMessage<IList<SysAppRoleMap>> Query([FromBody]QueryRequest reqMsg)
        {
            var list = _sysAppRoleMapRepository.Query(reqMsg);
            return new ResponseMessage<IList<SysAppRoleMap>> { data = list };
        }

        ///<summary>
        /// 异步根据条件查询角色授权表(sys_app_role_map)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessage<IList<SysAppRoleMap>>> QueryAsync([FromBody]QueryRequest reqMsg)
        {
            var list = await _sysAppRoleMapRepository.QueryAsync(reqMsg);
            return new ResponseMessage<IList<SysAppRoleMap>> { data = list };
        }

        ///<summary>
        /// 根据分页查询角色授权表(sys_app_role_map)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<IList<SysAppRoleMap>> QueryByPage([FromBody]QueryByPageRequest reqMsg)
        {

            var total = _sysAppRoleMapRepository.GetRecord(reqMsg);
            var list = _sysAppRoleMapRepository.QueryByPage(reqMsg);
            return new ResponseMessageWrap<IList<SysAppRoleMap>>() { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询角色授权表(sys_app_role_map)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<IList<SysAppRoleMap>>> QueryByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppRoleMapRepository.GetRecordAsync(reqMsg);
            var list = await _sysAppRoleMapRepository.QueryByPageAsync(reqMsg);
            return new ResponseMessageWrap<IList<SysAppRoleMap>>() { count = total, data = list };
        }

        ///<summary>
        /// 根据分页查询角色授权表(sys_app_role_map)
        ///</summary>
        [HttpPost]
        public ResponseMessageWrap<object> QueryDataByPage([FromBody]QueryByPageRequest reqMsg)
        {
            var total = _sysAppRoleMapService.QueryDataRecord(reqMsg);
            var list = _sysAppRoleMapService.QueryDataByPage(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步根据分页查询角色授权表(sys_app_role_map)
        ///</summary>
        [HttpPost]
        public async Task<ResponseMessageWrap<object>> QueryDataByPageAsync([FromBody]QueryByPageRequest reqMsg)
        {
            var total = await _sysAppRoleMapService.QueryDataRecordAsync(reqMsg);
            var list = await _sysAppRoleMapService.QueryDataByPageAsync(reqMsg);
            return new ResponseMessageWrap<object> { count = total, data = list };
        }

        ///<summary>
        /// 异步新增角色授权表(sys_app_role_map)
        ///</summary>
        [HttpPost]
        public ResponseMessage<int> UpdateMap([FromBody]OwnQueryRequest reqMsg)
        {
            bool tf = true;
            foreach (var item in reqMsg.objs)
            {
                var roleid = reqMsg.roleid;
                var mapid = item.id;
                var tmpdata = _sysAppRoleMapService.GetByFilter(roleid, mapid, int.Parse(reqMsg.type));
                if(tmpdata.Count == 0)
                {
                    SysAppRoleMap enity = new SysAppRoleMap()
                    {
                        id = 0,
                        role_id = roleid,
                        map_id = mapid,
                        type_code = reqMsg.type,
                        group_id = ""
                    };
                    _sysAppRoleMapService.Insert(enity);
                }
            }
            return new ResponseMessage<int> { data = tf ? 1 : 0 };
        }

        /// <summary>
        /// OwnQueryRequest
        /// </summary>
        public class OwnQueryRequest
        {
            /// <summary>
            /// 查询关键字
            /// </summary>
            public string roleid { get; set; }
            /// <summary>
            /// 查询关键字
            /// </summary>
            public string type { get; set; }
            /// <summary>
            /// 查询关键字
            /// </summary>
            public List<tmpdto> objs { get; set; }


        }

        /// <summary>
        /// tmpdto
        /// </summary>
        public class tmpdto
        {
            /// <summary>
            /// id
            /// </summary>
            public string id { get; set; }
        }

    }
}

