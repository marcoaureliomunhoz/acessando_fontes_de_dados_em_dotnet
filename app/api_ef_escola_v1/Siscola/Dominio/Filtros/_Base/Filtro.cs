using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio.Filtros._Base
{
    public class Filtro
    {
        public int Id { get; set; } = 0;
        public string Nome { get; set; } = "";

        public string Ordenador { get; set; } = "";
        public bool OrdenarDecrescente { get; set; } = false;

        public int Pagina { get; set; } = 0;
        public int ItensPorPagina { get; set; } = 0;
    }
}
