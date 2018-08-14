using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblio.WebApp.Models._Base
{
    public class CadVM
    {
        public List<string> Problemas { get; set; }

        public CadVM()
        {
            Problemas = new List<string>();
        }
    }
}
