using AssignmentHafta2.API.Middlewares;

namespace AssignmentHafta2.API.Extensions
{
    public static class LoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }
    }
}
