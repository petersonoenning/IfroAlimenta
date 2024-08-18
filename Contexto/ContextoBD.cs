using Microsoft.EntityFrameworkCore;
using IfroAlimenta.Models;

namespace IfroAlimenta.Contexto
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Sugestao> Sugestoes { get; set; }
        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<Opcao_Cardapio> Opcoes_Cardapios { get; set; }

    }
}
