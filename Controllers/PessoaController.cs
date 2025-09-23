using Microsoft.AspNetCore.Mvc;
using projetoPessoa.Models;

namespace projetoPessoa.Controllers
{
    public class PessoaController : ControllerBase
    {
        public static List<Pessoa> listaPessoas = new List<Pessoa>
        {
            new Pessoa { Id = 1, Nome = "Ana Carolina", Idade = 30, Email = "anitadaflon@gmail.com" },
            new Pessoa { Id = 2, Nome = "Igor BRandao", Idade = 25, Email = "devigorbrandao@gmail.com" }
        };

        [HttpGet]
        [Route("api/pessoas")]
        public IActionResult GetPessoas()
        {
            return Ok(listaPessoas);
        }

        [HttpGet]
        [Route("api/pessoas/{id}")]
        public IActionResult GetPessoaById(int id)
        {
            var pessoa = listaPessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost]
        [Route("api/pessoas")]
        public IActionResult CreatePessoa([FromBody] Pessoa novaPessoa)
        {
            if (novaPessoa == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            novaPessoa.Id = listaPessoas.Any() ? listaPessoas.Max(p => p.Id) + 1 : 1;
            listaPessoas.Add(novaPessoa);
            return CreatedAtAction(nameof(GetPessoaById), new { id = novaPessoa.Id }, novaPessoa);
        }

        [HttpPut]
        [Route("api/pessoas/{id}")]
        public IActionResult UpdatePessoa(int id, [FromBody] Pessoa pessoaAtualizada)
        {
            var pessoa = listaPessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa == null || pessoaAtualizada == null)
            {
                return NotFound();
            }
            pessoa.Nome = pessoaAtualizada.Nome;
            pessoa.Idade = pessoaAtualizada.Idade;
            pessoa.Email = pessoaAtualizada.Email;
            return NoContent();
        }


        [HttpDelete]
        [Route("api/pessoas/{id}")]
        public IActionResult DeletePessoa(int id)
        {
            var pessoa = listaPessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            listaPessoas.Remove(pessoa);
            return NoContent();
        }

    }
}
    
    
    
    
