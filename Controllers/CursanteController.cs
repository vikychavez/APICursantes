

using APICursantes.Models;
using APICursantes.Models.DTO;
using APICursantes.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using Microsoft.Data.SqlClient;
using System.Data;

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
        
        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] CursanteInsertDto dto)
        {
            int nroCursante = await _repository.CursantesInsertarAsync(dto);

            return Ok(new
            {
                NroCursante = nroCursante,
                mensaje = "Cursante creado correctamente"
            });
        }
    }
}
