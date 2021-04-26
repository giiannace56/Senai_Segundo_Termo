using senai_peoples_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webAPI.Interfaces
{
    /// <summary>
    /// Esta é a interface que é resposável pelo repositório "FuncionarioRepository"
    /// </summary>
    interface IFuncionarioRepository
    {
        /// <summary>
        /// Será uma lista de funcionários
        /// </summary>
        /// <returns> Uma lista de funcionários </returns>
        List<FuncionarioDomain> Listar();

        /// <summary>
        /// Será uma lista de funcionários ordenada
        /// </summary>
        /// <returns> Uma lista de funcionários ordenada </returns>
        List<FuncionarioDomain> ListarOrdenado(string ordem);

        /// <summary>
        /// Será buscado um funcionário pelo seu id
        /// </summary>
        /// <param name="id"> é o id que será buscado </param>
        /// <returns> um objeto funcionário que foi buscado </returns>
        FuncionarioDomain BuscarPorId(int id);

        /// <summary>
        /// Será buscado um funcionário pelo seu primeiro nome
        /// </summary>
        /// <param name="nome"> é o nome que será buscado </param>
        /// <returns> um objeto funcionário que foi buscado </returns>
        FuncionarioDomain BuscarPorNome(string nome);


        /// <summary>
        /// Deleta um funcionário existente
        /// </summary>
        /// <param name="id"> id do funcionário que será deletado </param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um funcionário existente passando o id pela a URL da requisição
        /// </summary>
        /// <param name="id"> id do funcionário que será atualizado </param>
        /// <param name="funcionario"> objeto "funcionario" com as novas informações </param>
        void Atualizar(int id, FuncionarioDomain funcionario);

        /// <summary>
        /// Cadastra um novo funcionário
        /// </summary>
        /// <param name="novoFuncionario"> objeto funcionário com as informações que serão cadastradas </param>
        void Cadastrar(FuncionarioDomain novoFuncionario);
    }
}
