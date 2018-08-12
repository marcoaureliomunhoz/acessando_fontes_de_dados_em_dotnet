using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaAspNetCoreDapper1.Models
{
    [Table("dbo.Contato")]
    public class Contato
    {
        [Key]
        public int ContatoId { get; set; } = 0;
        public string Nome { get; set; } = "";
        public string Valor { get; set; } = "";
        public string UF { get; set; } = "";
    }
}
