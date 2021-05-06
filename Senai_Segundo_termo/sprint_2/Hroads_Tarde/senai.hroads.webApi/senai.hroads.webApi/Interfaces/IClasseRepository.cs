using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
        List<Class> Listar();

        Class BuscarPorId(int id);

        void Cadastrar(Class novaClasse);

        void Atualizar(int id, Class classeAtualizada);

        void Deletar(int id);
    }
}
