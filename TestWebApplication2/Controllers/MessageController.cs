using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedDependencies.Data;
using SharedDependencies.Models;

namespace TestWebApplication2.Controller
{
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

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestData(int id)
        {
            var data = await _context.DbDatas.FirstOrDefaultAsync(d => d.id == id);
            
            if (data == null) {
                return NotFound();
            }
            
            return Ok(data);
        }
    }
}