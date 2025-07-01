using System.Net;
using Azure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionAppSlownessTest
{
    public class KeyAuthHttpFunction
    {
        private readonly ILogger _logger;

        public KeyAuthHttpFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FastHttpFunction>();
        }

        [Function("KeyAuthHttpFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("KeyAuthHttpFunction processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            await response.WriteStringAsync("Welcome to Azure Functions!");

            return response;
        }
    }
}
