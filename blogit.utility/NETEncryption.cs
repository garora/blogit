using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BlogIT.Utility
{
    /// <summary>
    ///     Class for Cryptography
    /// </summary>
    public class NetEncryption
    {
        public NetEncryption()
        {
            PassPhrase = "Pas5pr@se";
            SaltValue = "123#ABCDefg";
            HashAlgorithmType = "SHA1";
            PasswordIterations = 2;
            InitVector = "@1B2c3D4e5F6g7H8";
            KeySize = 256;
        }

        #region Encryption

        /// <summary>
        ///     Encrypt Plain Text
        /// </summary>
        /// <param name="plainText">Plain text</param>
        /// <returns>A base64 cipher Text</returns>
        public string TextEncryption(string plainText)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);

                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                var password = new PasswordDeriveBytes(
                    PassPhrase,
                    saltValueBytes,
                    HashAlgorithmType,
                    PasswordIterations);

                byte[] keyBytes = password.GetBytes(KeySize/8);

                var symmetricKey = new RijndaelManaged {Mode = CipherMode.CBC};


                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

                var memoryStream = new MemoryStream();

                var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();

                memoryStream.Close();
                cryptoStream.Close();

                string cipherText = Convert.ToBase64String(cipherTextBytes);

                return cipherText;
            }
            catch
            {
                throw;
            }
        }

        //public string TextEncryption(string plainText, bool isUrl)
        //{
        //    return isUrl ? HttpUtility.UrlEncode(TextEncryption(plainText)) : TextEncryption(plainText);

        //}
        /// <summary>
        ///     Encrypt Plain Text
        /// </summary>
        /// <param name="plainText">Plain text</param>
        /// <param name="isUrl">Whether use for Url or not</param>
        /// <returns>A base64 cipher text if not use for url </returns>
        /// <summary>
        ///     Encode string
        /// </summary>
        /// <param name="origText">Plain Text</param>
        /// <returns>Encoded string without special characters</returns>
        public string EncodeString(string origText)
        {
            byte[] stringBytes = Encoding.Unicode.GetBytes(origText);
            return Convert.ToBase64String(stringBytes, 0, stringBytes.Length);
        }

        #endregion

        #region Decryption

        /// <summary>
        ///     Decrypt A cypher text earlier encrypted using TextEncryption method
        /// </summary>
        /// <param name="cipherText">A base64 bit cypher text</param>
        /// <returns>Plain text</returns>
        public string TextDecryption(string cipherText)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);

                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                var password = new PasswordDeriveBytes(
                    PassPhrase,
                    saltValueBytes,
                    HashAlgorithmType,
                    PasswordIterations);

                byte[] keyBytes = password.GetBytes(KeySize/8);

                var symmetricKey = new RijndaelManaged {Mode = CipherMode.CBC};


                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                    keyBytes,
                    initVectorBytes);

                var memoryStream = new MemoryStream(cipherTextBytes);

                var cryptoStream = new CryptoStream(memoryStream,
                    decryptor,
                    CryptoStreamMode.Read);

                var plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                    0,
                    plainTextBytes.Length);

                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes,
                    0,
                    decryptedByteCount);

                return plainText;
            }
            catch
            {
                throw;
            }
        }

        //public string TextDecryption(string cipherText, bool isUrl)
        //{
        //    return isUrl ? TextDecryption(HttpUtility.UrlDecode(cipherText)) : TextDecryption(cipherText);
        //}
        /// <summary>
        ///     Decrypt A cypher text earlier encrypted using TextEncryption method
        /// </summary>
        /// <param name="cipherText">A base64 bit cypher text</param>
        /// <param name="isUrl">Whether use for Url or not</param>
        /// <returns>Plain Text</returns>
        /// <summary>
        ///     Decode string
        /// </summary>
        /// <param name="encodedText">Encoded string</param>
        /// <returns>Plain text</returns>
        public string DecodeString(string encodedText)
        {
            byte[] stringBytes = Convert.FromBase64String(encodedText);
            return Encoding.Unicode.GetString(stringBytes);
        }

        #endregion

        public string PassPhrase { get; set; }
        public string SaltValue { get; set; }
        public string HashAlgorithmType { get; set; }
        public int PasswordIterations { get; set; }
        public string InitVector { get; set; }
        public int KeySize { get; set; }
    }
}