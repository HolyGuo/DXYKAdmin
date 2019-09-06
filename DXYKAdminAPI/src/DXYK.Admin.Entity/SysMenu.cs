//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************

using System;
namespace DXYK.Admin.Entity
{

    ///<summary>
        /// 系统管理-菜单信息表
        ///</summary>
    public class SysMenu
    {
///<summary>
        /// 唯一标识
        ///</summary>
public virtual long id { get; set; }
///<summary>
        /// 菜单名称
        ///</summary>
public virtual string title { get; set; }
///<summary>
        /// 上级id
        ///</summary>
public virtual long? parent_id { get; set; }
///<summary>
        /// 图标(Css-Class)
        ///</summary>
public virtual string icon { get; set; }
///<summary>
        /// 菜单类型
        ///</summary>
public virtual string menu_type { get; set; }
///<summary>
        /// 跳转
        ///</summary>
public virtual string jump { get; set; }
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

