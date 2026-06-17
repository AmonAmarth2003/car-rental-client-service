using Client.API.DTO;
using Client.API.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Client.API.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        // GET /clients
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _service.GetByIdAsync(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        // POST /clients
        [HttpPost]
        public async Task<IActionResult> Post(CreateClientDto client)
        {
            var created = await _service.CreateAsync(client);
            return Created("", created);
        }

        // PATCH /clients/{id}/status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] ClientStatus status)
        {
            try
            {
                var updated = await _service.UpdateStatusAsync(id, status);

                if (updated == null)
                    return NotFound();

                return Ok(updated);
            }
            catch (Exception)
            {
                return StatusCode(500, "Unable to communicate with Rental Service. Fail status update");
            }
        }
    }
}