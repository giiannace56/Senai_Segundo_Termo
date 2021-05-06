using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagen
    {
        public int IdPersonagem { get; set; }
        public string Nomes { get; set; }
        public string VidaMaxima { get; set; }
        public string ManaMaxima { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? IdClasses { get; set; }

        public virtual Class IdClassesNavigation { get; set; }
    }
}
