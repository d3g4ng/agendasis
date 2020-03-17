using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaSis.Infra.Filtros
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = new ObjectResult(new
            {
                code = 500,
                message = context.Exception.Message,
                detais = context.Exception?.InnerException?.Message
            })
            {

                StatusCode = 500
            };
            context.Result = result;
        }
    }
}
