using Microsoft.EntityFrameworkCore;
using ListaLeitura.Core.Models;

namespace ListaLeitura.Api.Data
{
    public class LeituraContext : DbContext
    {
        public LeituraContext(DbContextOptions<LeituraContext> options) : base(options) { }

        public DbSet<Livro> Livros => Set<Livro>();
    }
}
