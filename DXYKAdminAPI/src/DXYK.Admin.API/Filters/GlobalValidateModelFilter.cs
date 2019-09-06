//*******************************
// Create By Holy Guo
// Date 2019-09-06 21:34
//*******************************
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DXYK.Admin.API.Messages;
using System.Linq;
using System.Text;

namespace DXYK.Admin.API.Filters
{
    public class GlobalValidateModelFilter : IActionFilter
    {
        private readonly IHostingEnvironment _env;
        private readonly ILogger<GlobalValidateModelFilter> _logger;

        public GlobalValidateModelFilter(IHostingEnvironment env, ILogger<GlobalValidateModelFilter> logger)
        {
            _env = env;
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

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

                var resp = new ResponseMessage
                {
                    code = 106,
                    msg = errStr.ToString().TrimEnd('|'),
                    success = false
                };

                var result = new JsonResult(resp);
                context.Result = result;
            }
        }
     }
}

