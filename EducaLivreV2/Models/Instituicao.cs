using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducaLivreV2.Models
{
    [Table("instituicao_selos")]
    public class InstituicaoSelo
    {
        [Key]
        public int id { get; set; }

        public int instituicao_id { get; set; }

        public int selo_id { get; set; }

        // Navegação (opcional, mas útil)
        [ForeignKey("instituicao_id")]
        public virtual Instituicao Instituicao { get; set; }
    }

    [Table("instituicoes")] // Nome exato da tabela no banco
    public class Instituicao
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string nome { get; set; }

        public string rua { get; set; }
        public string bairro { get; set; }
        public string numero { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string descricao { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string website { get; set; }

        [Column("imagem_url1")]
        public string imagem_url1 { get; set; }

        [Column("imagem_url2")]
        public string imagem_url2 { get; set; }

        [Column("imagem_url3")]
        public string imagem_url3 { get; set; }

        [Column("imagem_url4")]
        public string imagem_url4 { get; set; }

        public decimal nota { get; set; }

        public bool ativa { get; set; }

        [Column("data_cadastro")]
        public DateTime data_cadastro { get; set; }

        // Propriedade auxiliar para pegar a primeira imagem
        [NotMapped]
        public string ImagemPrincipal
        {
            get
            {
                return !string.IsNullOrEmpty(imagem_url1) ? imagem_url1 : "/Assets/escola-generica.jpg";
            }
        }

        // Propriedade auxiliar para todas as imagens
        [NotMapped]
        public List<string> TodasImagens
        {
            get
            {
                var imagens = new List<string>();
                if (!string.IsNullOrEmpty(imagem_url1)) imagens.Add(imagem_url1);
                if (!string.IsNullOrEmpty(imagem_url2)) imagens.Add(imagem_url2);
                if (!string.IsNullOrEmpty(imagem_url3)) imagens.Add(imagem_url3);
                if (!string.IsNullOrEmpty(imagem_url4)) imagens.Add(imagem_url4);

                return imagens.Any() ? imagens : new List<string> { "/Assets/escola-generica.jpg" };
            }
        }
        // No final da classe Instituicao, adicione:
        [NotMapped]
        public string NotaFormatada
        {
            get { return $"{nota:0.00}/5.00"; }
        }

        [NotMapped]
        public string NotaLivros
        {
            get
            {
                // Retorna livrinhos baseados na nota (0-5)
                int livrosCheios = (int)nota;
                bool meioLivro = (nota - livrosCheios) >= 0.5m;

                string html = "";
                for (int i = 0; i < livrosCheios; i++)
                    html += "<i class='fa-solid fa-book livrinho cheio'></i>";

                if (meioLivro)
                    html += "<i class='fa-solid fa-book-bookmark livrinho cheio'></i>";

                int livrosVazios = 5 - livrosCheios - (meioLivro ? 1 : 0);
                for (int i = 0; i < livrosVazios; i++)
                    html += "<i class='fa-solid fa-book livrinho vazio'></i>";

                return html;
            }
        }
                [NotMapped]
        public List<int> SelosIds { get; set; } = new List<int>();
    }
}