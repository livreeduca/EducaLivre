using EducaLivreV2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducaLivreV2.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                // Testa se consegue conectar com o banco
                var canConnect = _context.Database.CanConnect();

                if (canConnect)
                {
                    ViewBag.Message = "✅ CONEXÃO COM MYSQL FUNCIONANDO!";
                    ViewBag.Color = "green";
                }
                else
                {
                    ViewBag.Message = "❌ ERRO NA CONEXÃO MYSQL";
                    ViewBag.Color = "red";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"❌ ERRO: {ex.Message}";
                ViewBag.Color = "red";
            }

            return View();
        }
    }
}