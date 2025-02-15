using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaLojaBusca
{
    public static class TextoHelper
    {
        private static readonly string[] Stopwords = { "de", "a", "o", "e", "da", "do", "em", "na", "no", "para", "com" };

        public static List<string> Tokenizar(string texto)
        {
            return texto.ToLower()
                        .Split(new[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
        }

        public static List<string> RemoverStopwords(List<string> tokens)
        {
            return tokens.Where(token => !Stopwords.Contains(token)).ToList();
        }

        public static List<string> AplicarStemming(List<string> tokens)
        {
            return tokens.Select(token =>
            {
                if (token.EndsWith("ando") || token.EndsWith("endo"))
                    return token.Substring(0, token.Length - 4);
                if (token.EndsWith("mente"))
                    return token.Substring(0, token.Length - 5);
                return token;
            }).ToList();
        }
    }
}