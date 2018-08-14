using Biblio.DomainApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblio.WebApp.Models
{
    public class EditoraCadVM : _Base.CadVM
    {
        public int EditoraId { get; set; } = 0;
        public string Nome { get; set; } = "";
        public List<Livro> Livros { get; set; } 
    }
}
