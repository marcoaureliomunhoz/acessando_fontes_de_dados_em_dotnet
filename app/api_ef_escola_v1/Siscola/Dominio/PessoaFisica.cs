using Siscola.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio
{
    public class PessoaFisica : Entidade
    {
        public string NomeCivil { get; private set; }
        public string NomeSocial { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public DateTime DataDeNascimento { get; private set; }

        public virtual IList<Endereco> Enderecos { get; private set; } = new List<Endereco>();
        public virtual IList<Matricula> Matriculas { get; private set; } = new List<Matricula>();
        //public virtual IList<Professor> Professores { get; private set; } = new List<Professor>();

        protected PessoaFisica()
        {
        }

        public PessoaFisica(string nomeCivil, string nomeSocial, string cpf, string rg, DateTime dataDeNascimento)
        {
            NomeCivil = nomeCivil;
            NomeSocial = nomeSocial;
            CPF = cpf;
            RG = rg;
            DataDeNascimento = dataDeNascimento;
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Enderecos.Add(endereco);
        }
    }
}
