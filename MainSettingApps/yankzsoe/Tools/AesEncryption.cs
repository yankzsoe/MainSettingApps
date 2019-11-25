using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MainSettingApps.yankzsoe.Tools {
    internal class AesEncryption {
        internal static string EncryptString(string key, string plainText) {
            try {
                byte[] iv = new byte[16];
                byte[] array;

                using (Aes aes = Aes.Create()) {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream()) {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write)) {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream)) {
                                streamWriter.Write(plainText);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }
                return Convert.ToBase64String(array);
            } catch (Exception es) {
                throw es;
            }
        }

        internal static string DecryptString(string key, string cipherText) {
            try {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create()) {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer)) {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)) {
                            using (StreamReader streamReader = new StreamReader(cryptoStream)) {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            } catch (Exception es) {
                throw es;
            }
        }
    }
}
