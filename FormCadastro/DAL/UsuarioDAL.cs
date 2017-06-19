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
        public void Cadastrar(UsuarioDTO cliente)
        {
            //Framework - *ADO.NET* / NHibernate / Entity Framework
            //Responsável por realizar uma conexão física com o banco
            //de dados
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Home\Documents\USUARIO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "INSERT INTO USUARIO (NOME,CPF,EMAIL,DATANASCIMENTO,ATIVO) VALUES (@NOME,@CPF,@EMAIL,@DATANASCIMENTO,@ATIVO)";
                command.Parameters.AddWithValue("@NOME", cliente.Nome);
                command.Parameters.AddWithValue("@CPF", cliente.CPF);
                command.Parameters.AddWithValue("@EMAIL", cliente.Email);
                command.Parameters.AddWithValue("@DATANASCIMENTO", cliente.DataNascimento);
                command.Parameters.AddWithValue("@ATIVO", cliente.Ativo);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }

        public void Editar(UsuarioDTO cliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Home\Documents\USUARIO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "UPDATE USUARIO SET NOME = @NOME, EMAIL = @EMAIL WHERE ID = @ID";
                command.Parameters.AddWithValue("@NOME", cliente.Nome);
                command.Parameters.AddWithValue("@EMAIL", cliente.Email);
                command.Parameters.AddWithValue("@ID", cliente.ID);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Excluir(int idCliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Home\Documents\USUARIO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "DELETE FROM USUARIO WHERE ID = @ID";
                //Informa o valor do parâmetro @ID, neste caso, o ID do cliente
                //que queremos excluir.
                command.Parameters.AddWithValue("@ID", idCliente);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }


        public List<UsuarioDTO> LerTodos()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Home\Documents\USUARIO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "SELECT * FROM USUARIO";
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<UsuarioDTO> clientes = new List<UsuarioDTO>();
                while (reader.Read())
                {
                    //Como o objeto reader["COLUNABANCO"] retorna um OBJECT
                    //é papel do programador fazer uma conversão para
                    //o tipo especifico da classe
                    UsuarioDTO cliente = new UsuarioDTO();
                    cliente.ID = Convert.ToInt32(reader["ID"]);
                    cliente.Nome = Convert.ToString(reader["NOME"]);
                    cliente.CPF = (string)reader["CPF"];
                    cliente.Email = (string)reader["EMAIL"];
                    cliente.DataNascimento = (DateTime)reader["DATANASCIMENTO"];
                    cliente.Ativo = (bool)reader["ATIVO"];
                    clientes.Add(cliente);
                }
                return clientes;
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }

        public UsuarioDTO LerUsuario(int idCliente)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Home\Documents\USUARIO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "SELECT * FROM USUARIO";
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<UsuarioDTO> clientes = new List<UsuarioDTO>();
                while (reader.Read())
                {
                    //Como o objeto reader["COLUNABANCO"] retorna um OBJECT
                    //é papel do programador fazer uma conversão para
                    //o tipo especifico da classe
                    UsuarioDTO cliente = new UsuarioDTO();
                    cliente.ID = Convert.ToInt32(reader["ID"]);
                    cliente.Nome = Convert.ToString(reader["NOME"]);
                    cliente.CPF = (string)reader["CPF"];
                    cliente.Email = (string)reader["EMAIL"];
                    cliente.DataNascimento = (DateTime)reader["DATANASCIMENTO"];
                    cliente.Ativo = (bool)reader["ATIVO"];
                    clientes.Add(cliente);

                    if (idCliente == cliente.ID)
                    {
                        return cliente;
                    }
                }
                UsuarioDTO clienteVazio = new UsuarioDTO();
                return clienteVazio;
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }
    }
}
