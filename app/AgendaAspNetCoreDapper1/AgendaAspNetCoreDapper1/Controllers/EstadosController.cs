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
    public class EstadosController : Controller
    {
        private IConfiguration _config;

        public EstadosController(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IActionResult Index()
        {
            var model = new List<Estado>();
            using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("Contatos")))
            {
                model = conexao.Query<Estado>("select * from Estado").ToList();
            }
            return View(model);
        }

        public IActionResult Cadastro(string id)
        {
            var model = new Estado();
            if (!string.IsNullOrEmpty(id) && !id.Equals("_"))
            {
                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("Contatos")))
                {
                    model = conexao.QueryFirstOrDefault<Estado>(
                        "select * from Estado where UF = @UF",
                        new {
                            UF = id
                        });
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastro(Estado estado)
        {
            var resultOperacao = 0;

            ViewBag.problemas = new List<string>();

            if (string.IsNullOrEmpty(estado.UF))
                ViewBag.problemas.Add("Informe a UF!");

            if (string.IsNullOrEmpty(estado.Nome))
                ViewBag.problemas.Add("Informe o nome!");

            if (ViewBag.problemas.Count <= 0)
            {
                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("Contatos")))
                {
                    var cadastro = conexao.QueryFirstOrDefault<Estado>(
                            "select * from Estado where UF = @UF",
                            new
                            {
                                UF = estado.UF
                            });

                    var parametros = new DynamicParameters();
                    parametros.Add("@UF", estado.UF);
                    parametros.Add("@Nome", estado.Nome);

                    var sql = "insert into Estado (UF, Nome) values (@UF, @Nome)";
                    if (cadastro != null)
                        sql = "update Estado set Nome = @Nome where UF = @UF";

                    resultOperacao = conexao.Execute(
                        sql,
                        parametros,
                        commandType: System.Data.CommandType.Text);
                }
                if (resultOperacao > 0)
                    return RedirectToAction("Index");
            }

            return View(estado);
        }

        public IActionResult Excluir(string id)
        {
            if (!string.IsNullOrEmpty(id) && !id.Equals("_"))
            {
                using (SqlConnection conexao = new SqlConnection(_config.GetConnectionString("Contatos")))
                {
                    conexao.Execute(
                        "delete from Estado where UF = @UF",
                        new
                        {
                            UF = id
                        });
                }
            }
            return RedirectToAction("Index");
        }
    }
}