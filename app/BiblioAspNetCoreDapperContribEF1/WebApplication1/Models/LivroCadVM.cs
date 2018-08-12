using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class LivroCadVM : _Base.CadVM
    {
        public int LivroId { get; set; } = 0;
        public string Titulo { get; set; } = "";
        public List<AutorVM> Autores { get; set; }

        public LivroCadVM()
        {
            Autores = new List<AutorVM>();
        }
    }
}
