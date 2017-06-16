using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProdutoBLL
    {
        public void ValidarProduto(ProdutoDTO produto)
        {
            new ValidatorProdutoBLL().ValidatorProduto(produto);

            //Remove a máscara
            if (produto.ID == 0)
            {
               produto.Ativo = true;
            }         

            
        }

        public void CadastrarProduto(ProdutoDTO produto)
        {

            ValidarProduto(produto);
            //Se chegou aqui, o cliente está validado e nenhuma exceção
            //foi lançada. Podemos cadastrá-lo no banco de dados.
            ProdutoDAL dal = new ProdutoDAL();
            try
            {
                dal.Cadastrar(produto);
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados durante o Cadastro. Contate o adm.");
            }

        }

        public void EditarProduto(ProdutoDTO produto)
        {
            if (produto.ID == 0)
            {
                throw new Exception("Para editar primeiro selecione um produto cadastrado");
            }

            ValidarProduto(produto);
            ProdutoDAL dal = new ProdutoDAL();
            try
            {
                dal.Editar(produto);
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados durante a edição. Contate o adm.");
            }
        }

        public void ExcluirProduto(int id)
        {
            if (id == 0)
            {
                throw new Exception("Para excluir é necessario selecionar um produto antes.");
            }
            ProdutoDAL dal = new ProdutoDAL();
            try
            {
                dal.Excluir(id);
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados durante a exclusão. Contate o adm.");
            }
        }

        public List<ProdutoDTO> LerTodos()
        {
            ProdutoDAL dal = new ProdutoDAL();
            List<ProdutoDTO> produtos = dal.LerTodos();
            return produtos;
        }
    }
}
