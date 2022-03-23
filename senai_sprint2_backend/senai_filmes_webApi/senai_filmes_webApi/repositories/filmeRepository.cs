using senai_filmes_webApi.domains;
using senai_filmes_webApi.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.repositories
{
    public class filmeRepository : IFilmeRepository
    {

        private string stringConexao = "Data Source = DESKTOP-79ATS9L\\SQLEXPRESS; initial catalog = Filmes ; user id = sa; pwd = PsBF0203";
        public void AtualizarIdCorpo(filmeDomain update)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string att = "UPDATE Filme SET titulo = @titulo WHERE idFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(att, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", update.titulo);
                    cmd.Parameters.AddWithValue("@ID", update.idFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, filmeDomain update)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string att = "UPDATE Filme SET titulo = @titulo WHERE idFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(att, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", update.titulo);
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public filmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryMandaBusca = "SELECT idFilme, titulo FROM Filme WHERE idFilme = @ID";

                using (SqlCommand cmd =  new SqlCommand(queryMandaBusca,con))
                {
                    cmd.Parameters.AddWithValue("ID", id);
                    SqlDataReader rdr;
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        filmeDomain filme = new filmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr["idFilme"]),
                            titulo = rdr["titulo"].ToString()
                        };
                        return filme;
                    };
                    return null;
                }
            }
        }

        public void Cadastrar(filmeDomain novoFilme)
        {
            using (SqlConnection con =new SqlConnection(stringConexao))
            {
                string comando = $"INSERT INTO Filme (titulo) VALUES (@titulo)";

                using (SqlCommand cmd = new SqlCommand(comando, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", novoFilme.titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Filme WHERE idFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<filmeDomain> ListarTodos()
        {
            List<filmeDomain> ListaFilmes = new List<filmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                con.Open();
                string comando = "SELECT * FROM Filme";
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(comando,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        filmeDomain filme = new filmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr[0]),
                            titulo = rdr[2].ToString()

                        };
                        ListaFilmes.Add(filme);
                    }
                }
                return ListaFilmes;
            }
        }
    }
}
