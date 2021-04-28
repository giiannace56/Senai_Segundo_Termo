using senai_hroads_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {

        List<TipoHabilidade> Listar();

        TipoHabilidade BuscarPorId(int id);

        void Cadastrar(TipoHabilidade novoTipo);

        void Atualizar(int id, TipoHabilidade tipoAtualizado);

        void Deletar(int id);
    }
}
