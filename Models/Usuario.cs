using System.ComponentModel.DataAnnotations.Schema;

namespace IfroAlimenta.Models
{
	[Table("usuario")]
	public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string? Nome { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        [Column("senha")]
        public string? Senha { get; set; }
        [Column("cargo")]
        public string? Cargo { get; set; }
    }
}
