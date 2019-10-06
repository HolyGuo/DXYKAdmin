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
        public SysOrgService (ISysOrgRepository sysOrgRepository)
        {
            SysOrgRepository = sysOrgRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public long Insert(SysOrg sysOrg)
        {
            return SysOrgRepository.Insert(sysOrg);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<long> InsertAsync(SysOrg sysOrg)
        {
            return await SysOrgRepository.InsertAsync(sysOrg);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysOrgRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(long id)
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
        public SysOrg GetById(long id)
        {
            return SysOrgRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysOrg> GetByIdAsync(long id)
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



    }
}

