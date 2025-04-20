using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspDotNetCoreMVC.Filters;


public class ValidateModelAttribute: ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if(!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }

    //public override void OnActionExecuting(ActionExecutingContext context)
    //{
    //    base.OnActionExecuting(context);
    //}

    //public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //{
    //    // before
    //    await next();

    //    //after
    //}
}
