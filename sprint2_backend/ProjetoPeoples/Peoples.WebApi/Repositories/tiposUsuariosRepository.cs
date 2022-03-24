using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class tiposUsuariosRepository : ItipoUsuarioRepository
    {
        private string conexaoSql = "Data Source = DESKTOP-79ATS9L\\SQLEXPRESS; initial catalog = M_Peoples; user id = sa; pwd = PsBF0203";
        public void Atualizar(tipoUsuarioDomain novainfos)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string queryUpdate = "UPDATE TiposUsuarios SET tipo = @permissao";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@permissao",novainfos.permissao);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public tipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string querySelect = "SELECT idTipoUsuario, tipo FROM TiposUsuarios WHERE idTipoUsuario = @ID";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        tipoUsuarioDomain tipoUsuario = new tipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            permissao = rdr["tipo"].ToString()
                        };
                        return tipoUsuario;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string queryDelete = "DELETE FROM TiposUsuarios WHERE idTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<tipoUsuarioDomain> ListarTodos()
        {
            List<tipoUsuarioDomain> listaTiposUsuarios = new List<tipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(conexaoSql))
            {

                string querySelect = "SELECT idTipoUsuario, tipo FROM TiposUsuarios";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect,con))
                {
                    con.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        tipoUsuarioDomain tipo = new tipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            permissao = rdr["tipo"].ToString()
                        };
                        listaTiposUsuarios.Add(tipo);
                    }
                    return listaTiposUsuarios;
                }

            }
        }
    }
}
