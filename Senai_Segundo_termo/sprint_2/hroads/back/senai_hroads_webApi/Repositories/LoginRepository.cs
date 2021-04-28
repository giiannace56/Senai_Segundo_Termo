using senai_hroads_webApi.Contexts;
using senai_hroads_webApi.Domains;
using senai_hroads_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        HroadsContext _context = new HroadsContext();
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            Usuario usuarioLogin = _context.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);

            if (usuarioLogin.Email != null)
            {
                return usuarioLogin;
            }

            return null;
        }
    }
}
