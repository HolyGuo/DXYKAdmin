//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DXYK.Admin.API.Messages
{
    ///<summary>
    ///ResponseMessage 返回消息
    ///</summary>
    public class ResponseMessage : ResponseMessageWrap<object>
    {

    }

    ///<summary>
    ///ResponseMessageWrap 返回消息
    ///</summary>
    public class ResponseMessageWrap<TData>
    {
        /// <summary>
        /// 是否成功返回，true 返回成功  false 返回失败，默认为true
        /// </summary>
        public bool success { get; set; } = true;

        /// <summary>
        /// 状态代码 默认 0
        /// </summary>
        public int code { get; set; } = 0;

        /// <summary>
        /// 消息
        /// </summary>
        public String msg { get; set; } ="Ok";

        /// <summary>
        /// 消息
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 返回主体
        /// </summary>
        public TData data { get; set; }
    }
}



