using BLL;
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
    public class UsuarioBLL
    {
        /// <summary>
        /// Método que verifica propriedade por propriedade do objeto cliente
        /// e lança uma exceção com a somatória de erros do objeto.
        /// Caso nenhuma exceção seja lançada, o método não faz nada.
        /// </summary>
        /// <param name="cliente">Objeto que possui os dados do cliente a ser validado
        /// </param>
        public void ValidarCliente(UsuarioDTO cliente)
        {
            new ValidatorUsuarioBLL().ValidatorUsuario(cliente);

            //Remove a máscara
            cliente.CPF = cliente.CPF.Replace("-", "").Replace(".", "");
            cliente.Ativo = true;          
            

        }

        public void CadastrarCliente(UsuarioDTO cliente)
        {
            ValidarCliente(cliente);
            //Se chegou aqui, o cliente está validado e nenhuma exceção
            //foi lançada. Podemos cadastrá-lo no banco de dados.
            UsuarioDAL dal = new UsuarioDAL();
            try
            {
                dal.Cadastrar(cliente);
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados durante o Cadastro. Contate o adm.");
            }

        }

        public void EditarCliente(UsuarioDTO cliente)
        {
            if (cliente.ID == 0)
            {
                throw new Exception("Para editar primeiro selecione um usuario cadastrado");
            }

            ValidarCliente(cliente);
            UsuarioDAL dal = new UsuarioDAL();
            try
            {
                dal.Editar(cliente);
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados durante a edição. Contate o adm.");
            }
        }

        public void ExcluirCliente(int id)
        {
            if (id == 0)
            {
                throw new Exception("Para excluir é necessario selecionar um usuário antes.");
            }
            UsuarioDAL dal = new UsuarioDAL();
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

        public List<UsuarioDTO> LerTodos()
        {
            UsuarioDAL dal = new UsuarioDAL();
            List<UsuarioDTO> clientes = dal.LerTodos();
            for (int i = 0; i < clientes.Count; i++)
            {
                //Inserirmos de volta a máscara do CPF para cada cliente.
                clientes[i].CPF =
                    clientes[i].CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");
            }
            return clientes;
        }

        public UsuarioDTO LerUsuario(int id)
        {
                       
            try
            {
                UsuarioDAL dal = new UsuarioDAL();
                UsuarioDTO cliente = dal.LerUsuario(id);
                return cliente;
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados durante a pesquisa. Contate o adm.");
            }           
        }
    }
}
