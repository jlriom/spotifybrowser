using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace SpotifyBrowser.Host.ErrorHandling
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var errorDetails = new ErrorDetails(contextFeature.Error, context.Response.StatusCode);
                        context.Response.StatusCode = errorDetails.StatusCode;
                        logger.LogError($"Error id: '{errorDetails.ErrorId}', Details: {errorDetails}");
                        await context.Response.WriteAsync(errorDetails.ToStringForClient());
                    }
                });
            });
        }
    }
}
