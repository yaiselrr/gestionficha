using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificaciones;

namespace Core.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<T> GetEspecification(IEspecificacion<T> espec);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllEspecification(IEspecificacion<T> espec);
        Task<bool> Create(T obj);
        Task<bool> Update(T obj);
        Task<bool> Delete(int id);
    }
}