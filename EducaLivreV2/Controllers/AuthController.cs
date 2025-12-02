using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducaLivreV2.Data;
using EducaLivreV2.Models;
using EducaLivreV2.Services;
using System.Threading.Tasks;

namespace EducaLivreV2.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _authService;

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
        public async Task<IActionResult> Login(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                ViewBag.Error = "Preencha email e senha";
                return View();
            }

            // Busca usuário
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                ViewBag.Error = "Usuário não encontrado";
                return View();
            }

            // Verifica senha
            if (!PasswordHasher.VerifyPassword(senha, usuario.Senha))
            {
                ViewBag.Error = "Senha incorreta";
                return View();
            }

            // Login
            _authService.Login(usuario);

            return RedirectToAction("Index", "Home");
        }

        // GET: /Auth/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Auth/Register
        [HttpPost]
        public async Task<IActionResult> Register(string nome, string email, string senha, string confirmarSenha)
        {
            if (senha != confirmarSenha)
            {
                ViewBag.Error = "As senhas não coincidem";
                return View();
            }

            // Verifica se email já existe
            if (await _context.Usuarios.AnyAsync(u => u.Email == email))
            {
                ViewBag.Error = "Email já cadastrado";
                return View();
            }

            // Cria novo usuário
            var usuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = PasswordHasher.HashPassword(senha),
                TipoId = 2 // Usuário comum
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Login automático
            _authService.Login(usuario);

            return RedirectToAction("Index", "Home");
        }

        // GET: /Auth/Logout
        public IActionResult Logout()
        {
            _authService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}