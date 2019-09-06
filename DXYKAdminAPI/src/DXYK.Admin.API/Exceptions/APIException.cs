//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DXYK.Admin.API.Exceptions
{
    /// <summary>
    /// APIException
    /// </summary>
    public class APIException : Exception
    {
        /// <summary>
        /// APIException
        /// </summary>
        public APIException()
        {
            code = 1001;
        }
        /// <summary>
        /// code
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// APIException
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        public APIException(int errorCode) : base() { code = errorCode; }

        /// <summary>
        /// APIException
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="message">消息</param>
        public APIException(int errorCode, string message) : base(message) { code = errorCode; }

        /// <summary>
        /// APIException
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="info">info</param>
        /// <param name="context">context</param>
        public APIException(int errorCode, SerializationInfo info, StreamingContext context) : base(info, context) { code = errorCode; }

        /// <summary>
        /// APIException
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="message">消息</param>
        /// <param name="innerException">innerException</param>
        public APIException(int errorCode, string message, System.Exception innerException) : base(message, innerException) { code = errorCode; }
    }
}





