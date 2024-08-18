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

        [ForeignKey("IdProduto")] //Informa qual o atributo da classe vai armazenar a FK
        public Produto? Produto { get; set; } //Indica o dono da propiedade

        [Column("cardapio_id")]
        public int IdCardapio { get; set; }

        [ForeignKey("IdCardapio")] //Informa qual o atributo da classe vai armazenar a FK
        public Cardapio? Cardapio { get; set; } //Indica o dono da propiedade
    }
}
