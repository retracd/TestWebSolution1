using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using SharedDependencies.Models;

namespace TestWebApplication1.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase // contacts the 2nd web service's (TestWebApplication2) simple POST function localhost:6001/message
    {
        private readonly IHttpClientFactory _clientFactory;

        public RequestController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> SendData()
        {
            var client = _clientFactory.CreateClient();

            var messageData = new MessageData { 
                Message = "Hello from TestWebApplication1", 
                Number = 42,
                Time = DateTimeOffset.Now
            };
            var response = await client.PostAsJsonAsync("https://localhost:6001/message", messageData);

            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return Ok($"Response from TestWebApplication2 reads: {message}");
            }
            return StatusCode((int)response.StatusCode, "Failed to get a response from TestWebApplication2");
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class ExternalController : ControllerBase // contacts an external API (not one of the locally hosted)
    {
        private readonly IHttpClientFactory _clientFactory;

        public ExternalController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> ContactAPI()
        {
            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync("https://catfact.ninja/fact");

            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return Ok($"Response from \"https://catfact.ninja/fact\" reads: {JsonDocument.Parse(message).RootElement.GetProperty("fact").GetString()}");
            }
            return StatusCode((int)response.StatusCode, "Failed to get a response from \"https://catfact.ninja/fact\"");
        }
    }
}