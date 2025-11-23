using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLeitura.Core.Models
{
    public enum StatusLeitura
    {
        ParaLer,
        Lendo,
        Lido
    }

    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public StatusLeitura Status { get; set; } = StatusLeitura.ParaLer;
    }
}

