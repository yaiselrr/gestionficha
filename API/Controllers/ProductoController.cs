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
    public class ProductoController : ControllerBase
    {
        private readonly IRepositorio<Producto> _repo;
        
        public ProductoController(IRepositorio<Producto> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetAll()
        { 
            var producto = await _repo.GetAllAsync();

            return Ok(producto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            return await _repo.GetAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(Producto producto)
        {
            return await _repo.Create(producto);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update(Producto producto)
        {
            return await _repo.Update(producto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _repo.Delete(id);
        }
    }
}