using APICursantes.Models;
using APICursantes.Models.DTO;
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
        public async Task<List<Cursante>> CursantesDeUnCurso(int nrocuro)
        {
            return await _context.Cursantes
                .FromSqlRaw("EXEC CursantesDeUnCurso @NroCurso",
                    new SqlParameter("@NroCurso", (object?)nrocuro)
                   
                )
                .ToListAsync();
        }
        public async Task<List<Cursante>> CursantesSeleccionar(int? nrocursante, string? nrodoc, string? nombre)
        {
            return await _context.Cursantes
                .FromSqlRaw("EXEC CursantesSeleccionar @NroCursante,@NroDoc,@Nombre",
                    new SqlParameter("@NroCursante", (object?)nrocursante ?? DBNull.Value),
                    new SqlParameter("@NroDoc", (object?)nrodoc ?? DBNull.Value),
                    new SqlParameter("@Nombre", (object?)nombre ?? DBNull.Value)

                )
                .ToListAsync();
        }
        public async Task<int> CursantesActualizar(int NroCursante,CursanteDTO cursante)
        {
            var filasAfectadas =await _context.Database
                 .ExecuteSqlRawAsync("EXEC CursantesActualizar @NroCursante,@Apellido,@Nombre,@TipoDoc,@DNI," +
                 "@FechaNac,@Direccion,@Celular,@TelefonoOpcional, @EMail, @Ciudad, @Obser, @Foto",
                     new SqlParameter("@NroCursante", cursante.NroCursante),
                     new SqlParameter("@Apellido", cursante.Apellido),
                     new SqlParameter("@Nombre", cursante.Nombre),
                     new SqlParameter("@TipoDoc", int.Parse(cursante.TipoDoc)),
                     new SqlParameter("@DNI", cursante.DNI),
                     new SqlParameter("@FechaNac", cursante.FechaNac),
                     new SqlParameter("@Direccion", cursante.Direccion),
                     new SqlParameter("@Celular", cursante.Celular),
                     new SqlParameter("@TelefonoOpcional", cursante.TelefonoOpcional),
                     new SqlParameter("@EMail", cursante.Email),
                     new SqlParameter("@Ciudad", int.Parse(cursante.Ciudad)),
                     new SqlParameter("@Obser", cursante.ObserSistemaAnterior),
                     new SqlParameter("@Foto", cursante.Foto)

                 );

            return filasAfectadas;
                      
        }
        

    }
}

