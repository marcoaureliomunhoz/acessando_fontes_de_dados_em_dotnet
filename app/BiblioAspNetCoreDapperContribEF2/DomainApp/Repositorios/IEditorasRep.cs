using DomainApp.Entidades;
using System.Collections.Generic;

namespace DomainApp.Repositorios
{
    public interface IEditorasRep
    {
        Editora Localizar(int id, bool incluirLivros);
        List<Editora> Listar();
        int Salvar(Editora editora);
        int Excluir(int id);
    }
}
