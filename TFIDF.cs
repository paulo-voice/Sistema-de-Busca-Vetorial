using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaLojaBusca
{
    public class TFIDF
    {
        public static Dictionary<string, double> CalcularTF(List<string> tokens)
        {
            var tf = new Dictionary<string, double>();
            foreach (var token in tokens)
            {
                if (tf.ContainsKey(token))
                    tf[token]++;
                else
                    tf[token] = 1;
            }

            int totalTokens = tokens.Count;
            foreach (var key in tf.Keys.ToList())
            {
                tf[key] /= totalTokens;
            }

            return tf;
        }

        public static Dictionary<string, double> CalcularIDF(List<List<string>> todosDocumentos)
        {
            var idf = new Dictionary<string, double>();
            int totalDocumentos = todosDocumentos.Count;

            foreach (var documento in todosDocumentos)
            {
                foreach (var token in documento.Distinct())
                {
                    if (idf.ContainsKey(token))
                        idf[token]++;
                    else
                        idf[token] = 1;
                }
            }

            foreach (var key in idf.Keys.ToList())
            {
                idf[key] = Math.Log(totalDocumentos / idf[key]);
            }

            return idf;
        }

        public static Dictionary<string, double> CalcularTFIDF(Dictionary<string, double> tf, Dictionary<string, double> idf)
        {
            var tfidf = new Dictionary<string, double>();
            foreach (var key in tf.Keys)
            {
                tfidf[key] = tf[key] * idf[key];
            }
            return tfidf;
        }
    }
}