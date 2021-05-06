using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        hroadsContext _context = new hroadsContext();
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            Usuario usuarioLogin = _context.Usuarios.FirstOrDefault(e => e.EmailsUsuarios == email && e.SenhasUsuarios == senha);

            if (usuarioLogin.EmailsUsuarios != null)
            {
                return usuarioLogin;
            }

            return null;
        }
    }
}
