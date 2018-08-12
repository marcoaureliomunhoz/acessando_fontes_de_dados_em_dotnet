using BiblioAspNetCoreEF1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioAspNetCoreEF1.ViewModels
{
    public class LivroVM : Livro
    {
        public int EditoraId { get; set; } = 0;
        public ICollection<Autor> Autores { get; set; }

        public LivroVM()
        {
        }

        public LivroVM(Livro livro, ICollection<Autor> autores)
        {
            if (livro != null)
            {
                BaseVM.CopyToTargeFromSource<LivroVM, Livro>(this, livro);
                this.EditoraId = this.Editora.EditoraId;
            }
            this.Autores = autores;
        }
    }
}
