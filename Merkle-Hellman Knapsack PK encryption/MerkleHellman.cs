using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Merkle_Hellman_Knapsack_PK_encryption
{
    internal class MerkleHellman
    {
        
        private BigInteger[] w = { 2, 7, 11, 21, 42, 89, 180, 354 };
        private BigInteger q = 881;
        private BigInteger r = 588; 

        
        public BigInteger[] GetPublicKey()
        {
            BigInteger[] b = new BigInteger[w.Length];
            for (int i = 0; i < w.Length; i++)
            {
                b[i] = (w[i] * r) % q;
            }
            return b;
        }

        
        public async Task<string> EncryptAsync(string message)
        {
            return await Task.Run(() =>
            {
                byte[] bytes = Encoding.ASCII.GetBytes(message);
                BigInteger[] publicKey = GetPublicKey();
                List<string> result = new List<string>();

                foreach (byte b in bytes)
                {
                    BigInteger sum = 0;
                   
                    for (int i = 0; i < 8; i++)
                    {
                        
                        if (((b >> (7 - i)) & 1) == 1)
                        {
                            sum += publicKey[i];
                        }
                    }
                    result.Add(sum.ToString());
                }
               
                return string.Join(" ", result);
            });
        }
    }
}
