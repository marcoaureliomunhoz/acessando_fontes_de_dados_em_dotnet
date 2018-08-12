using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AgendaAspNetCoreDapper1.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AgendaAspNetCoreDapper1.Controllers
{
    public class ContatosController : Controller
    {
        private IConfiguration _config;

        public ContatosController(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IActionResult Index()
        {
            var model = new List<Contato>();
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("Contatos")))
            {
                model = conexao.Query<Contato>("select * from Contato").ToList();
            }
            return View(model);
        }

        public IActionResult Cadastro(int id)
        {
            ViewBag.Estados = null;
            var model = new Contato();
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("Contatos")))
            {
                ViewBag.Estados = conexao.Query<Estado>("select * from Estado");
                if (id > 0)
                {
                    model = conexao.QueryFirstOrDefault<Contato>(
                        "select * from Contato where ContatoId = @ContatoId",
                        new
                        {
                            ContatoId = id
                        });
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(Contato contato)
        {
            var resultOperacao = 0;

            ViewBag.problemas = new List<string>();

            if (string.IsNullOrEmpty(contato.Nome))
                ViewBag.problemas.Add("Informe o nome!");

            if (string.IsNullOrEmpty(contato.Valor))
                ViewBag.problemas.Add("Informe o valor!");

            if (string.IsNullOrEmpty(contato.UF))
                ViewBag.problemas.Add("Informe a UF!");

            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("Contatos")))
            {
                ViewBag.Estados = conexao.Query<Estado>("select * from Estado");
                if (ViewBag.problemas.Count <= 0)
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@UF", contato.UF);
                    parametros.Add("@Nome", contato.Nome);
                    parametros.Add("@Valor", contato.Valor);

                    var sql = "insert into Contato (UF, Nome, Valor) values (@UF, @Nome, @Valor)";
                    if (contato.ContatoId > 0)
                    {
                        sql = "update Contato set " +
                              " Nome = @Nome, " +
                              " Valor = @Valor, " +
                              " UF = @UF " +
                              "where ContatoId = @ContatoId";
                        parametros.Add("@ContatoId", contato.ContatoId);
                    }

                    resultOperacao = conexao.Execute(
                        sql,
                        parametros,
                        commandType: System.Data.CommandType.Text);
                }
                if (resultOperacao > 0)
                    return RedirectToAction("Index");
            }

            return View(contato);
        }

        public IActionResult Excluir(int id)
        {
            if (id > 0)
            {
                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("Contatos")))
                {
                    conexao.Execute(
                        "delete from Contato where ContatoId = @ContatoId",
                        new
                        {
                            ContatoId = id
                        });
                }
            }
            return RedirectToAction("Index");
        }
    }
}