using System.ComponentModel.DataAnnotations.Schema;

namespace IfroAlimenta.Models
{
    [Table("opcao_cardapio")]
    public class Opcao_Cardapio
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("produto_id")]
        public int IdProduto { get; set; }

        [ForeignKey("IdProduto")]
        public Produto? Produto { get; set; }

        [Column("cardapio_id")]
        public int IdCardapio { get; set; }

        [ForeignKey("IdCardapio")]
        public Cardapio? Cardapio { get; set; }
    }
}
