using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WhereMyBooks.Application.Exceptions;

namespace WhereMyBooks.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var result = new ObjectResult(context.Exception.Message);

        result.StatusCode = context.Exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            InternalException => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status500InternalServerError
        };

        context.Result = result;
    }
}