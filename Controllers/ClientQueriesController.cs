using ClientQueriesAPI.Data;
using ClientQueriesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientQueriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientQueriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientQueriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //  POST: /api/clientqueries
        [HttpPost]
        public async Task<IActionResult> CreateClientQuery([FromBody] ClientQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.ClientQueries.Add(query);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Thank you! Your request has been received. Our team will contact you soon."
            });
        }

        //  GET: /api/clientqueries (optional - admin use)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientQuery>>> GetClientQueries()
        {
            var queries = await _context.ClientQueries
                .OrderByDescending(q => q.CreatedAt)
                .ToListAsync();

            return Ok(queries);
        }
    }
}
