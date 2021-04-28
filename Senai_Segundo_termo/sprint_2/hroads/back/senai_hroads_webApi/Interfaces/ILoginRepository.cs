using senai_hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface ILoginRepository
    {
        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
