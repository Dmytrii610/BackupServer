using BackupServer.API.Data;
using BackupServer.API.DTOs;
using BackupServer.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackupServer.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HostController : ControllerBase
    {
        private ILogger<HostController> logger;
        private BackupServerContext context;

        public HostController(BackupServerContext context, ILogger<HostController> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HostSummaryDto>>> GetHostsAsync() { throw new NotImplementedException(); }
        [HttpGet("{id}")]
        public async Task<ActionResult<HostSummaryDto>> GetHostByIdAsync(int id) { throw new NotImplementedException(); }
        [HttpPost]
        public async Task<IActionResult> CreateHostAsync(HostSummaryDto host) { throw new NotImplementedException(); }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHostAsync(int id) { throw new NotImplementedException(); }
        [HttpDelete]
        public async Task<IActionResult> DeleteHost() { throw new NotImplementedException(); }
    }
}
