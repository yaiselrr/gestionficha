using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public PersonaRepositorio(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public async Task<Persona> GetPersonaAsync(int id)
        {
            return await _db.Persona.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IReadOnlyList<Persona>> GetPersonasAsync()
        {
            return await _db.Persona.ToListAsync();
        }
    }
}