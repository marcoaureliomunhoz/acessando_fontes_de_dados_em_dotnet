using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio
{
    public class PessoaJuridica : Entidade
    {
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string CNPJ { get; private set; }
        public DateTime DataDeAbertura { get; private set; }

        protected PessoaJuridica()
        {
        }

        public PessoaJuridica(string razaoSocial, string nomeFantasia, string cnpj, DateTime dataDeAbertura)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            CNPJ = cnpj;
            DataDeAbertura = dataDeAbertura;
        }
    }
}
