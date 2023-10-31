using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class OrdenRepositorio : IOrdenRepositorio
    {
        private readonly ApplicationDbContext _db;
        public OrdenRepositorio(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> CreateUpdateOrden(Orden orden)
        {
            var ord = await _db.Orden.FindAsync(orden.Id);
            var per = await _db.Persona.FindAsync(orden.PersonaId);

            if (ord != null && per != null)
            {
                ord.Fecha = orden.Fecha;
                ord.Direccion = orden.Direccion;
                ord.ProductoId = orden.ProductoId;
                ord.Cantidad = orden.Cantidad;
                ord.PersonaId = orden.PersonaId;

                _db.Update(ord);

                await _db.SaveChangesAsync();

                return true;

            }
            else
            {
                await _db.Orden.AddAsync(ord);
                await _db.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> DeleteOrden(int id)
        {
            var orden = await _db.Orden.FindAsync(id);

            if (orden == null)
            {
                return false;
            }

            _db.Remove(orden);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Orden> GetOrdenAsync(int id)
        {
            return await _db.Orden
                            .Include(p => p.Producto)
                            .Include(pe => pe.Persona)
                            .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IReadOnlyList<Orden>> GetOrdensAsync()
        {
            return await _db.Orden
                            .Include(p => p.Producto)
                            .Include(pe => pe.Persona)
                            .ToListAsync();
        }
    }
}