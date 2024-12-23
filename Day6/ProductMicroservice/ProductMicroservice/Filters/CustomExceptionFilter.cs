using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models;

namespace ProductMicroservice.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult(
                new ErrorObject
                {
                    ErrorNumber = 500,
                    Message = context.Exception.Message
                });
        }
    }
    }
