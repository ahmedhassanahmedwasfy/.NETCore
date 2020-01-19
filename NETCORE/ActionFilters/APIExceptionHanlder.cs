using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Target_NETCORE.APIControllers;

namespace Target_NETCORE.ActionFilters
{
    public class APIExceptionHanlder : Attribute, IActionFilter//, IOrderedFilter
    {
      //  public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        { 
            if (context.Exception == null || context.ExceptionHandled)
            { 
            }
            else
            {
                var controller = context.Controller as APIBaseController; 
                controller.LogException(context.Exception);
                controller._baseservice.Rollback();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
             
        }
    }
}
