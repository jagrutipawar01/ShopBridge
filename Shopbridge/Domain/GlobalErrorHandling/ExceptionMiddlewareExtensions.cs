using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shopbridge.Domain.Models;
using System.Net;

namespace Shopbridge.Domain.GlobalErrorHandling
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
            logger.LogError($"Something went wrong: {contextFeature.Error}", null);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDetails()
            {
              StatusCode = context.Response.StatusCode,
              Message = "Internal Server Error."
            }));
          }
        });
      });
    }

    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
      app.UseMiddleware<CustomExceptionMiddleware>();
    }
  }
}
