//********
//***********************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System;

namespace DXYK.Admin.MVC.Messages
{
    ///<summary>
    ///ResponseMessage 返回消息
    ///</summary>
    public class ResponseMessage<TData>
    {
        /// <summary>
        /// 是否成功返回，true 返回成功  false 返回失败，默认为true
        /// </summary>
        public bool success { get; set; } = true;

        /// <summary>
        /// 数据返回状态 0 为成功
        /// </summary>
        public int code { get; set; } = 0;

        /// <summary>
        /// 响应状态  500：访问出错了
        /// </summary>
        public int status { get; set; } = 200;

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; } = "OK";

        /// <summary>
        /// 返回主体
        /// </summary>
        public TData data { get; set; }
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
        /// 数据返回状态 0 为成功
        /// </summary>
        public int code { get; set; } = 0;

        /// <summary>
        /// 响应状态
        /// </summary>
        public int status { get; set; } = 200;
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; } = "请求成功";

        /// <summary>
        /// 消息
        /// </summary>
        public int count { get; set; } = 0;

        /// <summary>
        /// 返回主体
        /// </summary>
        public TData data { get; set; }
    }
}



