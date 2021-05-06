using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTiposUsuarios { get; set; }
        public string TiposUsuarios { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
