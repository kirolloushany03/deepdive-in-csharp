using System.Security.Cryptography;


namespace DeepDive_In_C_
{
    internal class RandomSecretKeyGenrator
    {
        public static void Generate_secretKey()
        {
            // Generate a 512-bit (64-byte) key
            var key = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(key);

            // Convert the key to a Base64 string
            var base64Key = Convert.ToBase64String(key);

            // Output the key
            Console.WriteLine("Generated Key: " + base64Key);

        }
    }
}
