using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BlogIT.Utility
{
    public class AESEncryption : IEncryptDecrypt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Plain text</param>
        /// <param name="key">Public secret key</param>
        /// <returns></returns>
        public string EncryptedText(string text, string key)
        {
            // Convert String to Byte

            var msgBytes = Utilities.ToUTFBytes(text);
            var keyBytes = Utilities.ToUTFBytes(key);

            // Hash the password with SHA256
            //Secure Hash Algorithm
            //Operation And, Xor, Rot,Add (mod 232),Or, Shr
            //block size 1024
            //Rounds 80
            //rotation operator , rotates point1 to point2 by theta1=> p2=rot(t1)p1
            //SHR shift to right
            keyBytes = Utilities.ToSHA256HashBytes(keyBytes);

            byte[] bytesEncrypted = Encryption(msgBytes, keyBytes);

            return Convert.ToBase64String(bytesEncrypted);
        }
        
        private byte[] Encryption(byte[] msg, byte[] Key)
        {
            if (Key == null) throw new ArgumentNullException("Key");
            byte[] encryptedBytes;

            //salt is generated randomly as an additional number to hash password or message in order o dictionary attack
            //against pre computed rainbow table
            //dictionary attack is a systematic way to test all of possibilities words in dictionary wheather or not is true?
            //to find decryption key
            //rainbow table is precomputed key for cracking password
            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.  == 16 bits
            byte[] saltBytes = {1, 2, 3, 4, 5, 6, 7, 8};

            using (var ms = new MemoryStream())
            {
                using (var aes = new RijndaelManaged())
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(Key, saltBytes, 1000);
                    aes.Key = key.GetBytes(aes.KeySize/8);
                    aes.IV = key.GetBytes(aes.BlockSize/8);

                    aes.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(msg, 0, msg.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public string DecryptedText(string text, string key)
        {
            // Convert String to Byte
            byte[] msgBytes = Utilities.FromBase64(text);
            byte[] keyBytes = Utilities.ToUTFBytes(key);
            keyBytes = Utilities.ToSHA256HashBytes(keyBytes);

            byte[] bytesDecrypted = Decryption(msgBytes, keyBytes);

            return Utilities.ToUTFText(bytesDecrypted);
        }
        private byte[] Decryption(byte[] msg, byte[] keyByte)
        {
            byte[] decryptedBytes;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = {1, 2, 3, 4, 5, 6, 7, 8};

            using (var ms = new MemoryStream())
            {
                using (var aes = new RijndaelManaged())
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(keyByte, saltBytes, 1000);
                    aes.Key = key.GetBytes(aes.KeySize/8);
                    aes.IV = key.GetBytes(aes.BlockSize/8);

                    aes.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(msg, 0, msg.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}