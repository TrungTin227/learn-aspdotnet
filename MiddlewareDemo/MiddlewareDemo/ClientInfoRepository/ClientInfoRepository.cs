using MiddlewareDemo.Models;

namespace MiddlewareDemo.ClientInfoRepository
{
    public class ClientInfoRepository : IClientInfoRepository
    {
        public ClientInfo? GetClientInfo(string apiKey)
        {
            if(_clientInfos.ContainsKey(apiKey))
            {
                return _clientInfos[apiKey];
            }
            return null;

        }

        private Dictionary<string, ClientInfo> _clientInfos = new()
        {
            { "12345", new ClientInfo { Id = 1, Name = "Client 1" } },
            { "67890", new ClientInfo { Id = 2, Name = "Client 2" } }
        };
    }
}
