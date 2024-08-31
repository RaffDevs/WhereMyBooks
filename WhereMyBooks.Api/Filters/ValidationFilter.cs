using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WhereMyBooks.Api.Filters;

public class ValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid) 
            return;
        
        var messages = context.ModelState
            .SelectMany(msg => msg.Value.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        context.Result = new BadRequestObjectResult(messages);
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}