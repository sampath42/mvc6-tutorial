using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MVC6.Training.Filters
{
    public interface ILog
    {
        void Log(HttpRequest request);
    }

    public class Log : ILog
    {
        void ILog.Log(HttpRequest request)
        {
        }
    }

    public class LogFilter : ActionFilterAttribute
    {
        private readonly ILog logger;
        private readonly string logName;

        public LogFilter(ILog logger,string logName)
        {
            this.logger = logger;
            this.logName = logName;
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            this.logger.Log(actionContext.HttpContext.Request);
        }
    }
}
