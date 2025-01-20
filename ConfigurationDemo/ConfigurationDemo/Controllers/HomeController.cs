using ConfigurationDemo.ConfigModels;
using ConfigurationDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Text;

namespace ConfigurationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfigurationRoot _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly ApiSettings apiSettings;
        public HomeController(IConfiguration configuration ,ILogger<HomeController> logger,IOptions <ApiSettings> apiSettings)
        {
            this.apiSettings = apiSettings.Value;
            _configuration = (IConfigurationRoot)configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/providers")]
        public IActionResult Providers()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Configuration Providers: ");
            foreach (var provider in _configuration.Providers)
            {
                sb.AppendLine(provider.ToString());
            }

            sb.AppendLine();
            sb.AppendLine("Configuration Values: ");
            foreach (var key in _configuration.AsEnumerable())
            {
                sb.AppendLine($"{key.Key} : {key.Value}");
            }

            return Content(sb.ToString(), "text/plain");
        }

        [Route("/key/{key}")]
        public IActionResult Key([FromRoute]string key)
        {
            var apiSettings = new ApiSettings();
            _configuration.GetSection("ApiSettings").Bind(apiSettings);
            return Content(_configuration[key] ?? "Not found", "text/plain");
        }

        [Route("/apisettings")]
        public IActionResult Apisettings([FromRoute] string key)
        {
            return Json(apiSettings);
        }
    }
}
