using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Persona
    {
        [Key]
        [Column("N_INTERNO")]
        public int NInterno { get; set; }

        [StringLength(60)]
        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [StringLength(60)]
        [Column("APELLIDOS")]
        public string Apellidos { get; set; }

        [StringLength(15)]
        [Column("USUARIO_RED")]
        public string UsuarioRed { get; set; }

        [Column("N_INTERNO_RESP", TypeName = "numeric")]
        public decimal? NInternoResp { get; set; }

        [Column("IS_ADMIN")]
        public bool IsAdmin { get; set; } = false;
    }
}