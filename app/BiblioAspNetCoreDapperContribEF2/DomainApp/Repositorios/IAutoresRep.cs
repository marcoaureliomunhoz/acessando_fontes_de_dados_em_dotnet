using DomainApp.Entidades;
using System.Collections.Generic;

namespace DomainApp.Repositorios
{
    public interface IAutoresRep
    {
        Autor Localizar(int id);
        List<Autor> Listar();
        int Salvar(Autor autor);
        int Excluir(int id);
    }
}
