using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class AutorCheckBox : AutorVM
    {
        public bool Selected { get; set; } = false;
    }

    public class LivroAutorCadVM
    {
        public int LivroId { get; set; }
        public List<AutorCheckBox> Autores { get; set; }

        public LivroAutorCadVM()
        {
            Autores = new List<AutorCheckBox>();
        }
    }
}
