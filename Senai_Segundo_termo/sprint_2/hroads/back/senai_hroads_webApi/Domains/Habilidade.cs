using System;
using System.Collections.Generic;

#nullable disable

namespace senai_hroads_webApi.Domains
{
    public partial class Habilidade
    {
        public int IdHabilidade { get; set; }
        public int? IdTipo { get; set; }
        public string Habilidade1 { get; set; }

        public virtual TipoHabilidade IdTipoNavigation { get; set; }
    }
}
