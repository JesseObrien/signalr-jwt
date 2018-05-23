using Microsoft.AspNetCore.Builder;
using sigtest.Middleware;

namespace sigtest
{
    public static class JwtVerifyMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtVerify(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtVerify>();
        }
    }
}