using senai.inlock.webApi_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface ILoginRepository
    {

        Login BuscarLogin(string email, string senha);

    }
}
