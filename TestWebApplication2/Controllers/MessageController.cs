using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedDependencies.Data;
using SharedDependencies.Models;

namespace TestWebApplication2.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase { // original function hosted on localhost:6001 - contains a GET and a POST method
        [HttpGet] // GET method is mostly just for testing purposes
        public IActionResult GetMessage() {
            return Ok("You successfully sent a GET request to this address and all you got back was this lousy message.");
        }

        [HttpPost] // this POST method is what the RequestController in the 1st webapp contacts
        public IActionResult PostMessage([FromBody] MessageData messageData) {
            return Ok($"Data from POST message received successfully, Message: {messageData.Message}; Number: {messageData.Number}; Time: {messageData.Time}");
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase // 2nd class which interfaces with the SQL database - contains a GET and a POST method...
    {                                            // meant to be interfaced with externally, ie via postman or bruno
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")] // GET method accepts an id which correlates to the PK of the table in the SQL db, returns data at that id
        public async Task<IActionResult> GetTestData(int id)
        {
            var data = await _context.DbDatas.FirstOrDefaultAsync(d => d.id == id);
            
            if (data == null) {
                return NotFound();
            }
            
            return Ok(data);
        }

        [HttpPost] // POST method for inserting data into the database - in the production build, much more input validation would be seen below
        public async Task<IActionResult> PostTestData([FromBody] DbData newData) { 
            if (newData == null) {
                return BadRequest("Invalid Data");
            }

            _context.DbDatas.Add(newData);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTestData), new { id = newData.id }, newData);
        }
    }
}