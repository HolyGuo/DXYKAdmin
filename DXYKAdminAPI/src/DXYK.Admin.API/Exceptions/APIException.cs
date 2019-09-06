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
    public class APIException : Exception
    {
        public APIException()
        {
            code = 200;
        }
        public int code { get; set; }

        public APIException(int errorCode) : base() { code = errorCode; }

        public APIException(int errorCode, string message) : base(message) { code = errorCode; }

        public APIException(int errorCode, SerializationInfo info, StreamingContext context) : base(info, context) { code = errorCode; }

        public APIException(int errorCode, string message, System.Exception innerException) : base(message, innerException) { code = errorCode; }
    }
}





