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
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenRepositorio _repo;
        
        public OrdenController(IOrdenRepositorio repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Orden>>> GetOrdens()
        { 
            var Orden = await _repo.GetOrdensAsync();

            return Ok(Orden);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orden>> GetOrden(int id)
        {
            return await _repo.GetOrdenAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUpdateOrden(Orden orden)
        {
            return await _repo.CreateUpdateOrden(orden);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteOrden(int id)
        {
            return await _repo.DeleteOrden(id);
        }
    }
}