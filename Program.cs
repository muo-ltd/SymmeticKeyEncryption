using System;

namespace crypto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("TripleDes encryption");

            string key = TripleDesCrypto.GenerateKey();

            Console.WriteLine($"Generated Key: {key}");

            string data = string.Empty;

            while(true)
            {
                Console.WriteLine("Please enter data to encrypt:");
                data = Console.ReadLine();

                string encryptedData = TripleDesCrypto.Encrypt(data, key);

                Console.WriteLine($"Encrypted Data: {encryptedData}");

                string decryptedData = TripleDesCrypto.Decrypt(encryptedData, key);

                Console.WriteLine($"Test Decrypt: {decryptedData}");
            }
        }   
    }
}
