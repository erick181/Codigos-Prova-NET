using SistemaContas.Models;

namespace SistemaContas.Repositories.Interface
{
    public interface IContaRepository 
    {
        Task<List<ContaModel>> BuscarTodos();
        Task<ContaModel> BuscarPorId(int id);
        Task<ContaModel> Adicionar(ContaModel conta);
        Task<ContaModel> Atualizar(ContaModel conta, int id);
        Task<bool> Apagar(int id);

    }
}
