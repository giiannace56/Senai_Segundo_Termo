using senai_peoples_webAPI.Domains;
using senai_peoples_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webAPI.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-HMTUR0P; initial catalog=T_Peoples; user Id=SA; pwd=Soufoda2";

        /// <summary>
        /// Atualiza um funcionário passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="id"> id do funcionário que será atualizado </param>
        /// <param name="funcionario"> objeto "funcionario" com as novas informações </param>
        public void Atualizar(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE funcionarios SET nome = @nome, sobrenome = @sobrenome, dataNascimento = @dataNascimento WHERE idFuncionario = @id";

                using (SqlCommand command = new SqlCommand(queryUpdateIdUrl, connection))
                {
                    // passa os valores para os parâmetros
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nome", funcionario.nome);
                    command.Parameters.AddWithValue("@sobrenome", funcionario.sobrenome);
                    command.Parameters.AddWithValue("@dataNascimento", funcionario.dataNascimento);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um funcionário através do seu id
        /// </summary>
        /// <param name="id"> id do funcionário que será buscado </param>
        /// <returns> retorna um funcionário buscado ou null, caso não seja encontrado </returns>
        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idFuncionario, nome, sobrenome, dataNascimento FROM funcionarios WHERE funcionarios.idFuncionario = @id";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySearchById, connection))
                {
                    // passa o valor para o parâmetro @id
                    command.Parameters.AddWithValue("@id", id);

                    // executa a query e armazena os dados na "reader"
                    reader = command.ExecuteReader();

                    // verifica se o resultado da query retornou algum registro
                    if (reader.Read())
                    {
                        // se sim, será instanciado um novo objeto "funcionarioBuscado" do tipo FuncionarioDomain
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain
                        {
                            // atribui a propriedade "idFuncionario" o valor da coluna "idFuncionario" da tabela do banco de dados, assim, a ordem não vai mais importar
                            idFuncionario = Convert.ToInt32(reader["idFuncionario"]),

                            // atribui a propriedade "nome" o valor da coluna "Nome" da tabela do banco de dados
                            nome = reader["nome"].ToString(),

                            // atribui a propriedade "sobrenome" o valor da coluna "sobrenome" da tabela do banco de dados
                            sobrenome = reader["sobrenome"].ToString(),

                            // atribui a propriedade "dataNascimento" o valor da coluna "dataNascimento" da tabela do banco de dados
                            dataNascimento = Convert.ToDateTime(reader["dataNascimento"])
                        };

                        // retorna os "funcionarioBuscado" com os dados obtidos
                        return funcionarioBuscado;
                    }
                    // se não, retorna null
                    else
                        return null;
                }
            }
        }


        /// <summary>
        /// Busca um funcionário através do seu primeiro nome
        /// </summary>
        /// <param name="nome"> primeiro nome do funcionário que será buscado </param>
        /// <returns> retorna um funcionário buscado ou null, caso não seja encontrado </returns>
        public FuncionarioDomain BuscarPorNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySearchByName = "SELECT idFuncionario, nome, sobrenome, dataNascimento FROM funcionarios WHERE funcionarios.nome = @nome";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySearchByName, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain
                        {
                            idFuncionario = Convert.ToInt32(reader["idFuncionario"]),

                            nome = reader["nome"].ToString(),

                            sobrenome = reader["sobrenome"].ToString(),

                            dataNascimento = Convert.ToDateTime(reader["dataNascimento"])
                        };
                        return funcionarioBuscado;
                    }
                    else
                        return null;
                }
            }
        }


        /// <summary>
        /// Cadastra um novo funcionário
        /// </summary>
        /// <param name="novoFuncionario"> informações do novo funcionário </param>
        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO funcionarios(nome, sobrenome, dataNascimento) VALUES (@nome, @sobrenome, @dataNascimento)";

                using (SqlCommand command = new SqlCommand(queryInsert, connection))
                {
                    // passa o valor de novoFuncionario para os parâmetros(@)
                    command.Parameters.AddWithValue("@nome", novoFuncionario.nome);
                    command.Parameters.AddWithValue("@sobrenome", novoFuncionario.sobrenome);
                    command.Parameters.AddWithValue("@dataNascimento", novoFuncionario.dataNascimento);

                    // abre a conexão com o banco de dados
                    connection.Open();

                    // executa a query
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um funcionário através do seu id
        /// </summary>
        /// <param name="id"> id do funcionário que será deletado </param>
        public void Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada passando o parâmetro @id
                string queryDelete = "DELETE funcionarios WHERE funcionarios.idFuncionario = @id";

                // declara o SqlCommand "command" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand command = new SqlCommand(queryDelete, connection))
                {
                    // define o valor id recebido no método como valor do parâmetro @id || usamos esse parâmetro para não cairmos no "efeito Joana D'Arc"
                    command.Parameters.AddWithValue("@id", id);

                    // abre a conexão com o banco de dados
                    connection.Open();

                    // executa o comando
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os funcionários
        /// </summary>
        /// <returns> Uma lista de funcionários </returns>
        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>();

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idFuncionario, nome, sobrenome, dataNascimento FROM funcionarios";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectAll, connection))
                {
                    // executa a query e armazena os dados no "reader"
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // instancia um objeto "funcionario" do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            // atribui a propriedade "idFuncionario" o valor da coluna "idFuncionario" da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(reader["idFuncionario"]),

                            // atribui a propriedade "nome" o valor da coluna "nome" da tabela do banco de dados
                            nome = reader["nome"].ToString(),

                            // atribui a propriedade "sobrenome" o valor da coluna "sobrenome" da tabela do banco de dados
                            sobrenome = reader["sobrenome"].ToString(),

                            // atribui a propriedade "dataNascimento" o valor da coluna "dataNascimento" da tabela do banco de dados
                            dataNascimento = Convert.ToDateTime(reader["dataNascimento"])
                        };

                        // adiciona o objeto "funcionario" criado à lista listaFuncionarios
                        listaFuncionarios.Add(funcionario);
                    }

                    // retorna a lista de funcionarios
                    return listaFuncionarios;
                }
            }
        }


        /// <summary>
        /// Lista todos os funcionários ordenadamente
        /// </summary>
        /// <param name="ordem"> nome que definirá a ordem dos funcionários </param>
        /// <returns> Uma lista de funcionários ordenada </returns>
        public List<FuncionarioDomain> ListarOrdenado(string ordem)
        {
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>();

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySelectAllOrdered;

                if (ordem == "asc")
                {
                    querySelectAllOrdered = "SELECT idFuncionario, nome, sobrenome, dataNascimento FROM funcionarios ORDER BY idFuncionario ASC";
                }
                else
                {
                    querySelectAllOrdered = "SELECT idFuncionario, nome, sobrenome, dataNascimento FROM funcionarios ORDER BY idFuncionario DESC";
                }

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectAllOrdered, connection))
                {
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            idFuncionario = Convert.ToInt32(reader["idFuncionario"]),

                            nome = reader["nome"].ToString(),

                            sobrenome = reader["sobrenome"].ToString(),

                            dataNascimento = Convert.ToDateTime(reader["dataNascimento"])
                        };

                        // adiciona o objeto "funcionario" criado à lista listaFuncionarios
                        listaFuncionarios.Add(funcionario);
                    }

                    // retorna a lista de funcionarios
                    return listaFuncionarios;
                }
            }
        }


    }
}
