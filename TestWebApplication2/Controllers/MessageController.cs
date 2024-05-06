using Microsoft.AspNetCore.Mvc;
using SharedDependencies;

namespace TestWebApplication2.Controller {
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase {
        [HttpGet]
        public IActionResult GetMessage() {
            return Ok("You successfully sent a GET request to this address and all you got back was this lousy message.");
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] MessageData messageData) {
            return Ok($"Data from POST message received successfully, Message: {messageData.Message}; Number: {messageData.Number}; Time: {messageData.Time}");
        }
    }
}