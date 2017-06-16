using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProdutoDAL
    {
        public void Cadastrar(ProdutoDTO produto)
        {
            //Framework - *ADO.NET* / NHibernate / Entity Framework
            //Responsável por realizar uma conexão física com o banco
            //de dados
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString =
                    @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\moc\Documents\PRODUTO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "INSERT INTO PRODUTO (DESCRICAO,PRECO,UNIDADEMEDIDA,QTDESTOQUE,QTDESTOQUEMINIMO,CATEGORIA,ATIVO) VALUES (@DESCRICAO,@PRECO,@UNIDADEMEDIDA,@QTDESTOQUE,@QTDESTOQUEMINIMO,@CATEGORIA,@ATIVO)";
                command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
                command.Parameters.AddWithValue("@PRECO", produto.Preco);
                command.Parameters.AddWithValue("@UNIDADEMEDIDA", produto.UnidadeMedida);
                command.Parameters.AddWithValue("@QTDESTOQUE", produto.QtdEstoque);
                command.Parameters.AddWithValue("@QTDESTOQUEMINIMO", produto.QtdEstoqueMinimo);
                command.Parameters.AddWithValue("@CATEGORIA", produto.Categoria);
                command.Parameters.AddWithValue("@ATIVO", produto.Ativo);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }

        public void Editar(ProdutoDTO produto)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString =
                    @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\moc\Documents\PRODUTO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "UPDATE PRODUTO SET DESCRICAO = @DESCRICAO, PRECO = @PRECO, UNIDADEMEDIDA = @UNIDADEMEDIDA, QTDESTOQUE = @QTDESTOQUE, QTDESTOQUEMINIMO = @QTDESTOQUEMINIMO, CATEGORIA = @CATEGORIA, ATIVO = @ATIVO WHERE ID = @ID";
                command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
                command.Parameters.AddWithValue("@PRECO", produto.Preco);
                command.Parameters.AddWithValue("@UNIDADEMEDIDA", produto.UnidadeMedida);
                command.Parameters.AddWithValue("@QTDESTOQUE", produto.QtdEstoque);
                command.Parameters.AddWithValue("@QTDESTOQUEMINIMO", produto.QtdEstoqueMinimo);
                command.Parameters.AddWithValue("@CATEGORIA", produto.Categoria);
                command.Parameters.AddWithValue("@ATIVO", produto.Ativo);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Excluir(int idProduto)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString =
                    @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\moc\Documents\PRODUTO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "DELETE FROM PRODUTO WHERE ID = @ID";
                //Informa o valor do parâmetro @ID, neste caso, o ID do cliente
                //que queremos excluir.
                command.Parameters.AddWithValue("@ID", idProduto);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        }


        public List<ProdutoDTO> LerTodos()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                //string de conexão
                connection.ConnectionString =
                    @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\moc\Documents\PRODUTO.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand command = new SqlCommand();
                command.CommandText =
                    "SELECT * FROM PRODUTO";
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<ProdutoDTO> produtos = new List<ProdutoDTO>();
                while (reader.Read())
                {
                    //Como o objeto reader["COLUNABANCO"] retorna um OBJECT
                    //é papel do programador fazer uma conversão para
                    //o tipo especifico da classe
                    ProdutoDTO produto = new ProdutoDTO();
                    produto.ID = Convert.ToInt32(reader["ID"]);
                    produto.Descricao = Convert.ToString(reader["NOME"]);
                    produto.UnidadeMedida = (int)reader["UNIDADEMEDIDA"];
                    produto.QtdEstoque = (double)reader["EMAIL"];
                    produto.QtdEstoqueMinimo = (double)reader["DATANASCIMENTO"];
                    produto.Categoria = (string)reader["CATEGORIA"];
                    produto.Ativo = (bool)reader["ATIVO"];
                    produtos.Add(produto);
                }
                return produtos;
            }//Fim da cláusula USING, o método Dispose da conexão será chamado.
        } 
    }
}
    

