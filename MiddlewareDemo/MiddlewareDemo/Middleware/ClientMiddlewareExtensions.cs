namespace MiddlewareDemo.Middleware
{
    public static class ClientMiddlewareExtensions
    {
        public static IApplicationBuilder UseClientInfo(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClientInfoMiddleware>();
        }

        public static IHostApplicationBuilder AddUseClientInfo(this IHostApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IClientInfoRepository, ClientInfoRepository.ClientInfoRepository>();
            return builder;
        }

    }
    
}
