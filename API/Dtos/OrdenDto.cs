using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OrdenDto
    {
        public int Id {get; set; }
        public DateTime Fecha { get; set; }
        public string Direccion { get; set; }
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }
        public string Persona { get; set; }
    }
}