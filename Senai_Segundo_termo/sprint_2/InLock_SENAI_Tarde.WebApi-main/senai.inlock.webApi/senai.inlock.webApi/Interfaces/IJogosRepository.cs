using senai.inlock.webApi_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IJogosRepository
    {

        //CRUD

        //LISTAR
        //CRIAR
        //APAGAR
        //ATUALIZAR

        /// <summary>
        /// Método para fazer a listagem dos jogos do banco de dados
        /// </summary>
        /// <returns> Os Jogos encontrados na lista de jogos do banco de dados </returns>
        List<Jogos> ListarJogos();

        Jogos ListarId(int id);

        void Cadastrar(Jogos novojogo);

        void ApagarPorId(int id);

        void AtualizarPorId(int id, Jogos jogo);

    }
}
