using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        string stringConexao = "Data Source = 'LAPTOP-5IAR0TCC' ; Initial Catalog = 'inlock_games_tarde'; user id = 'sa'; pwd = 'senai@132' ";


        public Login BuscarLogin(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryBuscarLogin = "SELECT * FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

                SqlDataReader rdr;

                con.Open();


                using (SqlCommand cmd = new SqlCommand(queryBuscarLogin, con))
                {

                    Login login = new Login();

                    rdr = cmd.ExecuteReader();

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    cmd.ExecuteNonQuery();

                    if (rdr.Read())
                    {

                        login.IdUsuario = Convert.ToInt32(rdr[0]);
                        login.Email = rdr[1].ToString();
                        login.Senha = rdr[2].ToString();
                        login.IdTipoUsuario = Convert.ToInt32(rdr[3]);

                        return login;

                    }

                    return null;

                }

            }
        }
    }
}
