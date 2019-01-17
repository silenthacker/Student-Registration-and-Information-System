using System;
using System.IO;
using System.Text;

using System.Security.Cryptography;
using Microsoft.CSharp.RuntimeBinder;
namespace Application
{
    class Cryptography
    {
        private string EncryptionKey = "XF5YU290XDS4Z16";
        private string EncryptionKey1 = "AAH777SEX10FUCK";
        private string EncryptionKey2 = "090LFJFKBBD8XXA";
        private string EncryptionKey3 = "QWERU360XDU0X44";
        private string EncryptionKey4 = "MNMYUHF0XDOPLOI";
        
        public string Encrypt(string ClearText)
        {
            byte[] ClearBytes = Encoding.Unicode.GetBytes(ClearText);

            using (Aes Encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes PDF = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });

                Encryptor.Key = PDF.GetBytes(32);
                Encryptor.IV = PDF.GetBytes(16);

                using (MemoryStream MemStream = new MemoryStream())
                {
                    using (CryptoStream CryptStream = new CryptoStream(MemStream, Encryptor.CreateEncryptor(),
                        CryptoStreamMode.Write))
                    {
                        CryptStream.Write(ClearBytes, 0, ClearBytes.Length);
                        CryptStream.Close();
                    }
                    ClearText = Convert.ToBase64String(MemStream.ToArray());
                }
            }
            return ClearText;
        }

        public string Decrypt(string CipherText)
        {
            byte[] CipherByte = Convert.FromBase64String(CipherText);

            using (Aes Encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes PDF = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                    });

                Encryptor.Key = PDF.GetBytes(32);
                Encryptor.IV = PDF.GetBytes(16);

                using (MemoryStream MemStream = new MemoryStream())
                {
                    using (CryptoStream CryptStream = new CryptoStream(MemStream, Encryptor.CreateDecryptor(),
                        CryptoStreamMode.Write))
                    {
                        CryptStream.Write(CipherByte, 0, CipherByte.Length);
                        CryptStream.Close();
                    }
                    CipherText = Encoding.Unicode.GetString(MemStream.ToArray());
                }
            }
            return CipherText;
        }

        private void Use()
        {
            EncryptionKey1.ToUpper();
            EncryptionKey2.ToUpper();
            EncryptionKey3.ToUpper();
            EncryptionKey4.ToUpper();
        }
    }
}
