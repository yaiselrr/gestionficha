using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepositorio _repo;
        
        public PersonaController(IPersonaRepositorio repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> GetPersonas()
        { 
            var persona = await _repo.GetPersonasAsync();

            return Ok(persona);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            return await _repo.GetPersonaAsync(id);
        }
    }
}