using System;
using System.Collections.Generic;
using System.Text;

namespace DXYK.Admin.Dto.Sys
{
    public class MenuTree
    {
        public string id;
        public string name;
        public string sort;
        public string pid;
        public string path;
        public string component;
        public string hidden;
        public string icon;
        public object meta;
        public List<MenuTree> children;
        public string createTime;
    }
}
