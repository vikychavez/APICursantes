

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

        //[HttpGet]
        //public async Task<ActionResult<List<Cursante>>> GetCursantes()
        //{
        //    var cursantes = await _repository.ObtenerCursantesAsync();

        //    return Ok(cursantes);
        //}
        
        [HttpGet]
        public async Task<IActionResult> CursantesSeleccionar(int? nrocursante, string? nrodoc, string? nombre)
        {
            var data = await _repository.CursantesSeleccionar(nrocursante, nrodoc, nombre);
            return Ok(data);
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
        [HttpGet("nrocursao/{nrocurso}")]
        public async Task<IActionResult> CursantesDeUnCurso(int nrocurso)
        {
            var data = await _repository.CursantesDeUnCurso(nrocurso);
            return Ok(data);
        }
        [HttpPut("{nrocursante}")]
        public async Task<IActionResult> CursantesActualizar(int nrocursante, CursanteDTO  cursante)
        {
            var actualizado = await _repository.CursantesActualizar(nrocursante,cursante);
            return NoContent();
        }
    }
}
