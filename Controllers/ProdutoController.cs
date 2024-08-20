using IfroAlimenta.Contexto;
using IfroAlimenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IfroAlimenta.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ContextoBD _context;

        public ProdutoController(ContextoBD context)
        {
            _context = context;
        }

        // Método para listar todos os produtos
        public async Task<List<Produto>> ListaProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // Método para adicionar um novo produto
        public async Task Add(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        // Método para salvar alterações
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
