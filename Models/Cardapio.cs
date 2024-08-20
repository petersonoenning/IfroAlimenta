using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace IfroAlimenta.Models
{
    [Table("cardapio")]
    public class Cardapio
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        public ICollection<Opcao_Cardapio>? Opcoes { get; set; }
    }
}
