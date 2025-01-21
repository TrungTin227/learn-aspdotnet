using Microsoft.AspNetCore.Mvc;
using MiddlewareDemo.ClientInfoRepository;

namespace MiddlewareDemo.Controllers
{
    public class ClientInfoController : Controller
    {
        private readonly IClientInfoRepository _clientInfoRepository;

        public ClientInfoController(IClientInfoRepository clientInfoRepository) 
        {
            _clientInfoRepository = clientInfoRepository;

        }

        //[Route("/clientinfo")]
        //[HttpGet]
        //public IActionResult GetClientInfo([FromHeader(Name = "API-Key")]string apiKey)
        //{
        //    if (apiKey == null)
        //    {
        //        return BadRequest();
        //    }

        //    var clientInfo = _clientInfoRepository.GetClientInfo(apiKey);

        //    if (clientInfo != null)
        //    {
        //        return Ok(clientInfo);
        //    }
        //    return Unauthorized();
        //}
        [Route("/clientinfo")]
        [HttpGet]
        public IActionResult GetClientInfo()
        { 
            return Ok(this.HttpContext.Features.Get<ClientInfo>());
        }
    } 
}
