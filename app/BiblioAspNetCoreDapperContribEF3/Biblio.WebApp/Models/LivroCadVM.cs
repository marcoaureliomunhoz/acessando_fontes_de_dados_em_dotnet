using Biblio.DomainApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblio.WebApp.Models
{
    public class LivroCadVM : _Base.CadVM
    {
        public int LivroId { get; set; } = 0;
        public string Titulo { get; set; } = "";
        public int EditoraId { get; set; } = 0;
        public List<Editora> Editoras { get; set; }
        public List<Autor> Autores { get; set; }
    }
}
