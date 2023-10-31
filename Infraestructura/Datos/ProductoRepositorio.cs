using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepositorio(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> CreateUpdateProducto(Producto producto)
        {
            var prod = await _db.Producto.FindAsync(producto.Id);

            if (prod != null)
            {
                prod.Nombre = producto.Nombre;
                prod.Descripcion = producto.Descripcion;
                prod.Precio = producto.Precio;

                _db.Update(prod);

                await _db.SaveChangesAsync();

                return true;

            }
            else
            {
                await _db.Producto.AddAsync(producto);
                await _db.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var producto = await _db.Producto.FindAsync(id);

            if (producto == null)
            {
                return false;
            }

            _db.Remove(producto);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Producto> GetProductoAsync(int id)
        {
            return await _db.Producto.FirstOrDefaultAsync(p => p.Id == id); ;
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await _db.Producto.ToListAsync();
        }
    }
}