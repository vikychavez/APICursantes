using APICursantes.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<int> CursantesInsertarAsync(CursanteInsertDto dto)
        {
            var nroCursante = new SqlParameter("@NroCursante", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            await _context.Database.ExecuteSqlRawAsync(
                @"EXEC CursantesInsertar 
        @Apellido,
        @Nombre,
        @TipoDoc,
        @DNI,
        @FechaNac,
        @Direccion,
        @Celular,
        @TelefonoOpcional,
        @Email,
        @Ciudad,
        @Obser,
        @Foto,
        @NroCursante OUTPUT",

                new SqlParameter("@Apellido", dto.Apellido),
                new SqlParameter("@Nombre", dto.Nombre),
                new SqlParameter("@TipoDoc", dto.TipoDoc),
                new SqlParameter("@DNI", dto.DNI),
                new SqlParameter("@FechaNac", dto.FechaNac),
                new SqlParameter("@Direccion", dto.Direccion),
                new SqlParameter("@Celular", dto.Celular),
                new SqlParameter("@TelefonoOpcional", dto.TelefonoOpcional),
                new SqlParameter("@Email", dto.Email),
                new SqlParameter("@Ciudad", dto.Ciudad),
                new SqlParameter("@Obser", dto.Obser),
                new SqlParameter("@Foto", dto.Foto),
                nroCursante
            );

            return (int)nroCursante.Value;
        }
    }
}
