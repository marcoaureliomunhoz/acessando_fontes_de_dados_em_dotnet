using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio
{
    public class Professor : Entidade
    {
        public int PessoaFisicaId { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }

        protected Professor()
        {
        }

        public Professor(int pessoaFisicaId, string usuario, string senha)
        {
            PessoaFisicaId = pessoaFisicaId;
            Usuario = usuario;
            Senha = senha;
        }
    }
}
