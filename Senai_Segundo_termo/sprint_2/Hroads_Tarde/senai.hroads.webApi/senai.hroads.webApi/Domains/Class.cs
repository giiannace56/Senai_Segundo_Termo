using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Class
    {
        public Class()
        {
            Personagens = new HashSet<Personagen>();
        }

        public int IdClasses { get; set; }
        public string Cargos { get; set; }

        public virtual ICollection<Personagen> Personagens { get; set; }
    }
}
