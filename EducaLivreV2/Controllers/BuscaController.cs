using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducaLivreV2.Data;
using EducaLivreV2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EducaLivreV2.Controllers
{
    public class BuscaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuscaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ APENAS UMA ACTION INDEX
        // GET: /Busca?q=termo&cidade=São Paulo&estado=SP
        public async Task<IActionResult> Index(string q, string cidade, string estado)
        {
            ViewData["TermoBuscado"] = q;
            ViewData["CidadeFiltro"] = cidade;
            ViewData["EstadoFiltro"] = estado;

            var query = _context.instituicoes.Where(i => i.ativa);

            // Filtro por termo geral (q)
            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(i =>
                    i.nome.Contains(q) ||
                    i.descricao.Contains(q) ||
                    i.cidade.Contains(q) ||
                    i.estado.Contains(q) ||
                    i.bairro.Contains(q)
                );
            }

            // Filtro por cidade
            if (!string.IsNullOrWhiteSpace(cidade))
            {
                query = query.Where(i => i.cidade.Contains(cidade));
            }

            // Filtro por estado
            if (!string.IsNullOrWhiteSpace(estado))
            {
                query = query.Where(i => i.estado.Contains(estado));
            }

            var instituicoes = await query
                .OrderByDescending(i => i.nota)
                .ToListAsync();

            return View(instituicoes);
        }

        // ✅ Método para AJAX (mantém separado)
        [HttpGet]
        public async Task<JsonResult> BuscarInstituicoes(string termo)
        {
            if (string.IsNullOrEmpty(termo))
            {
                return Json(new { success = false, message = "Termo de busca vazio" });
            }

            var instituicoes = await _context.instituicoes
                .Where(i => i.ativa && (
                    i.nome.Contains(termo) ||
                    i.cidade.Contains(termo) ||
                    i.estado.Contains(termo) ||
                    i.descricao.Contains(termo)
                ))
                .OrderByDescending(i => i.nota)
                .Take(10)
                .Select(i => new
                {
                    id = i.id,
                    nome = i.nome,
                    cidade = i.cidade,
                    estado = i.estado,
                    nota = i.nota,
                    imagemUrl1 = i.imagem_url1
                })
                .ToListAsync();

            return Json(new { success = true, data = instituicoes });
        }

        // ✅ Detalhes da instituição
        public async Task<IActionResult> Detalhes(int id)
        {
            var instituicao = await _context.instituicoes
                .FirstOrDefaultAsync(i => i.id == id && i.ativa);

            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }
    }
}