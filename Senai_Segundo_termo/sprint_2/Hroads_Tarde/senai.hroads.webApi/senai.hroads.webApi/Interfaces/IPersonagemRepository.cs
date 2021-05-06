using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        List<Personagen> Listar();

        Personagen BuscarPorId(int id);

        void Cadastrar(Personagen entity);

        void Atualizar(int id, Personagen entity);

        void Deletar(int id);
    }
}
