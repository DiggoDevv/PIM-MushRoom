using System.Security.Cryptography;
using System.Text;

namespace PIM.Helper
{
    public static class Criptografia
    {
        //this string = para conseguir usar o método em qualquer string.
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }
            return strHexa.ToString();
        } 
    }
}
