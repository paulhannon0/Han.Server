using System.Threading.Tasks;
using Han.Server.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.WebUtilities;

namespace Han.Server.Api.Middleware
{
    internal class HttpExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public HttpExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context);
            }
            catch (HttpException httpException)
            {
                context.Response.StatusCode = (int)httpException.StatusCode;

                var responseFeature = context.Features.Get<IHttpResponseFeature>();
                responseFeature.ReasonPhrase = $"{ReasonPhrases.GetReasonPhrase(context.Response.StatusCode)}";

                await context.Response.WriteAsync(httpException.Message);
            }
        }
    }
}
