using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaAspNetCoreEF1.Models
{
    public class Contato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContatoId { get; set; }

        [StringLength(50)]
        public string Nome { get; set; } = "";

        [StringLength(50)]
        public string Valor { get; set; } = "";

        [StringLength(2)]
        public string UF { get; set; } = "";
    }
}
