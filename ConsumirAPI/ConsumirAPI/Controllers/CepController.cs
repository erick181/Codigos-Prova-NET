using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serializers;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ConsumirAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
     
    [HttpPost("cep")] 
    public async Task<ActionResult> BuscarCep(String cep)
        {
            var client = new RestClient($"http://viacep.com.br/ws/{cep}/json/");

            var request = new RestRequest("", Method.Get);

            var response = await client.ExecuteAsync(request);

            return Ok(response.Content);
        }




    }
}
