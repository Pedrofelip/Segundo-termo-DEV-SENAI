using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class funcionarioRepository : IfuncionarioRepository
    {
        private string conexaoSql = "Data Source = DESKTOP-79ATS9L\\SQLEXPRESS; initial catalog = M_Peoples; user id = sa; pwd = PsBF0203";

        public void Atualizar(funcionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string queryAtualizar = "UPDATE Funcionarios SET nome = @nome, sobrenome = @sobrenome WHERE idFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", funcionario.sobrenome);
                    cmd.Parameters.AddWithValue("ID", funcionario.idFuncionario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarPelaUrl(int id, funcionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {

                string queryAtualizar = "UPDATE Funcionarios SET nome = @nome, sobrenome = @sobrenome WHERE idFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryAtualizar,con))
                {
                        cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                        cmd.Parameters.AddWithValue("@sobrenome", funcionario.sobrenome);
                        cmd.Parameters.AddWithValue("@ID", id);

                        con.Open();

                        cmd.ExecuteNonQuery();

                }
            }

        }

        public funcionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string queryBuscar = "SELECT idFuncionario, nome, sobrenome FROM funcionarios WHERE idFuncionario = @ID";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscar,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        funcionarioDomain funcionario = new funcionarioDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),
                            nome = rdr["nome"].ToString(),
                            sobrenome = rdr["sobrenome"].ToString()
                        };
                        return funcionario;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(funcionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string queryCadastro = "INSERT INTO Funcionarios (nome, sobrenome) VALUES (@nome, @sobrenome)";

                using (SqlCommand cmd = new SqlCommand(queryCadastro,con))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", funcionario.sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string queryDeletar = "DELETE FROM Funcionarios WHERE idFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDeletar,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();            
                }
            }
        }

        public List<funcionarioDomain> ListaTodos()
        {
            List<funcionarioDomain> ListaFuncionarios = new List<funcionarioDomain>();

            using (SqlConnection con = new SqlConnection(conexaoSql))
            {
                string queryListar = "SELECT idFuncionario, nome, sobrenome FROM Funcionarios";

                SqlDataReader rdr;

                con.Open();


                using (SqlCommand cmd = new SqlCommand(queryListar,con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        funcionarioDomain funcionario = new funcionarioDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),
                            nome = rdr["nome"].ToString(),
                            sobrenome = rdr["sobrenome"].ToString()
                        };
                        ListaFuncionarios.Add(funcionario);
                    }
                    return ListaFuncionarios;
                }
            }
        }
    }
}
