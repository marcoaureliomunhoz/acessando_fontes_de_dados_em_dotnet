using Biblio.DomainApp.Entidades;
using Biblio.DomainApp.Repositorios;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblio.DataApp.EF.Repositorios
{
    public class LivrosRep : ILivrosRep
    {
        ContextoGeralEF db;

        public LivrosRep(ContextoGeralEF db)
        {
            this.db = db;
        }

        public Livro Localizar(int id, bool incluirAutores)
        {
            var livro = db.Livros.Include(x => x.Editora).FirstOrDefault(x => x.LivroId == id);
            if (livro != null && incluirAutores)
            { 
                //Dapper
                //var autores = db.Database
                //                .GetDbConnection()
                //                .Query<Autor>($"select Autor.AutorId, Autor.Nome from Autor, Livro_Autor where Autor.AutorId = Livro_Autor.AutorId and Livro_Autor.LivroId = {id}").ToList();
                //EF
                var autores = db.Autores.FromSql($"select Autor.AutorId, Autor.Nome from Autor, Livro_Autor where Autor.AutorId = Livro_Autor.AutorId and Livro_Autor.LivroId = {id}").ToList();
                livro.AdicAutores(autores);
            }
            return livro;
        }

        public int Excluir(int id)
        {
            var cadastro = db.Livros.FirstOrDefault(x => x.LivroId == id);
            if (cadastro != null)
            {
                db.Livros.Remove(cadastro);
                return db.SaveChanges();
            }
            return 0;
        }

        public List<Livro> Listar()
        {
            return db.Livros.Include(x => x.Editora).ToList();
        }
        
        public int Salvar(Livro livro)
        {
            if (livro.LivroId == 0)
                db.Livros.Add(livro);
            return db.SaveChanges();
        }

        public int ExcluirAutor(int livroId, int autorId)
        {
            return db.Database.ExecuteSqlCommand($"delete from Livro_Autor where LivroId = {livroId} and AutorId = {autorId}");
        }

        public List<Autor> ListarAutoresRelacionados(int livroId)
        {
            return db.Autores.FromSql($"select Autor.AutorId, Autor.Nome from Autor, Livro_Autor where Autor.AutorId = Livro_Autor.AutorId and Livro_Autor.LivroId = {livroId}").ToList();
        }

        public List<Autor> ListarAutoresNaoRelacionados(int livroId)
        {
            return db.Autores.FromSql($"select AutorId, Nome from Autor where AutorId not in (select AutorId from Livro_Autor where LivroId = {livroId})").ToList();
        }

        public int RelacionarNovosAutores(List<int> autores, int livroId)
        {
            foreach (var autorId in autores)
            {
                db.Database.ExecuteSqlCommand($"insert into Livro_Autor (LivroId, AutorId) values ({livroId}, {autorId})");
            }
            return db.SaveChanges();
        }
    }
}
