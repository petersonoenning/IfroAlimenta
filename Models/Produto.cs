using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IfroAlimenta.Models
{
	[Table("produto")]
	public class Produto
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string? Nome { get; set; }
        [Column("descricao")]
        public string? Descricao { get; set; }
        [Column("quantidade")]
        public string? Quantidade { get; set; }
        [Column("categoria")]
        public byte? Categoria { get; set; } //Byte foi usado para receber dados do tipo TINYINT (Verificar se está correto)
        [Column("tipo")]
        public byte? Tipo { get; set; }
        [Column("valor")]
        public decimal? Valor { get; set; }

        [NotMapped]
        public decimal? MediaNota { get; set; }

        [Column("anexo")]
        [StringLength(255)]
        public string? Anexo { get; set; }

    }
}
