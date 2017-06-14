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
        /// e lança uma exceção de erros do objeto.
        /// Caso nenhuma exceção seja lançada, o método não faz nada.
        /// </summary>
        /// <param name="UsuarioDTO">Objeto que possui os dados do cliente a ser validado
        /// </param>
        public void ValidarCasatroCliente(UsuarioDTO cliente)
        {
            StringBuilder builder = new ValidatorUsuarioBLL().ValidatorUsuario(cliente);

            try
            {
                StringBuilder Builder = ValidarCliente(cliente);
            }
            catch (Exception)
            {
                throw new Exception(builder.ToString());
            }
                

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
                throw new Exception("Erro no banco de dados. Contate o adm.");
            }
        }

        /// <summary>
        /// Método que retorna um tipo UsuarioDTO carregado com os dados do banco
        /// </summary>
        /// <param name="UsuarioDTO"></param>
        /// <returns></returns>
        public UsuarioDTO ValidarPesquisaCliente(UsuarioDTO cliente)
        {
            //StringBuilder builder = new ValidatorUsuarioBLL().ValidatorUsuario(cliente);

            //try
            //{
                //StringBuilder Builder = ValidarCliente(cliente);
               
            //}
            //catch (Exception)
            //{

                //throw new Exception(builder.ToString());
            //}

            UsuarioDAL pes = new UsuarioDAL();
            try
            {

                UsuarioDTO usuario = pes.Pequisar(cliente);
                return usuario;
                    
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados. Contate o adm.");
            }
        }

        public StringBuilder ValidarCliente(UsuarioDTO cliente)
        {
            StringBuilder builder = new ValidatorUsuarioBLL().ValidatorUsuario(cliente);

            //Remove a máscara
            cliente.CPF = cliente.CPF.Replace("-", "").Replace(".", "");
            cliente.Ativo = true;

            //Lança uma exceção caso o StringBuilder esteja preenchido
            //com algum erro
            if (builder.Length > 0)
            {
                throw new Exception(builder.ToString());
            }

            return builder;

        }

        public List<UsuarioDTO> LerTodos()
        {
            UsuarioDAL dal = new UsuarioDAL();
            List<UsuarioDTO> clientes = dal.LerTodos();
            for (int i = 0; i < clientes.Count; i++)
            {
                clientes[i].CPF = clientes[i].CPF.Insert(3, ".").Insert(7, ".").Insert(11, "-");

            }
            return clientes;
        }

        public void ExcluirCliente(int id)
        {
            UsuarioDAL dal = new UsuarioDAL();
            dal.Excluir(id);
        }
    }
}
