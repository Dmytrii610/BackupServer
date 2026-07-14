using BackupServer.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackupServerContext = BackupServer.API.Data.BackupServerContext;

namespace BackupServer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly BackupServerContext context;
        private readonly ILogger<ClientsController> logger;

        public ClientsController(BackupServerContext context, ILogger<ClientsController> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult> GetClientsAsync()
        {
            var clients = await context.Clients
                .Include("ClientType")
                .Include(c => c.Hosts)
                .ToListAsync();
            logger.LogInformation("Get all clients.");
            return Ok(clients);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetClientByIdAsync(int id)
        {
            var client = await context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
            if (client == null)
            {
                logger.LogWarning($"Client with ID: {id} is not found.");
                return NotFound();
            }
            logger.LogInformation($"Getting client with ID: {id}");
            return Ok(client);
        }
        [HttpPost]
        public async Task<ActionResult> CreateClientAsync([FromBody] Client client)
        {
            client.CreatedAt = DateTime.UtcNow;
            context.Clients.Add(client);
            await context.SaveChangesAsync();
            logger.LogInformation($"Created a new user at: {client.CreatedAt}");
            return CreatedAtAction(
                nameof(GetClientByIdAsync),
                new { id = client.ClientId },
                client
            );
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClient(int id, [FromBody] Client client)
        {
            if(id != client.ClientId)
            {
                logger.LogWarning($"ID missmacth: provided {id} <---> client ID {client.ClientId}");
                return BadRequest();
            }
            context.Entry(client).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await context.Clients.AnyAsync(c => c.ClientId == id)) return NotFound();
                throw;
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClientByIdAsync(int id)
        {
            var client = await context.Clients.FindAsync(id);
            if(client == null)
            {
                return NotFound();
            }
            context.Clients.Remove(client);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
