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

        public async Task<List<Produto>> ListaProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task Add(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

     
    }
}
