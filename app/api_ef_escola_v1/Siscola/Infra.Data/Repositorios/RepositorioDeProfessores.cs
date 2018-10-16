using Microsoft.EntityFrameworkCore;
using Siscola.Dominio;
using Siscola.Dominio.Dtos;
using Siscola.Dominio.Repositorios;
using Siscola.Dominio.Repositorios._Base;
using Siscola.Infra.Data.Repositorios._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscola.Infra.Data.Repositorios
{
    public class RepositorioDeProfessores : Repositorio<Professor>, IRepositorioDeProfessores
    {
        public RepositorioDeProfessores(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public new List<Professor> Listar()
        {
            return this.Set()
                    .ToList();
        }

        public List<ItemListaDeProfessor> ListarItens()
        {
            try
            {
                var lista = from xprofessor in (from professor in this.Ctx().Set<Professor>()
                                                join pessoaFisica in this.Ctx().Set<PessoaFisica>() on professor.PessoaFisicaId equals pessoaFisica.Id
                                                select new { professor, pessoaFisica })
                            from xendereco in (from endereco in this.Ctx().Set<Endereco>()
                                               join cidade in this.Ctx().Set<Cidade>() on endereco.CidadeId equals cidade.Id
                                               select new { endereco, cidade }).Where(xendereco => xendereco.endereco.PessoaFisicaId == xprofessor.pessoaFisica.Id).Take(1)
                            select new ItemListaDeProfessor
                            {
                                Id = xprofessor.professor.Id,
                                PessoaFisicaId = xprofessor.professor.PessoaFisicaId,
                                NomeSocial = xprofessor.pessoaFisica.NomeSocial,
                                NomeCivil = xprofessor.pessoaFisica.NomeCivil,
                                Logradouro = xendereco.endereco.Logradouro,
                                Numero = xendereco.endereco.Numero,
                                Bairro = xendereco.endereco.Bairro,
                                Cidade = xendereco.cidade.Nome,
                                UF = xendereco.cidade.UF
                            };

                var retorno = lista.ToList();
                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public override int Salvar(Professor entidade)
        {
            if (entidade.Id == 0)
            {
                this.Set().Add(entidade);
                return entidade.Id;
            }

            var cadastro = this.Retornar(entidade.Id);
            if (cadastro != null)
            {
                //cadastro.AlterarTitulo(entidade.Titulo);
                //cadastro.AlterarDetalhes(entidade.Detalhes);
                return 1;
            }

            return 0;
        }
    }
}
