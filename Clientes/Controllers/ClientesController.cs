using Microsoft.AspNetCore.Mvc;

namespace Clientes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {
        public List<Cliente> clientes = new List<Cliente>();

        public ClientesController()
        {
            clientes.Add(new Cliente
            {
                nome = "Rodrigo",
                dataDeNascimento = new DateTime(1986, 12, 15)
            });
            clientes.Add(new Cliente
            {
                nome = "Fernanda",
                dataDeNascimento = new DateTime(1974, 03, 13)
            });
        }

        [HttpGet("todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Cliente>> Consultar()
        {
            return Ok(clientes);
        }

        [HttpGet]
        public ActionResult<Cliente> ConsultarPessoa(string nome)
        {
            Cliente cliente = clientes.FirstOrDefault(p => p.nome == nome);
            return Ok(cliente);
        }
   


    }
}