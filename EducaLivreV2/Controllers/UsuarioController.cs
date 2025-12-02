using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducaLivreV2.Data;
using EducaLivreV2.Models;
using EducaLivreV2.Services;
using System.Linq;
using System;

namespace EducaLivreV2.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LISTAR USUÁRIOS
        public IActionResult Index()
        {
            try
            {
                var usuarios = _context.Usuarios.ToList();
                Console.WriteLine($"Total de usuários: {usuarios.Count}");
                return View(usuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO Index: {ex.Message}");
                return View(new List<Usuario>());
            }
        }

        // CRIAR USUÁRIO - GET
        public IActionResult Create()
        {
            return View();
        }

        // CRIAR USUÁRIO - POST
        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            try
            {
                Console.WriteLine($"Tentando criar usuário: {usuario.Nome}, {usuario.Email}");

                if (ModelState.IsValid)
                {
                    // Hash da senha
                    usuario.Senha = PasswordHasher.HashPassword(usuario.Senha);
                    usuario.TipoId = usuario.TipoId ?? 2;

                    Console.WriteLine($"Senha hash: {usuario.Senha}");

                    _context.Usuarios.Add(usuario);
                    int result = await _context.SaveChangesAsync();

                    Console.WriteLine($"SaveChanges retornou: {result}");

                    if (result > 0)
                    {
                        TempData["MensagemSucesso"] = "Usuário criado com sucesso!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Falha ao salvar no banco de dados");
                    }
                }
                else
                {
                    Console.WriteLine("ModelState inválido!");
                    foreach (var state in ModelState)
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            Console.WriteLine($"Erro em {state.Key}: {error.ErrorMessage}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEÇÃO: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                ModelState.AddModelError("", $"Erro: {ex.Message}");
            }

            return View(usuario);
        }

        // ... resto do código similar com try-catch
    }
}