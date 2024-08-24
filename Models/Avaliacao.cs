using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IfroAlimenta.Models
{
    [Table("avaliacao")]
    public class Avaliacao
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("nota")]
        public byte Nota { get; set; }

        [Column("produto_id")]  
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
    }
}
