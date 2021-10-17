using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ElectronicWallet.Infraestructure.Middlewares
{
    public class ExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            SetExceptionResult(context, exception);
            context.ExceptionHandled = true;
        }

        private void SetExceptionResult(
            ExceptionContext context,
            Exception exception,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var result = new JsonResult(new
            {
                error = exception.Message
            });
            context.Result = result;
            context.HttpContext.Response.StatusCode = (int)statusCode;
        }
    }
}