using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        List<TiposHabilidade> Listar();

        TiposHabilidade BuscarPorId(int id);

        void Cadastrar(TiposHabilidade novoTipo);

        void Atualizar(int id, TiposHabilidade tipoAtualizado);

        void Deletar(int id);
    }
}
