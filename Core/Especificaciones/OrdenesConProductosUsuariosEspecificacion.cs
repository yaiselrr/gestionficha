using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Especificaciones
{
    public class OrdenesConProductosUsuariosEspecificacion : EspecificacionBase<Orden>
    {
        public OrdenesConProductosUsuariosEspecificacion()
        {
            AgregarInclude(x => x.Persona);
            AgregarInclude(x => x.Producto);
        }

        public OrdenesConProductosUsuariosEspecificacion(int id) : base(x => x.Id == id)
        {
            AgregarInclude(x => x.Persona);
            AgregarInclude(x => x.Producto);
        }
    }
}