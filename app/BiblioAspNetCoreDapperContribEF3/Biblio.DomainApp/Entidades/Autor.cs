using System;
using System.Collections.Generic;
using System.Text;

namespace Biblio.DomainApp.Entidades
{
    public class Autor
    {
        public int AutorId { get; private set; } = 0;
        public string Nome { get; private set; } = "";

        private Autor()
        {
        }

        public Autor(string nome)
        {
            Nome = nome;
        }

        public void Alterar(string nome)
        {
            Nome = nome;
        }
    }
}
