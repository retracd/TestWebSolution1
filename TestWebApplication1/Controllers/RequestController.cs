using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SharedDependencies;

namespace TestWebApplication1.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
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
                Number = 68,
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
}