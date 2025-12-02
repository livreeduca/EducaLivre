using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducaLivreV2.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("senha")]
        public string Senha { get; set; } = string.Empty;

        [Column("tipo_id")]
        public int? TipoId { get; set; } = 2;

        [NotMapped]
        public bool IsAdmin => TipoId == 1;
    }
}