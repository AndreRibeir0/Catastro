﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    class ValidatorCategoriaBLL
    {
        public void ValidatorCategoria(CategoriaDTO categoria)
        {
            StringBuilder builder = new StringBuilder();

            if (String.IsNullOrWhiteSpace(categoria.Categoria))
            {
                builder.AppendLine("A categoria deve ser informada.");
            }
            else if (categoria.Categoria.Length > 50)
            {
                builder.AppendLine("A categoria deve conter no máximo 50 caracteres");
            }

            if (!Regex.IsMatch(categoria.Categoria, "^[a-zA-Z]"))
            {
                builder.AppendLine("Categoria não deve conter números");
            }
            

            //Lança uma exceção caso o StringBuilder esteja preenchido
            //com algum erro
            if (builder.Length > 50)
            {
                throw new Exception(builder.ToString());
            }
        }
    }
}
