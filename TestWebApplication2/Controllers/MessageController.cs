using Microsoft.AspNetCore.Mvc;

namespace TestWebApplication2.Controller {
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase {
        [HttpGet]
        public IActionResult GetMessage() {
            return Ok("You successfully sent a GET request to this address and all you got back was this lousy message.");
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] string message) {
            return Ok($"Data from POST message received successfully: {message}");
        }
    }
}