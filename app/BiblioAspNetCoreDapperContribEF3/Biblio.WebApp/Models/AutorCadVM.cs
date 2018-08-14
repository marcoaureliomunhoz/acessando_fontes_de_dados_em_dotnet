using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblio.WebApp.Models
{
    public class AutorCadVM : _Base.CadVM
    {
        public int AutorId { get; set; } = 0;
        public string Nome { get; set; } = "";
    }
}
