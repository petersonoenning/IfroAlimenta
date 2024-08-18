using System.ComponentModel.DataAnnotations.Schema;

namespace IfroAlimenta.Models
{
    [Table("cardapio")]
    public class Cardapio
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("data")]
        public DateTime Data { get; set; }

        public List<Produto> Produtos { get; set; } //Chamar a lista para o Controller
    }
}
