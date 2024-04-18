using System.Security.Cryptography;
using System.Text;

namespace DanderiTV.Layer.Application.Helpers
{
    public class GetGUID
    {
        //Hasheando el ID del user
        private string HashUniqueAppKey(string KeyApp)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(KeyApp));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string GenerateGuidApp(string claveUnica)
        {
            string AppHashedKey = HashUniqueAppKey(claveUnica);
            Guid guid = Guid.NewGuid();
            string UniqueGuid = $"{AppHashedKey}{guid}";
            return UniqueGuid;
        }

    }
}
