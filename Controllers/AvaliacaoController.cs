using IfroAlimenta.Contexto;
using IfroAlimenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IfroAlimenta.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly ContextoBD _context;

        public AvaliacaoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Produto>> ListarProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task Add(Avaliacao avaliacao)
        {
            await _context.Avaliacoes.AddAsync(avaliacao);
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Avaliacao>> ListarAvaliacoesPorProduto(int produtoId)
        {
            return await _context.Avaliacoes
                                 .Where(a => a.ProdutoId == produtoId)
                                 .ToListAsync();
        }

        public async Task<decimal> CalcularMediaNotas(int produtoId)
        {
            var avaliacoes = await ListarAvaliacoesPorProduto(produtoId);
            if (avaliacoes.Count == 0) return 0;
            return (decimal)avaliacoes.Average(a => a.Nota);
        }

        public async Task<List<Produto>> ListarProdutosComMediaNotas()
        {
            var produtos = await _context.Produtos.ToListAsync();
            foreach (var produto in produtos)
            {
                produto.MediaNota = await CalcularMediaNotas(produto.Id);
            }
            return produtos.OrderByDescending(p => p.MediaNota).ToList();
        }
    }
}
