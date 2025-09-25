using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using projetoPessoa.Models;
using System.Threading.Tasks;

namespace projetoPessoa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PessoaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPessoas()
        {
            var pessoas = await _context.Pessoas.ToListAsync();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaById(int id)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePessoa([FromBody] Pessoa novaPessoa)
        {
            if (novaPessoa == null)
            {
                return BadRequest();
            }

      
            await _context.Pessoas.AddAsync(novaPessoa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPessoaById), new { id = novaPessoa.Id }, novaPessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePessoa(int id, [FromBody] Pessoa pessoaAtualizada)
        {
            if (pessoaAtualizada == null)
            {
                return BadRequest();
            }

            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            pessoa.Nome = pessoaAtualizada.Nome;
            pessoa.Idade = pessoaAtualizada.Idade;
            pessoa.Email = pessoaAtualizada.Email;

            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync(); 
            return NoContent();
        }

    }
}
    
    
    
    
