using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProdutoDTO
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; } 
        public EnumProdutoDTO UnidadeMedida { get; set; }
        public double QtdEstoque { get; set; }
        public double QtdEstoqueMinimo { get; set; }
        public int Categoria { get; set;}
        public bool Ativo { get; set; }

    }
}
