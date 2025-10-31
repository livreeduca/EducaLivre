using EducaLivreV2.Data;
using EducaLivreV2.Models;
using Microsoft.AspNetCore.Http;

namespace EducaLivreV2.Services
{
    public class AuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Login do usuário - COM VERIFICAÇÕES COMPLETAS
        public void Login(Usuario usuario)
        {
            // ✅ VERIFICAÇÃO EM CASCATA
            if (_httpContextAccessor?.HttpContext?.Session == null)
            {
                return; // Silenciosamente retorna se não houver sessão
            }

            _httpContextAccessor.HttpContext.Session.SetInt32("UserId", usuario.Id);
            _httpContextAccessor.HttpContext.Session.SetString("UserName", usuario.Nome ?? string.Empty);
            _httpContextAccessor.HttpContext.Session.SetString("UserEmail", usuario.Email ?? string.Empty);
            _httpContextAccessor.HttpContext.Session.SetInt32("IsAdmin", usuario.TipoId == 1 ? 1 : 0);
        }

        // Logout do usuário
        public void Logout()
        {
            _httpContextAccessor?.HttpContext?.Session?.Clear();
        }

        // Verificar se usuário está logado
        public bool IsLoggedIn()
        {
            return _httpContextAccessor?.HttpContext?.Session?.GetInt32("UserId") != null;
        }

        // Obter ID do usuário logado
        public int? GetUserId()
        {
            return _httpContextAccessor?.HttpContext?.Session?.GetInt32("UserId");
        }

        // Obter nome do usuário logado
        public string GetUserName()
        {
            return _httpContextAccessor?.HttpContext?.Session?.GetString("UserName") ?? string.Empty;
        }
        // ... métodos existentes

        // Verificar se usuário é admin
        public bool IsAdmin()
        {
            var isAdmin = _httpContextAccessor?.HttpContext?.Session?.GetInt32("IsAdmin");
            return isAdmin == 1;
        }
    }
}