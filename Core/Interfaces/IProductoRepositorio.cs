using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces
{
    public interface IProductoRepositorio
    {
        Task<Producto> GetProductoAsync(int id);
        Task<IReadOnlyList<Producto>> GetProductosAsync();
        Task<bool> CreateUpdateProducto(Producto producto);
        Task<bool> DeleteProducto(int id);
    }
}