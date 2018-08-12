using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaAspNetCoreEF1.Models
{
    public class Estado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UF { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }
    }
}
