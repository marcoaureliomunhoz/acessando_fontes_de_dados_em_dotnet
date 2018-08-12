using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaAspNetCoreDapper1.Models
{
    public class Contato
    {
        public int ContatoId { get; set; } = 0;
        public string Nome { get; set; } = "";
        public string Valor { get; set; } = "";
        public string UF { get; set; } = "";
    }
}
