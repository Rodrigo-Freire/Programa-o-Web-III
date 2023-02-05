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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Cliente> Inserir([FromBody]Cliente cliente)
        {
            clientes.Add(cliente);
            return CreatedAtAction(nameof(ConsultarPessoa), cliente);

        }
        [HttpPut("consultar/{inderx}/cliente")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Cliente>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromRoute] int index, [FromBody] Cliente cliente)
        {
            if (index < 0 || index > 1)
            {
                return BadRequest();
            }

            Response.Headers.Add("rastreamento", "123456789");
            clientes[index] = cliente;
            return Ok(clientes);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Deletar([FromQuery] string nome)
        {
            Cliente deletarCliente = clientes.FirstOrDefault(p => p.nome== nome);
            if (deletarCliente == null)
            {
                return BadRequest();
            }
            clientes.Remove(deletarCliente);
            return NoContent();
        } 


    }
}