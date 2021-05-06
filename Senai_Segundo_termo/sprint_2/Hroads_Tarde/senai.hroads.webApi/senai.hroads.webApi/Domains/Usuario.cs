using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuarios { get; set; }
        public string EmailsUsuarios { get; set; }
        public string SenhasUsuarios { get; set; }
        public int? IdTiposUsuarios { get; set; }

        public virtual TiposUsuario IdTiposUsuariosNavigation { get; set; }
    }
}
