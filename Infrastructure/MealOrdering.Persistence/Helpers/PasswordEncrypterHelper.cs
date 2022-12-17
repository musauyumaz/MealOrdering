using System.Text;

namespace MealOrdering.Persistence.Helpers
{
    public static class PasswordEncrypterHelper
    {
        public static string Encrypt(string password)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
