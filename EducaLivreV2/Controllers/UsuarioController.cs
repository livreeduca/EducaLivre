using EducaLivreV2.Data;
using EducaLivreV2.Filters;
using EducaLivreV2.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducaLivreV2.Controllers
{
    [ServiceFilter(typeof(AdminAuthorizationFilter))]
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
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }

        // CRIAR USUÁRIO - GET
        public IActionResult Create()
        {
            return View();
        }

        // CRIAR USUÁRIO - POST
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Garante que sempre tenha um TipoId
                usuario.TipoId = 2; // Usuário Comum
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // EDITAR USUÁRIO - GET
        public IActionResult Edit(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // EDITAR USUÁRIO - POST
        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // DELETAR USUÁRIO - GET
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // DELETAR USUÁRIO - POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}