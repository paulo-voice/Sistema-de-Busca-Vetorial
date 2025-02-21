using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Integrantes: Paulo Vinicius Ruffini Azevedo e Caio Corrêa Castro
namespace Sistema_Busca_Vetorial.Core
{
    public static class TextoHelper
    {
        // lista de palavras comuns que devem ser ignoradas na busca
        private static readonly string[] Stopwords = { "de", "a", "o", "e", "da", "do", "em", "na", "no", "para", "com" };

        // metodo para dividir um texto em tokens (palavras individuais)
        public static List<string> Tokenizar(string texto)
        {
            return texto.ToLower()
                        .Split(new[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
        }

        // metodo para remover stopwords dos tokens, melhorando a relevancia da busca
        public static List<string> RemoverStopwords(List<string> tokens)
        {
            return tokens.Where(token => !Stopwords.Contains(token)).ToList();
        }

        // metodo simples de stemming para reduzir palavras a sua raiz
        public static List<string> AplicarStemming(List<string> tokens)
        {
            return tokens.Select(token =>
            {
                // remove sufixos comuns para simplificar a palavra
                if (token.EndsWith("ando") || token.EndsWith("endo"))
                    return token.Substring(0, token.Length - 4);
                if (token.EndsWith("mente"))
                    return token.Substring(0, token.Length - 5);
                return token;
            }).ToList();
        }
    }
}
