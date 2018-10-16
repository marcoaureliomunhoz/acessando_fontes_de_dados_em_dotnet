using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Siscola.Dominio;
using Siscola.Dominio.Enums;
using Siscola.Dominio.Repositorios;
using Siscola.Dominio.Repositorios._Base;

namespace Siscola.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IRepositorioDeEspecialidades repositorioDeEspecialidades;
        private readonly IRepositorioDeDisciplinas repositorioDeDisciplinas;
        private readonly IRepositorioDeCidades repositorioDeCidades;
        private readonly IRepositorioDeCursos repositorioDeCursos;
        private readonly IRepositorioDePessoasFisicas repositorioDePessoasFisicas;
        private readonly IRepositorioDeTurmas repositorioDeTurmas;
        private readonly IRepositorioDeMatriculas repositorioDeMatriculas;
        private readonly IRepositorioDeEnderecos repositorioDeEnderecos;
        private readonly IRepositorioDeProfessores repositorioDeProfessores;
        private readonly IUnitOfWork unitOfWork;

        public ValuesController(
            IRepositorioDeEspecialidades repositorioDeEspecialidades,
            IRepositorioDeDisciplinas repositorioDeDisciplinas,
            IRepositorioDeCidades repositorioDeCidades,
            IRepositorioDeCursos repositorioDeCursos,
            IRepositorioDePessoasFisicas repositorioDePessoasFisicas,
            IRepositorioDeTurmas repositorioDeTurmas,
            IRepositorioDeMatriculas repositorioDeMatriculas,
            IRepositorioDeEnderecos repositorioDeEnderecos,
            IRepositorioDeProfessores repositorioDeProfessores,
            IUnitOfWork unitOfWork
        ) {
            this.repositorioDeEspecialidades = repositorioDeEspecialidades;
            this.repositorioDeDisciplinas = repositorioDeDisciplinas;
            this.repositorioDeCidades = repositorioDeCidades;
            this.repositorioDeCursos = repositorioDeCursos;
            this.repositorioDePessoasFisicas = repositorioDePessoasFisicas;
            this.repositorioDeTurmas = repositorioDeTurmas;
            this.repositorioDeMatriculas = repositorioDeMatriculas;
            this.repositorioDeEnderecos = repositorioDeEnderecos;
            this.repositorioDeProfessores = repositorioDeProfessores;
            this.unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            //remove

            repositorioDeProfessores.RemoverTodos();
            repositorioDeEnderecos.RemoverTodos();
            repositorioDeMatriculas.RemoverTodos();
            repositorioDeTurmas.RemoverTodos();
            repositorioDePessoasFisicas.RemoverTodos();
            repositorioDeDisciplinas.RemoverTodos();
            repositorioDeEspecialidades.RemoverTodos();
            repositorioDeCidades.RemoverTodos();
            repositorioDeCursos.RemoverTodos();

            //armazena

            _cidades.ForEach(x => repositorioDeCidades.Salvar(x));
            _especialidades.ForEach(x => repositorioDeEspecialidades.Salvar(x));
            _disciplinas.ForEach(x => repositorioDeDisciplinas.Salvar(x));            
            AdicionarDisciplinasAosCursos();
            _cursos.ForEach(x => repositorioDeCursos.Salvar(x));
            AdicionarEnderecosParaAsPessoasFisicas();
            _pessoasFisicas.ForEach(x => repositorioDePessoasFisicas.Salvar(x));
            _turmas.ForEach(x => repositorioDeTurmas.Salvar(x));
            _matriculas.ForEach(x => repositorioDeMatriculas.Salvar(x));            

            unitOfWork.Commit();

            foreach (var matricula in _matriculas)
            {
                matricula.DefinirRA();
                repositorioDeMatriculas.Salvar(matricula);
            }

            PrepararProfessores();
            _professores.ForEach(x => repositorioDeProfessores.Salvar(x));

            return DateTime.Now.ToString();
        }

        private void AdicionarDisciplinasAosCursos()
        {
            var curso5aSerie = _cursos.First(x => x.Titulo == "5ª Série");
            curso5aSerie.AdicionarDisciplina(new DisciplinaCurso
            {
                Curso = curso5aSerie,
                Disciplina = _disciplinas.First(x => x.Nome == "Português")
            });

            var curso6aSerie = _cursos.First(x => x.Titulo == "6ª Série");
            curso6aSerie.AdicionarDisciplina(new DisciplinaCurso
            {
                Curso = curso6aSerie,
                Disciplina = _disciplinas.First(x => x.Nome == "Português")
            });
            curso6aSerie.AdicionarDisciplina(new DisciplinaCurso
            {
                Curso = curso6aSerie,
                Disciplina = _disciplinas.First(x => x.Nome == "Matemática")
            });

            var curso7aSerie = _cursos.First(x => x.Titulo == "7ª Série");
            curso7aSerie.AdicionarDisciplina(new DisciplinaCurso
            {
                Curso = curso7aSerie,
                Disciplina = _disciplinas.First(x => x.Nome == "Português")
            });
            curso7aSerie.AdicionarDisciplina(new DisciplinaCurso
            {
                Curso = curso7aSerie,
                Disciplina = _disciplinas.First(x => x.Nome == "Matemática")
            });
            curso7aSerie.AdicionarDisciplina(new DisciplinaCurso
            {
                Curso = curso7aSerie,
                Disciplina = _disciplinas.First(x => x.Nome == "Biologia")
            });
        }

        private void AdicionarEnderecosParaAsPessoasFisicas()
        {
            var marco = _pessoasFisicas.First(x => x.NomeSocial == "Marco");
            marco.AdicionarEndereco(
                    new Endereco("Rua Fernão Sales", "Jardim Matilde", "114",
                        _cidades.First(x => x.Nome == "Regente Feijó"),
                        TipoEndereco.Residencial));

            var juliana = _pessoasFisicas.First(x => x.NomeSocial == "Juliana");
            juliana.AdicionarEndereco(
                    new Endereco("Rua Fernão Sales", "Barra Funda", "114",
                        _cidades.First(x => x.Nome == "Regente Feijó"),
                        TipoEndereco.Residencial));


            var nelsinho = _pessoasFisicas.First(x => x.NomeSocial == "Nelsinho");
            nelsinho.AdicionarEndereco(
                    new Endereco("Area da Casa do Dono", "Casinha", "1",
                        _cidades.First(x => x.Nome == "Regente Feijó"),
                        TipoEndereco.Residencial));

            var maria = _pessoasFisicas.First(x => x.NomeSocial == "Maria");
            maria.AdicionarEndereco(
                    new Endereco("Rua Oscar Peterlini 1", "São Bento", "211-A",
                        _cidades.First(x => x.Nome == "Regente Feijó"),
                        TipoEndereco.Residencial));
            maria.AdicionarEndereco(
                    new Endereco("Rua Oscar Peterlini 2", "São Bento", "211-B",
                        _cidades.First(x => x.Nome == "Regente Feijó"),
                        TipoEndereco.Residencial));

            var nega = _pessoasFisicas.First(x => x.NomeSocial == "Nega");
            nega.AdicionarEndereco(
                    new Endereco("Area da Casa do Dono", "Casinha", "2",
                        _cidades.First(x => x.Nome == "Regente Feijó"),
                        TipoEndereco.Residencial));
        }

        //------------------------------------ Registros ------------------------------------------

        private static List<Cidade> _cidades = new List<Cidade>()
        {
            new Cidade("Regente Feijó", "SP"),
            new Cidade("Indiana", "SP"),
            new Cidade("Presidente Prudente", "SP"),
            new Cidade("Maringá", "PR"),
            new Cidade("Londrina", "PR"),
            new Cidade("Campo Grande", "MS")
        };

        private static List<Especialidade> _especialidades = new List<Especialidade>()
        {
            new Especialidade("Exatas"),
            new Especialidade("Biológicas"),
            new Especialidade("Humanas")
        };

        private static List<Disciplina> _disciplinas = new List<Disciplina>()
        {
            new Disciplina("Matemática", "", _especialidades.First(x => x.Nome == "Exatas")),
            new Disciplina("Biologia", "", _especialidades.First(x => x.Nome == "Biológicas")),
            new Disciplina("Português", "", _especialidades.First(x => x.Nome == "Humanas"))
        };

        private static List<Curso> _cursos = new List<Curso>()
        {
            new Curso("5ª Série", ""),
            new Curso("6ª Série", ""),
            new Curso("7ª Série", "")
        };

        private static List<PessoaFisica> _pessoasFisicas = new List<PessoaFisica>()
        {
            new PessoaFisica("Marco Aurélio Munhóz", "Marco", "28567594839", "325978177", new DateTime(1980, 09, 22)),
            new PessoaFisica("Juliana Munhóz", "Juliana", "11111111111", "111", new DateTime(1982, 12, 03)),
            new PessoaFisica("Nelson Gato Munhóz", "Nelsinho", "22222222222", "222", new DateTime(2012, 01, 01)),
            new PessoaFisica("Maria Helena", "Maria", "33333333333", "333", new DateTime(1950, 04, 10)),
            new PessoaFisica("Nega Munhóz", "Nega", "44444444444", "444", new DateTime(2009, 01, 01))
        };

        private static List<Turma> _turmas = new List<Turma>()
        {
            new Turma("5ª Série A", 2018),
            new Turma("5ª Série B", 2018),
            new Turma("6ª Série A", 2018),
            new Turma("7ª Série A", 2019),
            new Turma("7ª Série B", 2019)
        };

        private static List<Matricula> _matriculas = new List<Matricula>()
        {
            new Matricula(
                    _cursos.First(x => x.Titulo == "5ª Série"),
                    _pessoasFisicas.First(x => x.NomeSocial == "Nelsinho"),
                    _turmas.First(x => x.Nome == "5ª Série A")),
            new Matricula(
                    _cursos.First(x => x.Titulo == "6ª Série"),
                    _pessoasFisicas.First(x => x.NomeSocial == "Marco"),
                    _turmas.First(x => x.Nome == "6ª Série A")),
            new Matricula(
                    _cursos.First(x => x.Titulo == "7ª Série"),
                    _pessoasFisicas.First(x => x.NomeSocial == "Juliana"),
                    _turmas.First(x => x.Nome == "7ª Série B"))
        };

        private static List<Professor> _professores = null;
        private void PrepararProfessores()
        {
            _professores = new List<Professor>()
            {
                new Professor(_pessoasFisicas.First(x => x.NomeSocial == "Maria").Id, "maria", "123"),
                new Professor(_pessoasFisicas.First(x => x.NomeSocial == "Nega").Id, "nega", "456")
            };
        }
    }
}
