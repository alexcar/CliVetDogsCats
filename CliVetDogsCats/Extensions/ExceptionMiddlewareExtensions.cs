using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using CliVetDogsCats.API.CustomExceptionMiddleware;
using CliVetDogsCats.API.Log;
using System.Net;
using System.Text.Json;

namespace CliVetDogsCats.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
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
                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,                            
                            _ => StatusCodes.Status500InternalServerError
                        };

                        //await context.Response.WriteAsync(new List<ErrorDetails>()
                        //{
                        //    new ErrorDetails()
                        //    {
                        //        StatusCode = context.Response.StatusCode,
                        //    Message = contextFeature.Error.Message,
                        //    }
                        //}.ToString());

                        var listError = new List<ErrorDetails>
                        {
                            new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message,
                            }
                        };

                        // await context.Response.WriteAsync(JsonSerializer.Serialize(listError));
                        var serializeOptions = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        };

                        await context.Response.WriteAsync(JsonSerializer.Serialize(listError, serializeOptions));
                    }
                });
            });
        }

        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
