using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriaDAL
    {

        public void Cadastrar(CategoriaDTO categoria)
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
                    "INSERT INTO CATEGORIA (CATEGORIA) VALUES (@CATEGORIA)";                
                command.Parameters.AddWithValue("@CATEGORIA", categoria.Categoria);                
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }

        public void Editar(CategoriaDTO categoria)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString = DbConfig.ConnectionString;

                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "UPDATE CATEGORIA SET DESCRICAO = CATEGORIA = @CATEGORIA WHERE ID = @ID";
                command.Parameters.AddWithValue("ID", categoria.ID);                
                command.Parameters.AddWithValue("@IDCATEGORIA", categoria.Categoria);                
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Excluir(int idCategoria)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString = DbConfig.ConnectionString;
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "DELETE FROM CATEGORIA WHERE ID = @ID";
                //Informa o valor do parâmetro @ID, neste caso, o ID do cliente
                //que queremos excluir.
                command.Parameters.AddWithValue("@ID", idCategoria);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }

        public List<CategoriaDTO> LerTodasCategorias()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString = DbConfig.ConnectionString;                    
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "SELECT * FROM CATEGORIA";
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<CategoriaDTO> categorias = new List<CategoriaDTO>();
                while (reader.Read())
                {
                    //Como o objeto reader["COLUNABANCO"] retorna um OBJECT
                    //é papel do programador fazer uma conversão para
                    //o tipo especifico da classe
                    CategoriaDTO categoria = new CategoriaDTO();
                    categoria.ID = Convert.ToInt32(reader["ID"]);
                    categoria.Categoria = (string)reader["CATEGORIA"];
                    categorias.Add(categoria);
                }
                return categorias;
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }

    }
}
