using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicWallet.Infraestructure.Middlewares
{
    public class HttpSecurityHeaderMiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.Headers.TryAdd("X-Frame-Options", "DENY");
            context.Response.Headers.Add("X-Content-Type-Options", new[] { "nosniff" }); //https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Content-Type-Options
            await next(context);
        }
    }

    public static class HttpSecurityHeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpSecurityHeaderMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpSecurityHeaderMiddleware>();
        }
    }
}
