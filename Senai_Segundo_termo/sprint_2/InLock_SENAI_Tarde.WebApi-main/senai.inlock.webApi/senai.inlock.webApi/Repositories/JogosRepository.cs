using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class JogosRepository : IJogosRepository
    {

        //Criar string de conexão para conectar com o banco de dados

        string stringConexao = "Data Source = 'LAPTOP-5IAR0TCC' ; Initial Catalog = 'inlock_games_tarde'; user id = 'sa'; pwd = 'senai@132' ";
        //string stringconexao = "";


        public void ApagarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryExcluirId = "DELETE * FROM Jogos WHERE IdJogo = @Id";

                con.Open();

                //SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryExcluirId, con) )
                {

                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void AtualizarPorId(int id, Jogos jogo)
        {

            Jogos jogoatt = new Jogos();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryAtualizarId = "UPDATE jogos SET NomeJogo = @Nome" +
                                          ",Descricao                = @Descricao" +
                                          ",DataLancamento           = @DataLancamento" +
                                          ",Valor                    = @Valor " +
                                          "WHERE IdJogo              = @IdJogo";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryAtualizarId, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", jogoatt.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", jogoatt.descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogoatt.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogoatt.Valor);
                    cmd.Parameters.AddWithValue("@IdJogo", jogoatt.IdJogo);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Cadastrar(Jogos novojogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryAddNovo = "INSERT INTO Jogos (Nome, IdEstudio, Descricao, DataLancamento, Valor) " +
                                      "VALUES          @Nome, @IdEstudio, @Descricao, @DataLancamento, @Valor";

                using (SqlCommand cmd = new SqlCommand(queryAddNovo, con))
                {

                    cmd.Parameters.AddWithValue("@Nome",            novojogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@IdEstudio",       novojogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Descricao",       novojogo.descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento",  novojogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor",           novojogo.Valor);

                    cmd.ExecuteNonQuery();

                    con.Open();

                }
            };
        }

        public Jogos ListarId(int IdJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryListarId = "SELECT NomeJogo, IdEstudio, Descricao, DataLancamento FROM Jogos WHERE IdJogo = @IdJogo";


                con.Open();
                
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryListarId, con))
                {

                    Jogos jogoBuscado = new Jogos();

                    cmd.Parameters.AddWithValue("@IdJogo", IdJogo );

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {

                        jogoBuscado.NomeJogo       = rdr[0].ToString();
                        jogoBuscado.IdEstudio      = Convert.ToInt32(rdr[1]);
                        jogoBuscado.descricao      = rdr[2].ToString();
                        jogoBuscado.DataLancamento = Convert.ToDateTime(rdr[3]);

                    }
                    else
                    {
                        return null;
                    }

                    return jogoBuscado;
                    
                }

            }
        }

        public List<Jogos> ListarJogos()
        {

            List<Jogos> ListaDeJogos = new List<Jogos>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelecionarTudo = "SELECT NomeJogo, IdEstudio, Descricao FROM jogos ";

                SqlDataReader rdr;

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelecionarTudo, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        Jogos jogo = new Jogos();

                        jogo.NomeJogo = rdr["NomeJogo"].ToString();
                        jogo.IdEstudio = Convert.ToInt32(rdr["IdEstudio"]);
                        jogo.descricao = rdr["Descricao"].ToString();

                        ListaDeJogos.Add(jogo);

                    }

                    return ListaDeJogos;

                }
            }
        }
    }
}
