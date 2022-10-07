using System;

namespace AssMiddleware.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLogginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogginMiddleware>();
        }
    }
}