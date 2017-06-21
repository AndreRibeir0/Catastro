using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ValidatorUsuarioBLL
    {
        
        /// <summary>
        /// Método que valida se o usuario logado é do tipo administrador
        /// </summary>
        /// <param name="usuario"></param>Usuario que deve ser do tipo administrador
        public void ValidarUsuarioLogado(UsuarioDTO usuario)
        {
            if (usuario.Tipo != 1)
            {
                throw new Exception("Apenas Usuario do tipo Administradores podem Cadastrar/Editar/Excluir usuarios");
            }
        }

        /// <summary>
        /// Método que valida o usuario a ser cadastrado.
        /// </summary>
        /// <param name="usuario"></param>Novo usuario a ser cadastrado por um usuario administrador.
        public void ValidarUsuarioACadastrar(UsuarioDTO usuario)
        {
            StringBuilder builder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                builder.AppendLine("Nome deve ser informado.");
            }
            else if (usuario.Nome.Length < 5 || usuario.Nome.Length > 100)
            {
                builder.AppendLine("Nome deve conter entre 3 e 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                builder.AppendLine("A senha deve ser informado.");
            }
            else if (usuario.Nome.Length < 5 || usuario.Nome.Length > 10)
            {
                builder.AppendLine("A deve conter entre 5 e 10 caracteres.");
            }
            else if (usuario.Senha.Contains(" "))
            {
                builder.AppendLine("A senha não pode conter espaços.");
            }

            if (usuario.Tipo != 1 && usuario.Tipo != 2)
            {
                builder.AppendLine("O usuario deve ser do tipo Administrador ou do tipo Usuario.");
            }

                //Lança uma exceção caso o StringBuilder esteja preenchido
                //com algum erro
                if (builder.Length > 0)
            {
                throw new Exception(builder.ToString());
            }
        }

        /// <summary>
        /// Método de validação para editar um usuário.
        /// </summary>
        /// <param name="usuarioLogado"></param>Usuario que deve ser do tipo administrador.
        /// <param name="usuarioAEditar"></param>Usuario que deve ser editado.
        public void ValidarUsuarioAEditar(UsuarioDTO usuarioLogado, UsuarioDTO usuarioAEditar)
        {
            ValidarUsuarioLogado(usuarioLogado);

            StringBuilder builder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(usuarioAEditar.Nome))
            {
                builder.AppendLine("Nome deve ser informado.");
            }
            else if (usuarioAEditar.Nome.Length < 5 || usuarioAEditar.Nome.Length > 100)
            {
                builder.AppendLine("Nome deve conter entre 3 e 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(usuarioAEditar.Senha))
            {
                builder.AppendLine("A senha deve ser informado.");
            }
            else if (usuarioAEditar.Nome.Length < 5 || usuarioAEditar.Nome.Length > 10)
            {
                builder.AppendLine("A senha deve conter entre 5 e 10 caracteres.");
            }
            else if (usuarioAEditar.Senha.Contains(" "))
            {
                builder.AppendLine("A senha não pode conter espaços.");
            }

            if (usuarioAEditar.ID == 0)
            {
                builder.AppendLine("Para editar primeiro selecione um usuario cadastrado");
            }

            //Lança uma exceção caso o StringBuilder esteja preenchido
            //com algum erro
            if (builder.Length > 0)
            {
                throw new Exception(builder.ToString());
            }        

        }

    }
}
