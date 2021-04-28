using senai_hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface IClasseRepository
    {

        List<Classe> Listar();

        Classe BuscarPorId(int id);

        void Cadastrar(Classe novaClasse);

        void Atualizar(int id, Classe classeAtualizada);

        void Deletar(int id);
    }
}
