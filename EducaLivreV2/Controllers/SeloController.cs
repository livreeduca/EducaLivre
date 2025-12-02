using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EducaLivreV2.Controllers
{
    public class SeloController : Controller
    {
        public IActionResult Index()
        {
            var selos = new List<SeloViewModel>
            {
                // SELOS DE EDUCAÇÃO DE QUALIDADE
                new SeloViewModel
                {
                    Id = 1,
                    Titulo = "Selo de Acessibilidade Digital e Física",
                    Descricao = "A escola/universidade tem site acessível (para leitores de tela, contraste etc.) e infraestrutura com rampas, elevadores e sinalização tátil.",
                    ImagemUrl = "/Assets/selos/educa/01.svg",
                    AltText = "Selo de Acessibilidade Digital e Física",
                    Categoria = "Educação de Qualidade"
                },
                /*new SeloViewModel
                {
                    Id = 2,
                    Titulo = "Selo de Apoio Psicopedagógico",
                    Descricao = "A instituição oferece suporte emocional e psicológico gratuito aos alunos.",
                    ImagemUrl = "/Assets/selos/educa/02.svg",
                    AltText = "Selo de Apoio Psicopedagógico",
                    Categoria = "Educação de Qualidade"
                },*/
                new SeloViewModel
                {
                    Id = 3,
                    Titulo = "Selo de Apoio à Iniciação Científica e Projetos",
                    Descricao = "Incentiva alunos a desenvolverem projetos, com bolsas ou suporte de orientação.",
                    ImagemUrl = "/Assets/selos/educa/03.svg",
                    AltText = "Selo de Apoio à Iniciação Científica",
                    Categoria = "Educação de Qualidade"
                },
                new SeloViewModel
                {
                    Id = 4,
                    Titulo = "Selo de Participação Estudantil",
                    Descricao = "Os alunos têm espaço de fala e voto em conselhos e decisões da escola.",
                    ImagemUrl = "/Assets/selos/educa/04.svg",
                    AltText = "Selo de Participação Estudantil",
                    Categoria = "Educação de Qualidade"
                },
                new SeloViewModel
                {
                    Id = 5,
                    Titulo = "Selo de Biblioteca Atualizada",
                    Descricao = "A escola/universidade tem acervo atualizado, incluindo obras digitais.",
                    ImagemUrl = "/Assets/selos/educa/05.svg",
                    AltText = "Selo de Biblioteca Atualizada",
                    Categoria = "Educação de Qualidade"
                },
                new SeloViewModel
                {
                    Id = 6,
                    Titulo = "Selo de Transparência Acadêmica",
                    Descricao = "Facilita o acesso a informações como grade curricular, notas, metodologia, etc.",
                    ImagemUrl = "/Assets/selos/educa/06.svg",
                    AltText = "Selo de Transparência Acadêmica",
                    Categoria = "Educação de Qualidade"
                },
                new SeloViewModel
                {
                    Id = 7,
                    Titulo = "Selo de Qualificação Docente",
                    Descricao = "Alta porcentagem de professores com mestrado, doutorado ou cursos de capacitação contínua.",
                    ImagemUrl = "/Assets/selos/educa/07.svg",
                    AltText = "Selo de Qualificação Docente",
                    Categoria = "Educação de Qualidade"
                },/*
                new SeloViewModel
                {
                    Id = 8,
                    Titulo = "Selo de Incentivo à Cultura e Artes",
                    Descricao = "A instituição oferece oficinas, eventos culturais ou festivais internos.",
                    ImagemUrl = "/Assets/selos/educa/08.svg",
                    AltText = "Selo de Incentivo à Cultura e Artes",
                    Categoria = "Educação de Qualidade"
                },*/

                // SELOS DE IGUALDADE DE GÊNERO
                new SeloViewModel
                {
                    Id = 9,
                    Titulo = "Selo 50/50 Docente",
                    Descricao = "A Proporção de Professoras e Professores é igualitária.",
                    ImagemUrl = "/Assets/selos/igual/01.svg",
                    AltText = "Selo 50/50 Docente",
                    Categoria = "Igualdade de Gênero"
                },
                new SeloViewModel
                {
                    Id = 10,
                    Titulo = "Selo de Representatividade Curricular",
                    Descricao = "A grade aborda temas de gênero, equidade, direitos humanos etc.",
                    ImagemUrl = "/Assets/selos/igual/02.svg",
                    AltText = "Selo de Representatividade Curricular",
                    Categoria = "Igualdade de Gênero"
                },
                new SeloViewModel
                {
                    Id = 11,
                    Titulo = "Selo de Banheiros Neutros e Inclusivos",
                    Descricao = "A instituição possui banheiros unissex e com acessibilidade para deficientes.",
                    ImagemUrl = "/Assets/selos/igual/03.svg",
                    AltText = "Selo de Banheiros Neutros e Inclusivos",
                    Categoria = "Igualdade de Gênero"
                },
                new SeloViewModel
                {
                    Id = 12,
                    Titulo = "Selo de Igualdade Salarial",
                    Descricao = "Professoras e Professores tem igualdade salarial independente do gênero.",
                    ImagemUrl = "/Assets/selos/igual/04.svg",
                    AltText = "Selo de Igualdade Salarial",
                    Categoria = "Igualdade de Gênero"
                },
                new SeloViewModel
                {
                    Id = 13,
                    Titulo = "Selo de Canal de Denúncia Ativo e Seguro",
                    Descricao = "Existe um canal seguro e funcional para denúncias de assédio ou discriminação.",
                    ImagemUrl = "/Assets/selos/igual/05.svg",
                    AltText = "Selo de Canal de Denúncia Ativo",
                    Categoria = "Igualdade de Gênero"
                },
                new SeloViewModel
                {
                    Id = 14,
                    Titulo = "Selo de Liderança Feminina",
                    Descricao = "Mulheres em cargos de coordenação, direção ou reitoria.",
                    ImagemUrl = "/Assets/selos/igual/06.svg",
                    AltText = "Selo de Liderança Feminina",
                    Categoria = "Igualdade de Gênero"
                },/*
                new SeloViewModel
                {
                    Id = 15,
                    Titulo = "Selo de Formação Antidiscriminatória",
                    Descricao = "Professores e funcionários passam por capacitação sobre gênero, assédio e direitos humanos.",
                    ImagemUrl = "/Assets/selos/igual/07.svg",
                    AltText = "Selo de Formação Antidiscriminatória",
                    Categoria = "Igualdade de Gênero"
                },
                new SeloViewModel
                {
                    Id = 16,
                    Titulo = "Selo de Inclusão LGBTQIA+",
                    Descricao = "A escola reconhece e respeita a identidade de gênero e orientação sexual de alunos e alunas (uso de nome social, por exemplo).",
                    ImagemUrl = "/Assets/selos/igual/08.svg",
                    AltText = "Selo de Inclusão LGBTQIA+",
                    Categoria = "Igualdade de Gênero"
                },
                new SeloViewModel
                {
                    Id = 17,
                    Titulo = "Selo de Apoio a Mães Estudantes",
                    Descricao = "Instituições que oferecem suporte (creche, horários flexíveis, bolsa) a mães que estudam.",
                    ImagemUrl = "/Assets/selos/igual/09.svg",
                    AltText = "Selo de Apoio a Mães Estudantes",
                    Categoria = "Igualdade de Gênero"
                },*/

                // SELOS DE SUSTENTABILIDADE
                new SeloViewModel
                {
                    Id = 18,
                    Titulo = "Selo Eco-Friendly",
                    Descricao = "A escola adota políticas sustentáveis (coleta seletiva, campanhas de redução de plástico etc.)",
                    ImagemUrl = "/Assets/selos/eco/01.svg",
                    AltText = "Selo Eco-Friendly",
                    Categoria = "Sustentabilidade"
                },/*
                new SeloViewModel
                {
                    Id = 19,
                    Titulo = "Selo de Energia Limpa",
                    Descricao = "A escola recebe energia elétrica de fontes renováveis.",
                    ImagemUrl = "/Assets/selos/eco/02.svg",
                    AltText = "Selo de Energia Limpa",
                    Categoria = "Sustentabilidade"
                },*/
                new SeloViewModel
                {
                    Id = 20,
                    Titulo = "Selo de Transporte Sustentável",
                    Descricao = "Tem transporte escolar ou auxílio deslocamento para os alunos.",
                    ImagemUrl = "/Assets/selos/eco/03.svg",
                    AltText = "Selo de Transporte Sustentável",
                    Categoria = "Sustentabilidade"
                }
            };

            return View(selos);
        }
    }

    public class SeloViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public string AltText { get; set; }
        public string Categoria { get; set; }
    }
}