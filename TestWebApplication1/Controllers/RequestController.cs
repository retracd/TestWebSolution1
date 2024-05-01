using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TestWebApplication1.Controller {
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase {
        private readonly IHttpClientFactory _clientFactory;

        public RequestController(IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        /*public async Task<IActionResult> GetResponseFromService()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:6001/message");

            if (response.IsSuccessStatusCode) { 
                var message = await response.Content.ReadAsStringAsync();
                return Ok($"Response from TestWebApplication2 reads: {message}");
            }
            return StatusCode((int)response.StatusCode, "Failed to get a response from TestWebApplication2");
        }*/
        public async Task<IActionResult> SendData() {
            var client = _clientFactory.CreateClient();
            var content = JsonContent.Create("Hello from TestWebApplication1");
            var response = await client.PostAsync("https://localhost:6001/message", content);

            if (response.IsSuccessStatusCode) { 
                var message = await response.Content.ReadAsStringAsync();
                return Ok($"Response from TestWebApplication2 reads: {message}");
            }
            return StatusCode((int)response.StatusCode, "Failed to get a response from TestWebApplication2");
        }
    }
}