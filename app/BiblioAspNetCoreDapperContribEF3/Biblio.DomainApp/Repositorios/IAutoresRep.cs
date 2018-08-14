using Biblio.DomainApp.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblio.DomainApp.Repositorios
{
    public interface IAutoresRep
    {
        List<Autor> Listar();
        Autor Localizar(int id);
        int Salvar(Autor autor);
        int Excluir(int id);
    }
}
