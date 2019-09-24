//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using DXYK.Admin.API.Exceptions;
using DXYK.Admin.API.Messages;
using System.Net;

namespace DXYK.Admin.API.Filters
{
    /// <summary>
    /// GlobalExceptionFilter
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// IHostingEnvironment
        /// </summary>
        private readonly IHostingEnvironment env;

        /// <summary>
        /// ILogger
        /// </summary>
        private readonly ILogger<GlobalExceptionFilter> logger;

        /// <summary>
        /// GlobalExceptionFilter
        /// </summary>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        public GlobalExceptionFilter(IHostingEnvironment env, ILogger<GlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var exception = context.Exception;
            //–¥»’÷æ
            logger.LogError(
                new EventId(exception.HResult),
                exception,
                exception.Message
            );
            int errorCode = 1;
            if (exception is APIException)
            {
                errorCode = (exception as APIException).code;
            }
            var errorResp = new ResponseMessage<object>
            {
                success = false,
                msg = exception.Message,
                code = errorCode,
                data = null
            };
            var result = new JsonResult(errorResp)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            context.Result = result;

        }
    }
}






