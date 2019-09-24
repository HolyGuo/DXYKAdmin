//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using DXYK.Admin.API.Messages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace DXYK.Admin.API.Filters
{
    /// <summary>
    /// GlobalValidateModelFilter
    /// </summary>
    public class GlobalValidateModelFilter : IActionFilter
    {
        /// <summary>
        /// IHostingEnvironment
        /// </summary>
        private readonly IHostingEnvironment _env;

        /// <summary>
        /// ILogger
        /// </summary>
        private readonly ILogger<GlobalValidateModelFilter> _logger;

        /// <summary>
        /// GlobalValidateModelFilter
        /// </summary>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        public GlobalValidateModelFilter(IHostingEnvironment env, ILogger<GlobalValidateModelFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                _logger.LogDebug("ModelState not valid:{0}", JsonConvert.SerializeObject(context.ModelState));
                StringBuilder errStr = new StringBuilder();

                foreach (var error in context.ModelState.Values)
                {
                    string errorMsg = error.Errors?.FirstOrDefault()?.ErrorMessage;
                    errStr.AppendFormat("{0} |", errorMsg);
                }

                var resp = new ResponseMessage<object>
                {
                    code = 106,
                    msg = errStr.ToString().TrimEnd('|'),
                    success = false,
                    data = null
                };

                var result = new JsonResult(resp);
                context.Result = result;
            }
        }

    }
}

