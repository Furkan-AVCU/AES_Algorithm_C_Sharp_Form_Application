using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AES_Algorithm
{
    class AES_Class
    {
        private const String AES_IV = @"!&+QWSDF!123126+";
        private const String aesAnahtar = @"QQsaw!257()%%ert";
        AesCryptoServiceProvider aesKriptoServisSağlayıcı = new AesCryptoServiceProvider();



        public string AesSifrele(string inputText)
        {
            aesKriptoServisSağlayıcı.BlockSize = 128; // 192 vs de olabilir ben 128 tercih ettim
            aesKriptoServisSağlayıcı.KeySize = 128;

            aesKriptoServisSağlayıcı.IV = Encoding.UTF8.GetBytes(AES_IV);
            aesKriptoServisSağlayıcı.Key = Encoding.UTF8.GetBytes(aesAnahtar);
            aesKriptoServisSağlayıcı.Mode = CipherMode.CBC;
            aesKriptoServisSağlayıcı.Padding = PaddingMode.PKCS7;

            byte[] byteArrayOfInput = Encoding.Unicode.GetBytes(inputText);
            using (ICryptoTransform sifrele = aesKriptoServisSağlayıcı.CreateEncryptor())
            {
                byte[] ciktiByteDizisi = sifrele.TransformFinalBlock(byteArrayOfInput, 0, byteArrayOfInput.Length);
                return Convert.ToBase64String(ciktiByteDizisi);
            }
        }

        public string AesSifresiniCoz(string inputText)
        {
            aesKriptoServisSağlayıcı.BlockSize = 128; // 192 vs de olabilir ben 128 tercih ettim
            aesKriptoServisSağlayıcı.KeySize = 128;

            aesKriptoServisSağlayıcı.IV = Encoding.UTF8.GetBytes(AES_IV);
            aesKriptoServisSağlayıcı.Key = Encoding.UTF8.GetBytes(aesAnahtar);
            aesKriptoServisSağlayıcı.Mode = CipherMode.CBC;
            aesKriptoServisSağlayıcı.Padding = PaddingMode.PKCS7;

            byte[] cozulecekVerininByteDizisi = Convert.FromBase64String(inputText);
            using (ICryptoTransform sifreCoz = aesKriptoServisSağlayıcı.CreateDecryptor())
            {
                byte[] ciktiByteDizisi = sifreCoz.TransformFinalBlock(cozulecekVerininByteDizisi, 0, cozulecekVerininByteDizisi.Length);
                return Encoding.Unicode.GetString(ciktiByteDizisi);
            }
        }

    }


}
