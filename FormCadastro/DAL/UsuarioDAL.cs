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
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cadastro;Integrated Security=True";
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

    }
}
