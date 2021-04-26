using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {

        string stringConexao = "Data Source = 'LAPTOP-5IAR0TCC' ; Initial Catalog = 'inlock_games_tarde'; user id = 'sa'; pwd = 'senai@132' ";

        public void AtualizarId(int id, Estudios EstudioAtt)
        {

            Estudios estudioatt = new Estudios();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryAttId = "UPDATE Estudios SET NomeEstudio = @NomeEstudio WHERE IdEstudio = @Id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryAttId, con))
                {

                    cmd.Parameters.AddWithValue("@NomeEstudio", estudioatt.NomeEstudio);
                    cmd.Parameters.AddWithValue("@Id", estudioatt.IdEstudio);


                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Cadastrar(Estudios novoEstudio)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryRegistrar = "INSERT INTO Estudios NomeEstudio VALUES" +
                                        "@NomeEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryRegistrar, con))
                {

                    cmd.Parameters.AddWithValue("@NomeEstudio", novoEstudio.NomeEstudio);

                    cmd.ExecuteNonQuery();

                }
            }

        }

        public void DeletarId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDeletarId = "DELETE * FROM Estudio WHERE IdEstudio = @IdEstudio";

                con.Open();
                
                using (SqlCommand cmd = new SqlCommand(queryDeletarId, con))
                {

                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    cmd.ExecuteNonQuery();

                }

            }
        }

        public List<Estudios> Listar()
        {

            List<Estudios> estudios = new List<Estudios>();

            Estudios estudio = new Estudios();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryListar = "SELECT NomeEstudio FROM Estudios ";

                SqlDataReader rdr;

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryListar, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        estudio.NomeEstudio = rdr["NomeEstudio"].ToString();

                        estudios.Add(estudio);

                    }

                    return estudios;

                }

            }

        }

        public Estudios ListarId(int id)
        {

            Estudios estudio = new Estudios();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryListarId = "SELECT NomeEstudio FROM Estudios WHERE IdEstudio = @Id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryListarId, con))
                {

                    cmd.Parameters.AddWithValue("@Id", estudio.IdEstudio);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {

                        estudio.NomeEstudio = rdr[0].ToString();

                        return estudio;
                        
                    }

                    //cmd.ExecuteNonQuery();

                    return null;

                }

            }
        }
    }
}
