using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    [Table("ORDEN")]
    public class Orden
    {
        [Key]
        public int Id {get; set; }

        [Required(ErrorMessage = "Por favor teclee el campo Fecha")]
        [Column("FECHA")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Por favor teclee el campo Dirección")]
        [StringLength(500)]
        [Column("DIRECCION")]
        public string Direccion { get; set; }
        
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        [Required(ErrorMessage = "Por favor teclee el campo Cantidad")]
        [Column("CANTIDAD", TypeName = "numeric")]
        public decimal Cantidad { get; set; }

        public int PersonaId { get; set;} 

        [ForeignKey("PersonaId")]
        public Persona Persona { get; set; }

        [Column("ES_GESTOR")]
        public bool EsGESTOR { get; set; } = false;
    }
}