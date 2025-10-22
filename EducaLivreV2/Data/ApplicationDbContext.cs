using Microsoft.EntityFrameworkCore;
using EducaLivreV2.Models;

namespace EducaLivreV2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Tabelas do seu banco - ADICIONE AQUI:
        public DbSet<Usuario> Usuarios { get; set; }
        // public DbSet<Instituicao> Instituicoes { get; set; }
        // public DbSet<Selo> Selos { get; set; }
        // public DbSet<Tipo> Tipos { get; set; }
    }
}