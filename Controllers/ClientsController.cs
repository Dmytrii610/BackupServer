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
                .Include(c => c == c.Hosts)
                .ToListAsync();

            return Ok(clients);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetClientByIdAsync(int id)
        {
            var client = await context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }
        [HttpPost]
        public async Task<ActionResult> CreateClientAsync([FromBody] Client client)
        {
            client.CreatedAt = DateTime.UtcNow;
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetClientByIdAsync),
                new { id = client.ClientId },
                client
            );
        }
    }
}
