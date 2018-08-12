using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dominio.Entidades;
using WebApplication1.Dominio.Repositorios;
using WebApplication1.Infra.FontesDados._Fontes.Tabelas;
using WebApplication1.Infra.FontesDados.Dapper;
using WebApplication1.Infra.FontesDados.Dapper.Map;
using WebApplication1.Infra.FontesDados.EF;

namespace WebApplication1.Infra.FontesDados.Repositorios
{
    public class LivrosRep : BaseMap, ILivrosRep
    {
        ContextoGeralDapper ctx;

        public LivrosRep(ContextoGeralDapper ctx) 
        {
            this.ctx = ctx;
        }

        private TabLivro GetCadastro(int id, SqlConnection db)
        {
            if (id > 0)
                return db.Get<TabLivro>(id);
            return null;
        }

        private List<Autor> GetAutores(int id, SqlConnection db)
        {
            var autores = new List<Autor>();
            var cadAutores = db.Query<TabAutor>($"select * from autor where autorid in (select autorid from livro_autor where livroid = {id})").ToList();
            cadAutores.ForEach(x => autores.Add(new Autor(x.AutorId, x.Nome)));
            return autores;
        }

        public Livro Localizar(int id, bool incluirAutores)
        {
            using (var db = ctx.getNewConnection())
            {
                var cadastro = this.GetCadastro(id, db);
                if (cadastro != null)
                {
                    var autores = new List<Autor>();
                    if (incluirAutores)
                        autores = this.GetAutores(id, db);

                    return new Livro(cadastro.LivroId, cadastro.Titulo, autores);
                }
            }
            return null;
        }

        public List<Livro> Listar()
        {
            using (var db = ctx.getNewConnection())
            {
                var rlist = new List<Livro>();
                var tlist = db.GetAll<TabLivro>();
                foreach (var x in tlist) rlist.Add(new Livro(x.LivroId, x.Titulo, null));
                return rlist;
            }
        }

        public int Salvar(Livro livro)
        {
            using (var db = ctx.getNewConnection())
            {
                TabLivro cadastro = this.GetCadastro(livro.LivroId, db);
                if (cadastro != null)
                {
                    cadastro.Titulo = livro.Titulo;
                    var retorno = db.Update<TabLivro>(cadastro);
                    if (retorno)
                        return 1;
                }
                cadastro = new TabLivro
                {
                    Titulo = livro.Titulo
                };
                return (int)db.Insert<TabLivro>(cadastro);
            }
        }

        public int Excluir(int id)
        {
            using (var db = ctx.getNewConnection())
            {
                var cadastro = this.GetCadastro(id, db);
                if (cadastro != null)
                {
                    var retorno = db.Delete<TabLivro>(cadastro);
                    if (retorno)
                        return 1;
                }
                return 0;
            }
        }

        public List<Autor> ListarAutoresNaoVinculados(int livroId)
        {
            using (var db = ctx.getNewConnection())
            {
                var autores = new List<Autor>();
                var cadAutores = db.Query<TabAutor>($"select * from autor where autorid not in (select autorid from livro_autor where livroid = {livroId})").ToList();
                cadAutores.ForEach(x => autores.Add(new Autor(x.AutorId, x.Nome)));
                return autores;
            }
        }

        public int RemoverAutor(int livroId, int autorId)
        {
            using (var db = ctx.getNewConnection())
            {
                return db.Execute($"delete from livro_autor where livroid = {livroId} and autorid = {autorId}");
            }
        }

        public int AdicionarAutores(ICollection<int> novos, int livroId)
        {
            using (var db = ctx.getNewConnection())
            {
                int retorno = 0;
                foreach (var autorId in novos)
                {
                    retorno += db.Execute($"insert into livro_autor (livroid, autorid) values ({livroId},{autorId})");
                }
                return retorno;
            }
        }
    }
}
