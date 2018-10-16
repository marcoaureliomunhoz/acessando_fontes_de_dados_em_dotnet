using Siscola.Dominio._Base;
using Siscola.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Dominio
{
    public class Endereco : Entidade
    {
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Numero { get; private set; }

        public TipoEndereco Tipo { get; private set; }

        public int CidadeId { get; private set; }
        public virtual Cidade Cidade { get; private set; }

        public int PessoaFisicaId { get; set; }
        public virtual PessoaFisica PessoaFisica { get; private set; }

        protected Endereco()
        {
        }

        public Endereco(string logradouro, string bairro, string numero, Cidade cidade, TipoEndereco tipo)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Numero = numero;
            Cidade = cidade;
            Tipo = tipo;
        }

        public void AlterarLogradouro(string logradouro)
        {
            Logradouro = logradouro;
        }

        public void AlterarBairro(string bairro)
        {
            Bairro = bairro;
        }

        public void AlterarNumero(string numero)
        {
            Numero = numero;
        }

        public void AlterarCidade(Cidade cidade)
        {
            Cidade = cidade;
        }

        public void AlterarTipo(TipoEndereco tipo)
        {
            Tipo = tipo;
        }
    }
}
