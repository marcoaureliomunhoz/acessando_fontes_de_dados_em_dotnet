using System.Collections.Generic;
using WebApplication1.Dominio.Entidades;

namespace WebApplication1.Dominio.Repositorios
{
    public interface ILivrosRep
    {
        Livro Localizar(int id, bool incluirAutores);
        List<Livro> Listar();
        int Salvar(Livro livro);
        int Excluir(int id);
        List<Autor> ListarAutoresNaoVinculados(int livroId);
        int RemoverAutor(int livroId, int autorId);
        int AdicionarAutores(ICollection<int> novos, int livroId);
    }
}
