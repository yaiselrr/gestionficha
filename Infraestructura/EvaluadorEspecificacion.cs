using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificaciones;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class EvaluadorEspecificacion<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IEspecificacion<T> espec)
        {
            var query = inputQuery;

            if (espec.Filtro != null)
            {
                query = query.Where(espec.Filtro);
            }

            query = espec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}