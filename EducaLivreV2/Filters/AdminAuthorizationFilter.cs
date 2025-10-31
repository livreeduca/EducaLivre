using EducaLivreV2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EducaLivreV2.Filters
{
    public class AdminAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authService = context.HttpContext.RequestServices.GetService<AuthService>();

            if (authService == null || !authService.IsAdmin())
            {
                // Redireciona para Home se não for admin
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}