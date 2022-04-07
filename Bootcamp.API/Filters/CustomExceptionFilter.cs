using Bootcamp.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Bootcamp.API.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {

        public CustomExceptionFilter()
        {

        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            Debug.WriteLine("Exception Filter çalıştı");

            context.Result = new ObjectResult(ResponseDto<NoContentDto>.Fail($"{context.Exception.Message}", 500)) { StatusCode = 500 };


            return Task.CompletedTask;

        }


    }
}
