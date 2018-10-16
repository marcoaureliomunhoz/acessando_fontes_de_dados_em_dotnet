using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio
{
    public class Cidade : Entidade
    {
        public string Nome { get; private set; }
        public string UF { get; private set; }

        public virtual IList<Endereco> Enderecos { get; private set; } = new List<Endereco>();

        protected Cidade()
        {
        }

        public Cidade(string nome, string uf)
        {
            Nome = nome;
            UF = uf;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarUF(string uf)
        {
            UF = uf;
        }
    }
}
