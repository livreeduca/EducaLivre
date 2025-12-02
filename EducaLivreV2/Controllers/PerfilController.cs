using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducaLivreV2.Data;
using EducaLivreV2.Models;
using EducaLivreV2.Services;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace EducaLivreV2.Controllers
{
    public class PerfilController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _authService;

        public PerfilController(ApplicationDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // GET: /Perfil
        public async Task<IActionResult> Index()
        {
            if (!_authService.IsLoggedIn())
            {
                TempData["MensagemErro"] = "Faça login para acessar seu perfil";
                return RedirectToAction("Login", "Auth");
            }

            var userId = _authService.GetUserId();
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (usuario == null)
            {
                TempData["MensagemErro"] = "Usuário não encontrado";
                return RedirectToAction("Index", "Home");
            }

            return View(usuario);
        }

        // GET: /Perfil/Editar
        public async Task<IActionResult> Editar()
        {
            if (!_authService.IsLoggedIn())
            {
                return RedirectToAction("Login", "Auth");
            }

            var userId = _authService.GetUserId();
            var usuario = await _context.Usuarios.FindAsync(userId);

            if (usuario == null)
            {
                return NotFound();
            }

            // Não enviamos a senha real para a view
            usuario.Senha = "";
            return View(usuario);
        }

        // POST: /Perfil/Editar
        [HttpPost]
        public async Task<IActionResult> Editar(Usuario usuarioAtualizado)
        {
            if (!_authService.IsLoggedIn())
            {
                return RedirectToAction("Login", "Auth");
            }

            var userId = _authService.GetUserId();
            var usuario = await _context.Usuarios.FindAsync(userId);

            if (usuario == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Atualiza dados básicos
                usuario.Nome = usuarioAtualizado.Nome;
                usuario.Email = usuarioAtualizado.Email;

                // Atualiza senha se foi fornecida
                if (!string.IsNullOrEmpty(usuarioAtualizado.Senha) &&
                    usuarioAtualizado.Senha.Length >= 6)
                {
                    usuario.Senha = PasswordHasher.HashPassword(usuarioAtualizado.Senha);
                }

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                TempData["MensagemSucesso"] = "Perfil atualizado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(usuarioAtualizado);
        }

        // GET: /Perfil/Seguranca
        public IActionResult Seguranca()
        {
            if (!_authService.IsLoggedIn())
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }

        // POST: /Perfil/AlterarSenha
        [HttpPost]
        public async Task<IActionResult> AlterarSenha(string senhaAtual, string novaSenha, string confirmarSenha)
        {
            if (!_authService.IsLoggedIn())
            {
                return RedirectToAction("Login", "Auth");
            }

            if (novaSenha != confirmarSenha)
            {
                TempData["MensagemErro"] = "As novas senhas não coincidem";
                return RedirectToAction("Seguranca");
            }

            if (novaSenha.Length < 6)
            {
                TempData["MensagemErro"] = "A nova senha deve ter no mínimo 6 caracteres";
                return RedirectToAction("Seguranca");
            }

            var userId = _authService.GetUserId();
            var usuario = await _context.Usuarios.FindAsync(userId);

            if (usuario == null)
            {
                return NotFound();
            }

            // Verifica senha atual
            if (!PasswordHasher.VerifyPassword(senhaAtual, usuario.Senha))
            {
                TempData["MensagemErro"] = "Senha atual incorreta";
                return RedirectToAction("Seguranca");
            }

            // Atualiza senha
            usuario.Senha = PasswordHasher.HashPassword(novaSenha);
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
            return RedirectToAction("Seguranca");
        }

        // GET: /Perfil/Atividade
        public IActionResult Atividade()
        {
            if (!_authService.IsLoggedIn())
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }
    }
}