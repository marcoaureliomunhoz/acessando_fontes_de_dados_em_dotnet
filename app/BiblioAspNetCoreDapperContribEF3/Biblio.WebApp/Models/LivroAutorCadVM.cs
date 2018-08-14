using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblio.WebApp.Models
{
    public class AutorCheckBox 
    {
        public int AutorId { get; set; } = 0;
        public string Nome { get; set; } = "";
        public bool Selected { get; set; } = false;
    }

    public class LivroAutorCadVM
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public List<AutorCheckBox> Autores { get; set; }
        public List<string> Problemas { get; set; }

        public LivroAutorCadVM()
        {
            Autores = new List<AutorCheckBox>();
        }
    }
}
