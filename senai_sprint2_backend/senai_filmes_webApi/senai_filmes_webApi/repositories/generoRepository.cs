using senai_filmes_webApi.domains;
using senai_filmes_webApi.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.repositories
{
    public class generoRepository : IGenerorepository
    {
        private string stringConexao = "Data Source = DESKTOP-79ATS9L\\SQLEXPRESS; initial catalog = Filmes ; user id = sa; pwd = PsBF0203";
        public void AtualizarIdCorpo(generoDomain update)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAttIdCorpo = "UPDATE Genero SET nome = @nome WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryAttIdCorpo,con))
                {
                    cmd.Parameters.AddWithValue("@nome", update.nome);
                    cmd.Parameters.AddWithValue("@ID", update.idGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, generoDomain update)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizarIdUrl = "UPDATE Genero SET nome = @nome WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryAtualizarIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nome", update.nome);
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public generoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string sqlbusca = "SELECT idGenero, nome FROM Genero WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(sqlbusca,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader rdr;

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        generoDomain genero = new generoDomain()
                        {
                            idGenero = Convert.ToInt32(rdr["idGenero"]),
                            nome = rdr["nome"].ToString()
                        };

                        return genero;
                    }
                    return null;

                }
            }
        }

        public void Cadastrar(generoDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"INSERT INTO Genero (nome) VALUES (@genero)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@genero", novoGenero.nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Genero WHERE idGenero = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<generoDomain> ListarTodos()
        {
            List<generoDomain> ListaGeneros = new List<generoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                con.Open();

                string Comando = "SELECT * FROM Genero";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Comando,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        generoDomain genero = new generoDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),
                            nome = rdr[1].ToString()
                        };
                        ListaGeneros.Add(genero);
                    }
                }
                return ListaGeneros;
            }
        }
    }
}
