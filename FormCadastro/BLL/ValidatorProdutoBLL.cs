using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class ValidatorProdutoBLL
    {

        public void ValidatorProduto(ProdutoDTO produto)
        {
            StringBuilder builder = new StringBuilder();

            if (String.IsNullOrWhiteSpace(produto.Descricao))
            {
               builder.AppendLine("Descrição deve ser informada."); 
            }

            if (produto.Preco < 0)
            {
                builder.AppendLine("O preço deve ser maior que ZERO.");
            }

            if (produto.QtdEstoque < 1)
            {
                builder.AppendLine("A Qtd. do estoque deve ser maior que a Qtd. do estoque mínimo.");
            }

            if (produto.QtdEstoqueMinimo <= produto.QtdEstoque)
	        {
                builder.AppendLine("A Qtd. do 'estoque mínimo' deve ser maior que a Qtd. do estoque.");
	        }

            if (String.IsNullOrWhiteSpace(produto.Categoria))
            {
                builder.AppendLine("A categoria deve ser informada");
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
