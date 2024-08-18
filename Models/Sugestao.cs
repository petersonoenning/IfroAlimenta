using System.ComponentModel.DataAnnotations.Schema;

namespace IfroAlimenta.Models
{
	[Table("sugestao")]
	public class Sugestao
	{
        [Column("id")]
        public int Id { get; set; }
        [Column("descricao")]
        public string? Descricao { get; set; }
        [Column("data")]
        public DateTime Data { get; set; }
    }
}
