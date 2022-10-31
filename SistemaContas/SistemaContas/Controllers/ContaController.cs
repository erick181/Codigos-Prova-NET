using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaContas.Models;
using SistemaContas.Repositories.Interface;

namespace SistemaContas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {

        private readonly IContaRepository _contaRepository;

        public ContaController(IContaRepository contaRepository)
        {

            _contaRepository = contaRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<ContaModel>>> BuscarTodos()
        {
            List<ContaModel> contas = await _contaRepository.BuscarTodos();
            return Ok(contas);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContaModel>> BuscarPorId(int id)
        {
            ContaModel conta = await _contaRepository.BuscarPorId(id);
            return Ok(conta);
        }

        [HttpPost]
        public async Task<ActionResult<ContaModel>> Adicionar(ContaModel conta)
        {
            ContaModel contaCriada = await _contaRepository.Adicionar(conta);
            return Ok(contaCriada);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContaModel>> Atualizar(ContaModel conta, int id)
        {
            ContaModel contaAtulizada = await _contaRepository.Atualizar(conta, id);
            return Ok(contaAtulizada);  

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ContaModel>> Apagar(int id)
        {
            bool contaApagada = await _contaRepository.Apagar(id);
            return Ok(contaApagada);
        }

      
    }
}
