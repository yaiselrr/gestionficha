using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PersonaController(ApplicationDbContext db)
        {
            _db = db;

        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> GetPersonas()
        { 
            var persona = await _db.Persona.ToListAsync();

            return Ok(persona);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            return await _db.Persona.FindAsync(id);
        }
    }
}