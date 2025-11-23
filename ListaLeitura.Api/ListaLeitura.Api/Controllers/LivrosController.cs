using ListaLeitura.Api.Data;
using ListaLeitura.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Validacoes;

namespace ListaLeitura.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LeituraContext _context;

        public LivrosController(LeituraContext context)
        {
            _context = context;
        }

        // GET: api/livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            return await _context.Livros.ToListAsync();
        }

        // GET: api/livros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
                return NotFound();

            return livro;
        }

        // POST: api/livros
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            if (!ValidadorLivro.TituloValido(livro.Titulo) || !ValidadorLivro.AutorValido(livro.Autor))
            {
                return BadRequest("Título e autor devem ter pelo menos 3 caracteres.");
            }

            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, livro);
        }

        // PUT: api/livros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.Id)
                return BadRequest();

            if (!ValidadorLivro.TituloValido(livro.Titulo) || !ValidadorLivro.AutorValido(livro.Autor))
            {
                return BadRequest("Título e autor devem ter pelo menos 3 caracteres.");
            }

            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/livros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
                return NotFound();

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
