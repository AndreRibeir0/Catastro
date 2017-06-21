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
        public bool ValidarLogin(UsuarioDTO usuario)
        {
            UsuarioDTO usuarioAux = new UsuarioDTO();
            try
            {
                usuarioAux = new UsuarioDAL().LerUsuario(usuario.ID);
                if (usuario.Senha == usuarioAux.Senha && usuario.Nome == usuarioAux.Nome)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw new Exception("Usuário não cadastrado.");
            }
        }

        public void SetUsuarioLogado()
        {

        }

        public void CadastrarUsuario(UsuarioDTO usuarioLogado, UsuarioDTO usuarioACadastrar)
        {
            new ValidatorUsuarioBLL().ValidarUsuarioLogado(usuarioLogado);
            new ValidatorUsuarioBLL().ValidarUsuarioACadastrar(usuarioACadastrar);

            UsuarioDAL dal = new UsuarioDAL();
            try
            {
                dal.Cadastrar(usuarioACadastrar);
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados durante o Cadastro. Contate o adm.");
            }
        }

        public void EditarUsuario(UsuarioDTO usuarioLogado, UsuarioDTO usuarioAEditar)
        {
            new ValidatorUsuarioBLL().ValidarUsuarioAEditar(usuarioLogado,usuarioAEditar);
            try
            {
                UsuarioDTO usuario = new UsuarioDTO();
                usuario = new UsuarioDAL().LerUsuario(usuarioAEditar.ID);
            }
            catch (Exception)
            {

                throw new Exception("Para editar é necessario selecionar um usuário antes.");
            }

            UsuarioDAL dal = new UsuarioDAL();
            try
            {
                dal.Editar(usuarioAEditar);
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados durante a edição. Contate o adm.");
            }
        }

        public void ExcluirUsuario(UsuarioDTO usuarioLogado, UsuarioDTO usuarioAExcluir)
        {
            try
            {
                UsuarioDTO usuario = new UsuarioDTO();
                usuario = new UsuarioDAL().LerUsuario(usuarioAExcluir.ID);
            }
            catch (Exception)
            {

                throw new Exception("Para excluir é necessario selecionar um usuário antes.");
            }
            
            UsuarioDAL dal = new UsuarioDAL();
            try
            {
                dal.Excluir(usuarioAExcluir.ID);
            }
            catch (Exception ex)
            {
                //Loga o erro para o administrador
                File.AppendAllText("log.txt", ex.Message + "\r\n" + ex.StackTrace);
                //Relança a exceção e a captura na interface gráfica
                throw new Exception("Erro no banco de dados durante a exclusão. Contate o adm.");
            }
        }
    }
}
