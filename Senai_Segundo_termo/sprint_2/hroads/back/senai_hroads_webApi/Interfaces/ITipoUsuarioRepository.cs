using senai_hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        TipoUsuario BuscarPorId(int id);

        void Cadastrar(TipoUsuario entity);

        void Atualizar(int id, TipoUsuario entity);

        void Deletar(int id);
    }
}
