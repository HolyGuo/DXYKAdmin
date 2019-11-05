using System;
using System.Collections.Generic;
using System.Text;

namespace DXYK.Admin.Dto.Cmomon
{
    /// <summary>
    /// Ztree节点对象
    /// </summary>
    public class LayUITreeDto
    {
        /// <summary>
        /// 节点id
        /// </summary>
        public string id ;   //tree id
        /// <summary>
        /// 父级id
        /// </summary>
        public string pId;   //父级id
        /// <summary>
        /// 显示文本
        /// </summary>
        public string title;   //显示文本

        public List<LayUITreeDto> children;
        /// <summary>
        /// 是否展开节点
        /// </summary>
        public bool spread;//是否展开节点
        /// <summary>
        /// 图标路径
        /// </summary>
        public string icon;//图标路径
        /// <summary>
        /// 图标样式class
        /// </summary>
        public string iconSkin;//图标样式class
        /// <summary>
        /// 类型  用于扩展
        /// </summary>
        public string treeType;//类型  用于扩展
        /// <summary>
        /// 用于存储对象
        /// </summary>
        public object obj;//用于存储对象
        /// <summary>
        /// 用于存储对象ID
        /// </summary>
        public string objId;//用于存储对象ID
    }
}
