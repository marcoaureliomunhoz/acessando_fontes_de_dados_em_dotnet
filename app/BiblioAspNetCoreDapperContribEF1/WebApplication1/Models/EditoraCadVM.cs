using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EditoraCadVM : _Base.CadVM
    {
        public int EditoraId { get; set; } = 0;
        public string Nome { get; set; } = "";
        public List<LivroVM> Livros { get; set; }

        public EditoraCadVM()
        {
            Livros = new List<LivroVM>();
        }
    }
}
