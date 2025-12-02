using Microsoft.EntityFrameworkCore;
using EducaLivreV2.Models;

namespace EducaLivreV2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Instituicao> instituicoes { get; set; }
        public DbSet<InstituicaoSelo> instituicao_selos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CONFIGURAÇÃO INSTITUIÇÕES
            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.ToTable("instituicoes");
                entity.HasKey(e => e.id);
                entity.Property(e => e.nome).IsRequired().HasMaxLength(200);
                entity.Property(e => e.cidade).HasMaxLength(100);
                entity.Property(e => e.estado).HasMaxLength(50);
                entity.Property(e => e.nota).HasPrecision(3, 2);
                entity.Property(e => e.ativa).HasDefaultValue(true);

                // Mapeamento das colunas de imagem
                entity.Property(e => e.imagem_url1).HasColumnName("imagem_url1");
                entity.Property(e => e.imagem_url2).HasColumnName("imagem_url2");
                entity.Property(e => e.imagem_url3).HasColumnName("imagem_url3");
                entity.Property(e => e.imagem_url4).HasColumnName("imagem_url4");
            });

            // CONFIGURAÇÃO INSTITUICAO_SELOS
            modelBuilder.Entity<InstituicaoSelo>(entity =>
            {
                entity.ToTable("instituicao_selos");
                entity.HasKey(e => e.id);
            });

            // CONFIGURAÇÃO USUARIOS (se tiver)
            // modelBuilder.Entity<Usuario>(entity =>
            // {
            //     ... configuração dos usuários
            // });
        }
    }
}