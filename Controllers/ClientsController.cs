using BackupServer.API.DTOs;
using BackupServer.API.Models;
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
        public async Task<ActionResult<IEnumerable<ClientDetailsDto>>> GetClientsAsync()
        {
           var clients = await context.Clients
                .Include(c => c.ClientType)
                .Include(c => c.Hosts)
                .ToListAsync();

            var dtos = clients.Select(c => new ClientDetailsDto
            {
                ClientId = c.ClientId,
                Name = c.Name,
                Surname = c.Surname,
                EmailContact = c.EmailContact,
                PhoneContact = c.PhoneContact,
                TaxID = c.TaxID,
                CreatedAt = c.CreatedAt,
                ClientTypeName = c.ClientType?.Type ?? "Unknown",
                Hosts = c.Hosts.Select(h => new HostSummaryDto
                {
                    HostId = h.HostId,
                    HostName = h.HostName,
                    HostIP = h.HostIP,
                    IsActive = h.IsActive
                }).ToList()
            });
            logger.LogInformation("Get all clients.");
            return Ok(dtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDetailsDto>> GetClientByIdAsync(int id)
        {
            var client = await context.Clients
                .Include(c => c.ClientType)
                .Include(c => c.Hosts)
                .FirstOrDefaultAsync(c => c.ClientId == id);
            if (client == null)
            {
                logger.LogWarning($"Client with ID: {id} is not found.");
                return NotFound();
            }
            var dto =new ClientDetailsDto
            {
                ClientId = client.ClientId,
                Name = client.Name,
                Surname = client.Surname,
                EmailContact = client.EmailContact,
                PhoneContact = client.PhoneContact,
                TaxID = client.TaxID,
                CreatedAt = client.CreatedAt,
                ClientTypeName = client.ClientType?.Type ?? "Unknown",
                Hosts = client.Hosts.Select(h => new HostSummaryDto
                {
                    HostId = h.HostId,
                    HostName = h.HostName,
                    HostIP = h.HostIP,
                    IsActive = h.IsActive
                }).ToList()
            };
            logger.LogInformation($"Get client with ID: {id}");
            return Ok(dto);
        }
        [HttpPost]
        public async Task<ActionResult<ClientCreateDto>> CreateClientAsync([FromBody] ClientCreateDto dtoClient)
        {
            var clientTypeExist = await context.ClientTypes
                .AnyAsync(ct => ct.IdType == dtoClient.ClientTypeId);
            if (!clientTypeExist)
                return BadRequest();

            var client = new Client
            {
                Name = dtoClient.Name,
                Surname = dtoClient.Surname,
                EmailContact = dtoClient.EmailContact,
                ClientTypeId = dtoClient.ClientTypeId,
                PhoneContact = dtoClient.PhoneContact,
                TaxID = dtoClient.TaxID,
                CreatedAt = DateTime.UtcNow
            };
            logger.LogInformation($"Created a new user at: {client.CreatedAt}");

            context.Clients.Add(client);
            await context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetClientByIdAsync),
                new { id = client.ClientId },
                client
            );
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientCreateDto dtoClient)
        {
            var client = await context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            client.Name = dtoClient.Name;
            client.Surname = dtoClient.Surname;
            client.EmailContact = dtoClient.EmailContact;
            client.PhoneContact = dtoClient.PhoneContact;
            client.TaxID = dtoClient.TaxID;

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
        public async Task<IActionResult> DeleteClientByIdAsync(int id)
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
