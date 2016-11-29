# SymmetricKeyEncryption

Sample project to show how to encrypt data using .Net Core.

~~~~
	public static string GenerateKey()
        {
            using (TripleDES tripleDES = TripleDES.Create())
            {
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                tripleDES.GenerateKey();
                return Convert.ToBase64String(tripleDES.Key);
            }
        }

        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            using (TripleDES tripleDES = TripleDES.Create())
            {
                tripleDES.Key = Convert.FromBase64String(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tripleDES.CreateEncryptor();
                byte[] resultArray = transform.TransformFinalBlock(inputArray, 0, inputArray.Length);            
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }

        }

        public static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            using (TripleDES tripleDES = TripleDES.Create())
            {
                tripleDES.Key = Convert.FromBase64String(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tripleDES.CreateDecryptor();
                byte[] resultArray = transform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
        }
~~~~
