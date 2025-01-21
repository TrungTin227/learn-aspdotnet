namespace MiddlewareDemo.Middleware
{
    public class ClientInfoMiddleware
    {
        private readonly ILogger<ClientInfoMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ClientInfoMiddleware(RequestDelegate next, ILogger<ClientInfoMiddleware> logger)
        {
            _logger = logger;
            _next = next;

            _logger.LogInformation("ClientInfoMiddleware is executing.");
        }
        public async Task InvokeAsync(HttpContext context, IClientInfoRepository clientInfoRepository)
        {
            _logger.LogInformation("ClientInfoMiddleware is Invoked.");

            var apiKey = context.Request.Headers["API-Key"].FirstOrDefault();

            if (!string.IsNullOrEmpty(apiKey))
            {
                var clientInfo = clientInfoRepository.GetClientInfo(apiKey);
                if (clientInfo != null)
                {
                    _logger.LogInformation($"ClientInfo found: {clientInfo.Name}");
                    context.Features.Set(clientInfo);
                    await _next(context);
                    return;
                }
            }

            context.Response.StatusCode = 401;

        }

    }
}
