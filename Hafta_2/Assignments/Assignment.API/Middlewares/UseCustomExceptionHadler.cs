using Microsoft.AspNetCore.Diagnostics;
using System;

namespace AssignmentHafta2.API.Middlewares
{
    public static class UseCustomExceptionHadler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();

                    var exception = exceptionHandler.Error;

                    var statusCode = StatusCodes.Status500InternalServerError;

                    context.Response.StatusCode = statusCode;
                    if (exception is NotImplementedException)
                    {
                        statusCode = StatusCodes.Status501NotImplemented;
                    }
                    else if (exception is UnauthorizedAccessException)
                    {
                        statusCode = StatusCodes.Status401Unauthorized;
                    }

                    context.Response.StatusCode = statusCode;

                    await context.Response.WriteAsync(new
                    {
                        StatusCode = statusCode,
                        Message = exception.Message
                    }.ToString());


                });
            });
        }
    }
}
