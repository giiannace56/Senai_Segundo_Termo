using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroads_webApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string Nome { get; set; }
        public decimal? CapMaxVida { get; set; }
        public decimal? CapMaxMana { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
