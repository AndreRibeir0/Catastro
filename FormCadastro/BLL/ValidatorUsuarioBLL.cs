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
        /// Método validator do Usuario que retorna um StringBuilder
        /// </summary>
        /// <param name="cliente">Objeto que possui os dados do usuario a ser validado
        /// <returns></returns>
        public StringBuilder ValidatorUsuario(UsuarioDTO cliente)
        {
            StringBuilder builder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(cliente.Nome))
            {
                builder.AppendLine("Nome deve ser informado.");
            }
            else if (cliente.Nome.Length < 5 || cliente.Nome.Length > 100)
            {
                builder.AppendLine("Nome deve conter entre 5 e 100 caracteres.");
            }
            if (string.IsNullOrWhiteSpace(cliente.Email))
            {
                builder.AppendLine("O email deve ser informado.");
            }
            else if (!cliente.Email.Contains("@") || !cliente.Email.Contains(".com"))
            {
                builder.AppendLine("Email inválido.");
            }
            if (!new CommonValidations().ValidarCpf(cliente.CPF))
            {
                builder.AppendLine("CPF inválido.");
            }
            if (DateTime.Now.Subtract(cliente.DataNascimento).TotalDays < 365 * 18 + 4)
            {
                builder.AppendLine("Apenas maior de idade.");
            }

            return builder;
        }
    }
}
