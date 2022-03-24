using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class usuarioRepository : IusuarioRepository
    {
        private string conexaoSql = "Data Source = DESKTOP-79ATS9L\\SQLEXPRESS; initial catalog = M_Peoples; user id = sa; pwd = PsBF0203";

        public void Atualizar(usuarioDomain novaInfos)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string queryUpdate = "UPDATE Usuarios SET  idTipoUsuario = @permissao, Email = @email, senha = @senha";

                using (SqlCommand cmd = new SqlCommand(queryUpdate,con))
                {
                    cmd.Parameters.AddWithValue("@permissao", novaInfos.permissao);
                    cmd.Parameters.AddWithValue("@email", novaInfos.email);
                    cmd.Parameters.AddWithValue("@senha", novaInfos.senha);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public usuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string querySelect = "SELECT * FROM Usuarios WHERE idUsuario = @ID";
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        usuarioDomain usuarioBuscado = new usuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            permissao = Convert.ToInt32(rdr["idTipoUsuario"]),
                            email = rdr["Email"].ToString(),
                            senha = rdr["Senha"].ToString()

                        };
                        return (usuarioBuscado);
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(usuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string queryInsert = "INSERT INTO Usuarios(idTipoUsuario,Email,Senha) VALUES (@idTipoUsuario,@Email,@Senha)";

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@idTipoUsuario", novoUsuario.permissao);
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.senha);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string queryDelete = "DELETE FROM Usuarios WHERE idUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<usuarioDomain> ListarTodos()
        {
            List<usuarioDomain> listaUsuarios = new List<usuarioDomain>();

            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string querySelect = "SELECT * FROM Usuarios";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect,con))
                {
                    con.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        usuarioDomain usuario = new usuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            permissao = Convert.ToInt32(rdr["idTipoUsuario"]),
                            email = rdr["Email"].ToString(),
                            senha = rdr["senha"].ToString()

                        };
                        listaUsuarios.Add(usuario);
                    }
                        return listaUsuarios;
                }
            }
        }

        public usuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {

                string querySelect = "SELECT idUsuario, idTipoUsuario, Email, Senha FROM Usuarios WHERE Email = @email AND Senha = @senha";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect,con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        usuarioDomain usuario = new usuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            permissao = Convert.ToInt32(rdr["idTipoUsuario"]),
                            email = rdr["Email"].ToString(),
                            senha = rdr["Senha"].ToString()
                        };
                        return usuario;
                    }
                    return null;
                }
            }
        }
    }
}
