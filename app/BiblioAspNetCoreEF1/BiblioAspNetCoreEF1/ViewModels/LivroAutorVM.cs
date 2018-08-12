using BiblioAspNetCoreEF1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioAspNetCoreEF1.ViewModels
{
    public class AutorCheckBox : Autor
    {
        public bool Selected { get; set; } = false;
    }

    public class LivroAutorVM
    {
        public int LivroId { get; set; }
        public List<AutorCheckBox> Autores { get; set; }

        public LivroAutorVM()
        {
            Autores = new List<AutorCheckBox>();
        }
    }
}
