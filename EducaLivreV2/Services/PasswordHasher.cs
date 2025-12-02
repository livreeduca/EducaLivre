using BCrypt.Net;

namespace EducaLivreV2.Services
{
    public static class PasswordHasher
    {
        // Cria hash da senha
        public static string HashPassword(string password)
        {
            // Work factor de 13 (seguro e razoavelmente rápido)
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        }

        // Verifica se a senha confere com o hash
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        }
    }
}