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

        public List<CategoriaDTO> LerTodasCategorias()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Home\Documents\PRODUTO.mdf;Integrated Security=True;Connect Timeout=30";
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
