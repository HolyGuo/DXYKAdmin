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

namespace  DXYK.Admin.API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment env;
        private readonly ILogger<GlobalExceptionFilter> logger;

        public GlobalExceptionFilter(IHostingEnvironment env, ILogger<GlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            var exception = context.Exception;
            logger.LogError(
            new EventId(exception.HResult),
            exception,
            exception.Message);
            int errorCode = 200;
            if (exception is APIException) { errorCode = (exception as APIException).code; }
            var errorResp = new ResponseMessage
            {
                msg = exception.Message,
                code = errorCode,
                success = false
            };
            var result = new JsonResult(errorResp)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            context.Result = result;

        }
    }
}






