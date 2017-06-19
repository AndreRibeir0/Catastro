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
    public class CategoriaBLL
    {
        public void ValidarCategoria(CategoriaDTO categoria)
        {
            
            new ValidatorCategoriaBLL().ValidatorCategoria(categoria);     
                  
        }

        public void CadastrarCategoria(CategoriaDTO categoria)
        {
            ValidarCategoria(categoria);
            //Se chegou aqui, o cliente está validado e nenhuma exceção
            //foi lançada. Podemos cadastrá-lo no banco de dados.
            CategoriaDAL dal = new CategoriaDAL();
            try
            {
                dal.Cadastrar(categoria);
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados durante o Cadastro. Contate o adm.");
            }

         }

        public void EditarCategoria(CategoriaDTO categoria)
        {
            if (categoria.ID == 0)
            {
                throw new Exception("Para editar primeiro selecione um usuario cadastrado");
            }

            ValidarCategoria(categoria);
            CategoriaDAL dal = new CategoriaDAL();
            try
            {
                dal.Editar(categoria);
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados durante a edição. Contate o adm.");
            }
        }

        public void ExcluirCategoria(int id)
        {
            if (id == 0)
            {
                throw new Exception("Para excluir é necessario selecionar um usuário antes.");
            }
            CategoriaDAL dal = new CategoriaDAL();
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

        public List<CategoriaDTO> LerTodosCategorias()
        {
            CategoriaDAL dal = new CategoriaDAL();
            List<CategoriaDTO> categorias = dal.LerTodasCategorias();            
            return categorias;
        }

    }
}
