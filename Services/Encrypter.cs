using System.Text;

namespace btw_api.Services
{
    public class Encrypter
    {
        
        // Encripta un campo a Base64 a partir de una cadena de texto
        public static string EncryptField(string field)
        {
            byte[] encryptedField = Encoding.UTF8.GetBytes(field);
            return Convert.ToBase64String(encryptedField);
        }

        // Desencripta un string encriptado en Base64
        public static string DecryptField(string field)
        {
            byte[] decryptedField = Convert.FromBase64String(field);
            return Encoding.UTF8.GetString(decryptedField);
        }

    }
}
