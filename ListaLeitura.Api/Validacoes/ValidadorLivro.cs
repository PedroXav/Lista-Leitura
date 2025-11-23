using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacoes
{
    public static class ValidadorLivro
    {
        public static bool TituloValido(string titulo)
        {
            return !string.IsNullOrWhiteSpace(titulo) && titulo.Length > 3;
        }

        public static bool AutorValido(string autor)
        {
            return !string.IsNullOrWhiteSpace(autor) && autor.Length > 3;
        }

        public static bool StatusValido(int status)
        {
            return status >= 0 && status <= 2;
        }
    }
}


