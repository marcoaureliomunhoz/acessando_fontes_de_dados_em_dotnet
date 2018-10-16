using Microsoft.EntityFrameworkCore;
using Siscola.Dominio;
using Siscola.Dominio.Repositorios;
using Siscola.Dominio.Repositorios._Base;
using Siscola.Infra.Data.Repositorios._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Infra.Data.Repositorios
{
    public class RepositorioDeEnderecos : Repositorio<Endereco>, IRepositorioDeEnderecos
    {
        public RepositorioDeEnderecos(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public new List<Endereco> Listar()
        {
            return this.Set()
                    .Include(endereco => endereco.Cidade)
                    .ToList();
        }

        public override int Salvar(Endereco entidade)
        {
            if (entidade.Id == 0)
            {
                this.Set().Add(entidade);
                return entidade.Id;
            }

            var cadastro = this.Retornar(entidade.Id);
            if (cadastro != null)
            {
                cadastro.AlterarLogradouro(entidade.Logradouro);
                cadastro.AlterarBairro(entidade.Bairro);
                cadastro.AlterarNumero(entidade.Numero);
                cadastro.AlterarTipo(entidade.Tipo);
                cadastro.AlterarCidade(entidade.Cidade);
                return 1;
            }

            return 0;
        }
    }
}
