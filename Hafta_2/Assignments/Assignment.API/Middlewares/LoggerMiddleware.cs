namespace AssignmentHafta2.API.Middlewares
{
    public class LoggerMiddleware:IMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggerMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.Log(LogLevel.Information, $"Run Action : {context.Request.Method} ");
            await _next(context);
        }
    }
}
