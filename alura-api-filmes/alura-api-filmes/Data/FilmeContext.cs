using alura_api_filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace alura_api_filmes.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options) : base (options)
        {

        }

        public DbSet<Filme> Filme { get; set; }
    }
}
