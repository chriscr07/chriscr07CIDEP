using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace API.Helpers
{
    public class StringNormalizerHelper
    {
        public static string CharacterNormalizer(string input)
        {
            // Define un diccionario de caracteres especiales y sus equivalentes sin diacríticos
            var replacements = new Dictionary<char, char>
            {
                {'á', 'a'}, {'é', 'e'}, {'í', 'i'}, {'ó', 'o'}, {'ú', 'u'},
                {'Á', 'A'}, {'É', 'E'}, {'Í', 'I'}, {'Ó', 'O'}, {'Ú', 'U'},
                {'ñ', 'n'}, {'Ñ', 'N'}, {'ü', 'u'}, {'Ü', 'U'}
                // Agrega aquí otros caracteres especiales y sus equivalentes
            };

            // Reemplaza los caracteres especiales en la cadena de entrada
            foreach (var entry in replacements)
            {
                input = input.Replace(entry.Key, entry.Value);
            }

            return input;
        }
    }
}
