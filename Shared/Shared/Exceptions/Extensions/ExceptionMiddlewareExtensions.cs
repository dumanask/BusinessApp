using Microsoft.AspNetCore.Builder;

namespace Shared.Exceptions.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        =>app.UseMiddleware<ExceptionMiddleware>();
}