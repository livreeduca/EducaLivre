using EducaLivreV2.Data;
using EducaLivreV2.Models;
using EducaLivreV2.Services; // ← VERIFIQUE SE ESTÁ APENAS UMA VEZ
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducaLivreV2.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _authService;

        // Adicione AuthService no construtor
        public AuthController(ApplicationDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // GET: /Auth/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        public IActionResult Login(string username, string senha)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email == username || u.Nome == username);

            if (usuario != null && PasswordHasher.VerifyPassword(senha, usuario.Senha))
            {
                // ✅ ADICIONAR SESSÃO
                _authService.Login(usuario);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Usuário ou senha inválidos!";
            return View();
        }

        // GET: /Auth/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Auth/Register  
        [HttpPost]
        public IActionResult Register(Usuario usuario)
        {
            Console.WriteLine($"✅ Dados recebidos: {usuario.Nome}, {usuario.Email}");

            if (ModelState.IsValid)
            {
                Console.WriteLine("✅ ModelState é válido!");

                // Cria hash da senha antes de salvar
                usuario.Senha = PasswordHasher.HashPassword(usuario.Senha);
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                Console.WriteLine("✅ Usuário salvo no banco!");
                return RedirectToAction("Login");
            }
            else
            {
                Console.WriteLine("❌ ModelState INVÁLIDO!");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Erro: {error.ErrorMessage}");
                }
            }

            return View(usuario);
        }

        // GET: /Auth/Logout
        public IActionResult Logout()
        {
            // ✅ LIMPAR SESSÃO
            _authService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}