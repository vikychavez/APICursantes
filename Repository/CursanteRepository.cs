using APICursantes.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APICursantes.Repository
{
    public class CursanteRepository
    {
        private readonly CursanteContext _context;

        public CursanteRepository(CursanteContext context)
        {
            _context = context;
        }

        public async Task<List<Cursante>> ObtenerCursantesAsync()
        {
            return await _context.Cursantes
                .FromSqlRaw("EXEC CursantesSeleccionar")
                .ToListAsync();
        }
    }
}
