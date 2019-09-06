//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System;
using System.Linq;
using System.Threading.Tasks;
using DXYK.Admin.Entity;
using DXYK.Admin.Repository;

namespace DXYK.Admin.Service
{
    ///<summary>
        /// 系统管理-群组信息表
        ///</summary>
    public class SysGroupService
    {

        ///<summary>
        ///SysGroupService 仓储
        ///</summary>
        public ISysGroupRepository SysGroupRepository { get; }

        ///<summary>
        ///SysGroupService 构造函数
        ///</summary>
        public SysGroupService (ISysGroupRepository sysGroupRepository)
        {
            SysGroupRepository = sysGroupRepository;
        }

        ///<summary>
        ///新增
        ///</summary>
        public long Insert(SysGroup sysGroup)
        {
            return SysGroupRepository.Insert(sysGroup);
        }

        ///<summary>
        ///异步新增
        ///</summary>
        public  async Task<long> InsertAsync(SysGroup sysGroup)
        {
            return await SysGroupRepository.InsertAsync(sysGroup);
        }

        ///<summary>
        ///删除
        ///</summary>
        public int DeleteById(long id)
        {
            return SysGroupRepository.DeleteById(id);
        }

        ///<summary>
        ///异步删除
        ///</summary>
        public  async Task<int> DeleteByIdAsync(long id)
        {
            return await SysGroupRepository.DeleteByIdAsync(id);
        }

        ///<summary>
        ///更新
        ///</summary>
        public int Update(SysGroup sysGroup)
        {
            return SysGroupRepository.Update(sysGroup);
        }

        ///<summary>
        ///异步更新
        ///</summary>
        public async Task<int> UpdateAsync(SysGroup sysGroup)
        {
            return await SysGroupRepository.UpdateAsync(sysGroup);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public SysGroup GetById(long id)
        {
            return SysGroupRepository.GetById(id);
        }

        /// <summary>
        /// 根据Id查询数据
        /// </summary>
        public async Task<SysGroup> GetByIdAsync(long id)
        {
            return await SysGroupRepository.GetByIdAsync(id);
        }



    }
}

