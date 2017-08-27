using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6.Training.Filters
{
    public class MyActionFilter : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = new ContentResult()
            {
                Content = "My Action Executing"
            };
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new ContentResult()
            {
                Content = "My Action Executed"
            };
        }
    }
}
