using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Models
{
    public class Login
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
