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
        private readonly IProductoRepositorio _repo;
        
        public ProductoController(IProductoRepositorio repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        { 
            var producto = await _repo.GetProductosAsync();

            return Ok(producto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            return await _repo.GetProductoAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUpdateCliente(Producto producto)
        {
            return await _repo.CreateUpdateProducto(producto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCliente(int id)
        {
            return await _repo.DeleteProducto(id);
        }
    }
}