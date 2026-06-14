using Microsoft.AspNetCore.Mvc;

namespace Exemplo
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private IServExemplo _servExemplo;

        public ClientController()
        {
            _servExemplo = new ServExemplo();
        }

        [Route("/api/[Controller]/{id}")]
        [HttpGet]
        public IActionResult Client(int id)
        {
            try
            {
                var exemploDto = _servExemplo.Exemplo(id);

                return Ok(exemploDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
