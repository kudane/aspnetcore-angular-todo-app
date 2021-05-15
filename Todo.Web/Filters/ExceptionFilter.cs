using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Todo.Core.Exceptions;

namespace Todo.Web.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = (RestException)context.Exception;

            context.HttpContext.Response.StatusCode = (int)exception.Code;
            context.Result = new BadRequestObjectResult(exception.Errors);
        }
    }
}
