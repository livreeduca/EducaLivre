using EducaLivreV2.Data;
using EducaLivreV2.Filters;
using EducaLivreV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducaLivreV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // No HomeController.cs, adicione:
        [ServiceFilter(typeof(AdminAuthorizationFilter))]
        public async Task<IActionResult> PainelAdmin()
        {
            try
            {
                // Estatísticas
                ViewData["TotalUsuarios"] = await _context.Usuarios.CountAsync();
                ViewData["TotalEscolas"] = await _context.instituicoes
                    .Where(i => i.ativa)
                    .CountAsync();

                // Últimos usuários (5 mais recentes)
                ViewData["UltimosUsuarios"] = await _context.Usuarios
                    .OrderByDescending(u => u.Id)
                    .Take(5)
                    .ToListAsync();

                // Últimas escolas (5 mais recentes)
                ViewData["UltimasEscolas"] = await _context.instituicoes
                    .Where(i => i.ativa)
                    .OrderByDescending(i => i.data_cadastro)
                    .Take(5)
                    .ToListAsync();

                return View();
            }
            catch (Exception ex)
            {
                // Log do erro
                Console.WriteLine($"Erro no PainelAdmin: {ex.Message}");
                return View();
            }
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var instituicoesDestaque = await _context.Set<Instituicao>()
                    .Where(i => i.ativa)
                    .OrderByDescending(i => i.nota)
                    .Take(6)
                    .ToListAsync();

                // CARREGAR OS SELOS DE CADA INSTITUIÇÃO
                foreach (var instituicao in instituicoesDestaque)
                {
                    var selosIds = await _context.instituicao_selos
                        .Where(x => x.instituicao_id == instituicao.id)
                        .Select(x => x.selo_id)
                        .ToListAsync();

                    instituicao.SelosIds = selosIds;
                }

                return View(instituicoesDestaque);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro: {ex.Message}");
                return View(new List<Instituicao>());
            }
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // GET: /Home/Contato
        public IActionResult Contato()
        {
            return View();
        }

        // POST: /Home/Contato
        [HttpPost]
        public async Task<IActionResult> Contato(ContatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Aqui você pode:
                    // 1. Salvar no banco de dados
                    // 2. Enviar email
                    // 3. Integrar com sistema de tickets

                    // Por enquanto, apenas mostra mensagem de sucesso
                    TempData["MensagemSucesso"] = "Mensagem enviada com sucesso! Entraremos em contato em breve.";
                    return RedirectToAction("Contato");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erro ao enviar mensagem. Tente novamente.");
                }
            }

            return View(model);
        }
    }

    // ViewModel para o formulário de contato (DENTRO do namespace, FORA da classe HomeController)
    public class ContatoViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O assunto é obrigatório")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "A mensagem é obrigatória")]
        [StringLength(1000, ErrorMessage = "A mensagem deve ter no máximo 1000 caracteres")]
        public string Mensagem { get; set; }
    }
}