using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Functii_hash_criptografice
{
    internal class SimpleHash
    {
        internal int hashIdx = 0;

        internal async Task HashFileAsync(string inputPath, string outputPath)
        {
            if (string.IsNullOrWhiteSpace(inputPath) || !File.Exists(inputPath))
                throw new Exception("Fisierul de intrare nu este valid!");

           
            HashAlgorithm alg = hashIdx switch
            {
                0 => MD5.Create(),
                1 => SHA1.Create(),
                2 => SHA256.Create(),
                3 => SHA384.Create(),
                4 => SHA512.Create(),
                5 => SHA3_256.Create(),
                6 => SHA3_384.Create(),
                7 => SHA3_512.Create(),
                _ => MD5.Create()
            };

            using (alg)
            {
                using var stream = File.OpenRead(inputPath);
                
                byte[] hashBytes = await alg.ComputeHashAsync(stream);

               
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes) sb.Append(b.ToString("x2"));

                await File.WriteAllTextAsync(outputPath, sb.ToString());
            }
        }
    }
}
