using Microsoft.AspNetCore.Http;
using Shopbridge.Domain.Models;
using System.Net;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Shopbridge.Domain.GlobalErrorHandling
{
  public class CustomExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public CustomExceptionMiddleware(RequestDelegate next, ILogger logger) {
      _next = next;
      _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch(NullReferenceException nulEx)
      {
        _logger.LogError($"Something went wrong: {nulEx}", nulEx);
        await HandleExceptionAsync(httpContext);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Something went wrong: {ex}",ex);
        await HandleExceptionAsync(httpContext);
      }
    }

    private async Task HandleExceptionAsync(HttpContext context)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDetails()
      {
        StatusCode = context.Response.StatusCode,
        Message = "Internal Server Error from the custom middleware."
      }));
    }
  }
}
