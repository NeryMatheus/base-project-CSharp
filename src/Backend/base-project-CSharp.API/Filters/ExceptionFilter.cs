using base_project_CSharp.Communication.Responses;
using base_project_CSharp.Exceptions;
using base_project_CSharp.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace base_project_CSharp.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is RecipeBookException)
                HandleProjectExceptio(context);
            else
                ThrowUnkonownException(context);
        }

        private void HandleProjectExceptio(ExceptionContext context) { 
            if (context.Exception is ErrorOnValidationException)
            {
                var exception = context.Exception as ErrorOnValidationException;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorsMessages));
            }
        }

        private void ThrowUnkonownException(ExceptionContext context) {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesExceptions.UNKONOWN_ERROR));
        }
    }
}
