using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Cadastrar(UsuarioDTO usuario)
        {
            //Framework - *ADO.NET* / NHibernate / Entity Framework
            //Responsável por realizar uma conexão física com o banco
            //de dados
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString = DbConfig.ConnectionString;
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "INSERT INTO USUARIO (NOME, SENHA, TIPO) VALUES (@(NOME, @SENHA, @TIPO)";
                command.Parameters.AddWithValue("@NOME", usuario.Nome);
                command.Parameters.AddWithValue("@SENHA", usuario.Senha);
                command.Parameters.AddWithValue("@TIPO", usuario.Tipo);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }

        public void Editar(UsuarioDTO usuario)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString = DbConfig.ConnectionString;

                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "UPDATE USUARIO SET SENHA = @SENHA, TIPO = @TIPO WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", usuario.ID );
                command.Parameters.AddWithValue("@SENHA", usuario.Senha);
                command.Parameters.AddWithValue("@TIPO", usuario.Tipo);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Excluir(int idUsuario)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString = DbConfig.ConnectionString;
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "DELETE FROM USUARIO WHERE ID = @ID";
                //Informa o valor do parâmetro @ID, neste caso, o ID do usuario
                //que queremos excluir.
                command.Parameters.AddWithValue("@ID", idUsuario);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }

        public UsuarioDTO LerUsuario(int ID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString = DbConfig.ConnectionString;
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "SELECT * FROM USUARIO WHERE NOME = @ID";
                command.Parameters.AddWithValue("ID", ID);
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                UsuarioDTO usuario = new UsuarioDTO();
                //Como o objeto reader["COLUNABANCO"] retorna um OBJECT
                //aqui é feito a conversão para
                //o tipo especifico da classe
                if (reader.Read())
                {
                    usuario.SetID(Convert.ToInt32(reader["ID"]));
                    usuario.SetNome(Convert.ToString(reader["NOME"]));
                    usuario.SetSenha(Convert.ToString(reader["SENHA"]));
                    usuario.SetTipo(Convert.ToInt32(reader["TIPO"]));
                    return usuario;
                }          
                return usuario;            
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }
    }
}
