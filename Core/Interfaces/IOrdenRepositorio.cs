using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces
{
    public interface IOrdenRepositorio
    {
        Task<Orden> GetOrdenAsync(int id);
        Task<IReadOnlyList<Orden>> GetOrdensAsync();
        Task<bool> CreateUpdateOrden(Orden Orden);
        Task<bool> DeleteOrden(int id);
    }
}