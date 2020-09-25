
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
namespace BeanZhang.WebAPI
{
    public class ExceptionMiddleware
    {
        private readonly ILogger logger;
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await ExceptionHandlerAsync(context, e);
            }
        }

        private async Task ExceptionHandlerAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";

            logger.LogError(e, context.Request.Path);

            var result = new ResponseModel<string>()
            {
                status = 500,
                msg = e.Message
            };

            await context.Response.WriteAsync(result.ToJson());
        }
    }
}
