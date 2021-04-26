using senai_peoples_webAPI.Domains;
using senai_peoples_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-HMTUR0P; initial catalog=T_Peoples; user Id=SA; pwd=Soufoda2";

        public void Atualizar(int id, TipoUsuarioDomain tipoUsuario)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada
                string queryUpdateId = "UPDATE tipoUsuario SET permissao = @permissao WHERE idTipoUsuario = @id";

                using (SqlCommand command = new SqlCommand(queryUpdateId, connection))
                {
                    // passa os valores para os parâmetros
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@permissao", tipoUsuario.permissao);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySearchById = "SELECT idTipoUsuario, permissao FROM tipoUsuarios WHERE tipoUsuarios.idTipoUsuario = @id";

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
                        TipoUsuarioDomain tipoUsuarioBuscado = new TipoUsuarioDomain
                        {
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                            permissao = reader["permissao"].ToString()
                        };

                        // retorna os "tipoUsuarioBuscado" com os dados obtidos
                        return tipoUsuarioBuscado;
                    }
                    // se não, retorna null
                    else
                        return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                // declara a query a ser executada passando o parâmetro @id
                string queryDelete = "DELETE tipoUsuarios WHERE tipoUsuarios.idTipoUsuario = @id";

                // declara o SqlCommand "command" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand command = new SqlCommand(queryDelete, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    // abre a conexão com o banco de dados
                    connection.Open();

                    // executa o comando
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> listaTipoUsuarios = new List<TipoUsuarioDomain>();

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idTipoUsuario, permissao FROM tipoUsuarios";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectAll, connection))
                {
                    // executa a query e armazena os dados no "reader"
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                            permissao = reader["permissao"].ToString(),
                        };

                        listaTipoUsuarios.Add(tipoUsuario);
                    }

                    return listaTipoUsuarios;
                }
            }
        }

    }
}