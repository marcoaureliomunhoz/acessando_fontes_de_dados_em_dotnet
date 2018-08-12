using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dominio.Entidades;
using WebApplication1.Dominio.Repositorios;
using WebApplication1.Infra.FontesDados._Fontes.Tabelas;
using WebApplication1.Infra.FontesDados.EF;

namespace WebApplication1.Infra.FontesDados.Repositorios
{
    public class AutoresRep : IAutoresRep
    {
        ContextoGeralEF db;

        public AutoresRep(ContextoGeralEF db)
        {
            this.db = db;
        }

        private TabAutor GetCadastro(int id)
        {
            if (id > 0)
                return db.Autores.FirstOrDefault(x => x.AutorId == id);
            return null;
        }

        public Autor Localizar(int id)
        {
            var cadastro = this.GetCadastro(id);
            if (cadastro != null)
                return new Autor(cadastro.AutorId, cadastro.Nome);
            return null;
        }

        public List<Autor> Listar()
        {
            var rlist = new List<Autor>();
            var tlist = db.Autores.ToList();
            tlist.ForEach(x => rlist.Add(new Autor(x.AutorId, x.Nome)));
            return rlist;
        }

        public int Salvar(Autor autor)
        {
            TabAutor cadastro = this.GetCadastro(autor.AutorId);
            if (cadastro != null)
            {
                cadastro.Nome = autor.Nome;
                return db.SaveChanges();
            }
            cadastro = new TabAutor
            {
                Nome = autor.Nome
            };
            db.Autores.Add(cadastro);
            return db.SaveChanges();
        }

        public int Excluir(int id)
        {
            var cadastro = this.GetCadastro(id);
            if (cadastro != null)
            {
                db.Autores.Remove(cadastro);
                return db.SaveChanges();
            }
            return 0;
        }
    }
}
