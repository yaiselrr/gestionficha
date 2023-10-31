using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    [Table("PRODUCTO")]
    public class Producto
    {
        [Key]
        public int Id {get; set; }
        
        [Required(ErrorMessage = "Por favor teclee el campo Nombre")]
        [StringLength(150)]
        [Column("NOMBRE", TypeName = "VARCHAR(150)")]
        public string Nombre { get; set; }
        
        [StringLength(500)]
        [Column("DESCRIPCION", TypeName = "VARCHAR(500)")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Por favor teclee el campo Precio")]
        [Column("PRECIO", TypeName = "numeric")]
        public decimal Precio { get; set; }
    }
}