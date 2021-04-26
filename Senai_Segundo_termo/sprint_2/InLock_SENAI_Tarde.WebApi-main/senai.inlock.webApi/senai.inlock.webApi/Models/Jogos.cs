using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Models
{
    public class Jogos
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }

        public string NomeJogo { get; set; }

        public string descricao { get; set; }

        public DateTime DataLancamento { get; set; }

        public float Valor { get; set; }
    }
}
