using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducaLivreV2.Models
{
    [Table("usuarios")] // ← ESPECIFICA O NOME DA TABELA
    public class Usuario
    {
        [Key]
        [Column("id")] // ← ESPECIFICA O NOME DA COLUNA
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        [Column("nome")] // ← ESPECIFICA O NOME DA COLUNA
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Column("email")] // ← ESPECIFICA O NOME DA COLUNA
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("senha")] // ← ESPECIFICA O NOME DA COLUNA
        public string Senha { get; set; } = string.Empty;

        [Column("tipo_id")]
        public int? TipoId { get; set; } = 2; // 2 = "Usuário Comum"
        
        [NotMapped] // Não grava no banco - calculado dinamicamente
        public bool IsAdmin => TipoId == 1; // 1 = Administrador
    }
}