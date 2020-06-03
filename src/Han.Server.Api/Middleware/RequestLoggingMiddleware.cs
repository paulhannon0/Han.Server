using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Han.Server.Api.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            var parsedRequestBody = string.Empty;

            using (var streamReader = new StreamReader(context.Request.Body))
            {
                parsedRequestBody = JsonConvert.SerializeObject(await streamReader.ReadToEndAsync());
            }

            if (!string.IsNullOrWhiteSpace(parsedRequestBody))
            {
                this.logger.LogDebug($"Request Body: {parsedRequestBody}");
            }

            await this.next(context);
        }
    }
}
