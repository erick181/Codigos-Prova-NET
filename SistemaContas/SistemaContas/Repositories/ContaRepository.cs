using Microsoft.EntityFrameworkCore;
using SistemaContas.DataBase;
using SistemaContas.Models;
using SistemaContas.Repositories.Interface;

namespace SistemaContas.Repositories
{
    public class ContaRepository : IContaRepository
    {

        private readonly SistemaContaContext _sistemaContaContext;

        public ContaRepository(SistemaContaContext sistemaContaContext)
        {
            _sistemaContaContext = sistemaContaContext;
        }
        
        public async Task<ContaModel> Adicionar(ContaModel conta)
        {
          await _sistemaContaContext.Contas.AddAsync(conta);
          await _sistemaContaContext.SaveChangesAsync();
            return conta;
        }

        public async Task<bool> Apagar(int id)
        {
            ContaModel contaSelecionada = await BuscarPorId(id);

            if (contaSelecionada == null)
            {
                throw new Exception($" Conta com ID {id} não encontrada");
            }

            _sistemaContaContext.Contas.Remove(contaSelecionada);
            await _sistemaContaContext.SaveChangesAsync();

            return true;
        }

        public async Task<ContaModel> Atualizar(ContaModel conta, int id)
        {
            ContaModel contaSelecionada = await BuscarPorId(id);

            if(contaSelecionada == null) 
            {
                throw new Exception($" Conta com ID {id} não encontrada");
            }
            
            contaSelecionada.Nome = conta.Nome;
            contaSelecionada.Descricao = conta.Descricao;

            _sistemaContaContext.Contas.Update(contaSelecionada);
            await _sistemaContaContext.SaveChangesAsync();
            return contaSelecionada;

        }

        public async Task<ContaModel> BuscarPorId(int id)
        {
           return await _sistemaContaContext.Contas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ContaModel>> BuscarTodos()
        {
           return await _sistemaContaContext.Contas.ToListAsync();
        }
    }
}
