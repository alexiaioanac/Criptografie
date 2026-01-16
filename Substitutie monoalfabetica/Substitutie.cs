using System;
using System.Collections.Generic;
using System.Text;

namespace Substitutie_monoalfabetica
{
    internal class Substitutie
    {
       
            private static string alfabet = "abcdefghijklmnopqrstuvwxyz";
            private static string cheie = "mipodsqrabcfghjklntuvwxyz";

            public static string Encrypt(string plain)
            {
                if (string.IsNullOrWhiteSpace(plain)) return plain;
                StringBuilder sb = new StringBuilder();

                foreach (char c in plain.ToLower())
                {
                    int index = alfabet.IndexOf(c);
                    if (index != -1) sb.Append(cheie[index]);
                    else sb.Append(c); 
                }
                return sb.ToString();
            }

            public static string Decrypt(string cipher)
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in cipher.ToLower())
                {
                    int index = cheie.IndexOf(c);
                    if (index != -1) sb.Append(alfabet[index]);
                    else sb.Append(c);
                }
                return sb.ToString();
            }

            public static string AnalizaFrecventa(string cipher)
            {
                var frecventa = cipher.ToLower()
                    .Where(c => char.IsLetter(c))
                    .GroupBy(c => c)
                    .OrderByDescending(g => g.Count());

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Frecvența literelor detectate:");
                foreach (var grup in frecventa)
                {
                    sb.AppendLine($"Litera '{grup.Key}' apare de {grup.Count()} ori.");
                }
                return sb.ToString();
            }
        
    }
}
