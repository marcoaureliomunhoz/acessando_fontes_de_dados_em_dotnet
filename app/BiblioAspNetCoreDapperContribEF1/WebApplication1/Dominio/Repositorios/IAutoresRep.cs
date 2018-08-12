using System.Collections.Generic;
using WebApplication1.Dominio.Entidades;

namespace WebApplication1.Dominio.Repositorios
{
    public interface IAutoresRep
    {
        Autor Localizar(int id);
        List<Autor> Listar();
        int Salvar(Autor autor);
        int Excluir(int id);
    }
}
