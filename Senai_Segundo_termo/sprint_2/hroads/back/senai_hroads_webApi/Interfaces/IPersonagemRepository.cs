using senai_hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface IPersonagemRepository
    {
        List<Personagem> Listar();

        Personagem BuscarPorId(int id);

        void Cadastrar(Personagem entity);

        void Atualizar(int id, Personagem entity);

        void Deletar(int id);
    }
}
