//*******************************
// Create By Holy Guo
// Date 2019-10-03 09:12
//*******************************
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using DXYK.Admin.Entity;
using DXYK.Admin.Repository;
using DXYK.Admin.Dto.Cmomon;

namespace DXYK.Admin.Service
{
    ///<summary>
    /// 单位信息表
    ///</summary>
    public class SysOrgService
    {

        ///<summary>
        ///SysOrgService 仓储
        ///</summary>
        public ISysOrgRepository SysOrgRepository { get; }

        ///<summary>
        ///SysOrgService 构造函数
        ///</summary>
        public SysOrgService(ISysOrgRepository sysOrgRepository)
        {
            SysOrgRepository = sysOrgRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public string Insert(SysOrg sysOrg)
        {
            return SysOrgRepository.Insert(sysOrg);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public async Task<string> InsertAsync(SysOrg sysOrg)
        {
            return await SysOrgRepository.InsertAsync(sysOrg);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(string id)
        {
            return SysOrgRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public async Task<int> DeleteByIdAsync(string id)
        {
            return await SysOrgRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysOrg sysOrg)
        {
            return SysOrgRepository.Update(sysOrg);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysOrg sysOrg)
        {
            return await SysOrgRepository.UpdateAsync(sysOrg);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysOrg GetById(string id)
        {
            return SysOrgRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysOrg> GetByIdAsync(string id)
        {
            return await SysOrgRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 根据条件查询总数
        /// </summary>
        /// <returns></returns>
        public int QueryDataRecord(object param)
        {
            return SysOrgRepository.QueryDataRecord(param);
        }

        /// <summary>
        /// 异步根据条件查询总数
        /// </summary>
        public async Task<int> QueryDataRecordAsync(object param)
        {
            return await SysOrgRepository.QueryDataRecordAsync(param);
        }

        /// <summary>
        /// 根据条件进行分页查询
        /// </summary>
        public List<object> QueryDataByPage(object param)
        {
            return SysOrgRepository.QueryDataByPage(param);
        }

        /// <summary>
        /// 异步根据条件进行分页查询
        /// </summary>
        public async Task<List<object>> QueryDataByPageAsync(object param)
        {
            return await SysOrgRepository.QueryDataByPageAsync(param);
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        public List<SysOrg> GetAll()
        {
            return SysOrgRepository.GetAll();
        }

        /// <summary>
        /// 根据名称和状态获取数据列
        /// </summary>
        public List<SysOrg> QueryDataByNameAndType(string org_name, string dept_type)
        {
            return SysOrgRepository.QueryDataByNameAndType(org_name, dept_type);
        }

        /// <summary>
        /// 查询当前单位及下级单位
        /// </summary>
        /// <param name="id">当前单位id</param>
        /// <param name="group_id">群组id</param>
        /// <returns></returns>
        public List<SysOrg> QueryDataByAuthorize(string id, string group_id)
        {
            List<SysOrg> resList = null;
            List<SysOrg> list = SysOrgRepository.QueryData(group_id);
            if (list != null && list.Count > 0)
            {
                resList = new List<SysOrg>();
                //当前单位为根节点
                SysOrg rootOrg = list.Where(s => s.id == id).FirstOrDefault();
                resList.Add(rootOrg);
                GetChildOrg(resList, list, id);
            }
            return resList;
        }

        private void GetChildOrg(List<SysOrg> resList, List<SysOrg> orgList, string org_id)
        {
            List<SysOrg> childList = orgList.Where(s => s.parent_id == org_id).ToList();
            if (childList != null && childList.Count > 0)
            {
                resList.AddRange(childList);
                foreach (SysOrg item in childList)
                {
                    GetChildOrg(resList, orgList, item.id);
                }
            }
        }

        public LayUITreeDto QueryDataByAuthorizeForLayUITree(string id, string group_id)
        {
            LayUITreeDto res = null;
            List<SysOrg> list = SysOrgRepository.QueryData(group_id);
            if (list != null && list.Count > 0)
            {
                res = new LayUITreeDto();
                //当前单位为根节点
                SysOrg rootOrg = list.Where(s => s.id == id).FirstOrDefault();
                res.title = rootOrg.org_name;
                res.id = rootOrg.id;
                res.spread = true;
                res.pId = rootOrg.parent_id;
                res.obj = rootOrg;
                GetChildOrg(res, list, id);
            }
            return res;
        }
        private void GetChildOrg(LayUITreeDto res, List<SysOrg> orgList, string org_id)
        {
            List<SysOrg> childList = orgList.Where(s => s.parent_id == org_id).ToList();
            if (childList != null && childList.Count > 0)
            {
                foreach (SysOrg item in childList)
                {
                    LayUITreeDto node = new LayUITreeDto();
                    node.title = item.org_name;
                    node.id = item.id;
                    node.pId = item.parent_id;
                    node.obj = item;
                    if (res.children == null)
                    {
                        res.children = new List<LayUITreeDto>();
                    }
                    res.children.Add(node);
                    GetChildOrg(res, orgList, item.id);
                }
            }
        }




    }
}

