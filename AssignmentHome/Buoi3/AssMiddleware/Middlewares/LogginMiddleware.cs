using System.Diagnostics;

namespace AssMiddleware.Middlewares
{
    public class LogginMiddleware
    {
        private readonly RequestDelegate _next;

        public LogginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            string listInfo = "Schema" + request.Scheme +
            "\tHost" + request.Host +
            "\tPath" + request.Path +
            "\tStringquery" + request.QueryString +
            "\tRequestBody" + request.Body;

            File.WriteAllText("text.txt", listInfo);

            await _next(context);
        }
    }
}