using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces
{
    public interface IPersonaRepositorio
    {
        Task<Persona> GetPersonaAsync(int id);
        Task<IReadOnlyList<Persona>> GetPersonasAsync();
    }
}