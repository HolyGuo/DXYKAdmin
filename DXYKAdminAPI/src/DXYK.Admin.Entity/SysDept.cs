//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
        /// 系统管理-单位信息表
        ///</summary>
    public class SysDept
    {
///<summary>
        /// 唯一标识
        ///</summary>
public virtual long id { get; set; }
///<summary>
        /// 单位名称
        ///</summary>
public virtual string dept_name { get; set; }
///<summary>
        /// 上级id
        ///</summary>
public virtual long? parent_id { get; set; }
///<summary>
        /// 对应sys_user表中的id
        ///</summary>
public virtual long? leader_id { get; set; }
///<summary>
        /// 单位类型
        ///</summary>
public virtual string dept_type { get; set; }
///<summary>
        /// 单位地址
        ///</summary>
public virtual string dept_address { get; set; }
///<summary>
        /// 联系电话
        ///</summary>
public virtual string telphone { get; set; }
///<summary>
        /// 电子邮箱
        ///</summary>
public virtual string email { get; set; }
///<summary>
        /// 排序
        ///</summary>
public virtual int? sort { get; set; }
///<summary>
        /// 群组id
        ///</summary>
public virtual long? group_id { get; set; }
///<summary>
        /// 乐观锁
        ///</summary>
public virtual int? re_vision { get; set; }
///<summary>
        /// 创建人
        ///</summary>
public virtual long? created_by { get; set; }
///<summary>
        /// 创建时间
        ///</summary>
public virtual DateTime? created_time { get; set; }
///<summary>
        /// 更新人
        ///</summary>
public virtual long? updated_by { get; set; }
///<summary>
        /// 更新时间
        ///</summary>
public virtual DateTime? updated_time { get; set; }
///<summary>
        /// 删除人
        ///</summary>
public virtual long? deleted_by { get; set; }
///<summary>
        /// 删除时间
        ///</summary>
public virtual DateTime? deleted_time { get; set; }
    }
    }

