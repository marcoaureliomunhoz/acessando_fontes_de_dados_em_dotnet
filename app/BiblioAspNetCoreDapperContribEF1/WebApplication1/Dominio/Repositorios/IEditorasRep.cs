using System.Collections.Generic;
using WebApplication1.Dominio.Entidades;

namespace WebApplication1.Dominio.Repositorios
{
    public interface IEditorasRep
    {
        Editora Localizar(int id, bool incluirLivros);
        List<Editora> Listar();
        int Salvar(Editora editora);
        int Excluir(int id);
    }
}
