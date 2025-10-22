using EducaLivreV2.Data;
using EducaLivreV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducaLivreV2.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
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
            // Lógica de autenticação aqui
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email == username || u.Nome == username);

            if (usuario != null && usuario.Senha == senha) // ⚠️ Temporário - precisa de hash!
            {
                // Login bem-sucedido
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
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(usuario);
        }

        // GET: /Auth/Logout
        public IActionResult Logout()
        {
            // Lógica de logout aqui
            return RedirectToAction("Index", "Home");
        }
    }

}