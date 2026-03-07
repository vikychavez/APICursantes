

using APICursantes.Models;
using APICursantes.Models.DTO;
using APICursantes.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICursantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursanteController:ControllerBase
    {
        private readonly CursanteContext _context;
        private readonly CursanteRepository _repository;

        public CursanteController(CursanteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cursante>>> GetCursantes()
        {
            var cursantes = await _repository.ObtenerCursantesAsync();

            return Ok(cursantes);
        }

    }
}
