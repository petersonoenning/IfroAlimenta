using IfroAlimenta.Models;
using Microsoft.EntityFrameworkCore;

namespace IfroAlimenta.Contexto
{
    public class ContextoBD : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<Opcao_Cardapio> Opcoes_Cardapios { get; set; } // Certifique-se de que o nome está correto
        public DbSet<Sugestao> Sugestoes { get; set; }

        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
        {
        }
    }
}
