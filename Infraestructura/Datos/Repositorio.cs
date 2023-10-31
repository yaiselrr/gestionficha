using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificaciones;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public Repositorio(ApplicationDbContext db)
        {
            _db = db;

        }
        public async Task<bool> Create(T obj)
        {
            _db.Add(obj);

            try
            {
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var obj = await _db.Set<T>().FindAsync(id);
            
            _db.Remove(obj);

            try
            {
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllEspecification(IEspecificacion<T> espec)
        {
            return await  AplicarEspecificacion(espec).ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEspecification(IEspecificacion<T> espec)
        {
            return await  AplicarEspecificacion(espec).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(T obj)
        {
            _db.Entry(obj).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private IQueryable<T> AplicarEspecificacion(IEspecificacion<T> espec)
        {
            return EvaluadorEspecificacion<T>.GetQuery(_db.Set<T>().AsQueryable(), espec);
        }
    }
}