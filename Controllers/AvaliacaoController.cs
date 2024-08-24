using Microsoft.AspNetCore.Mvc;
using IfroAlimenta.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IfroAlimenta.Contexto;

namespace IfroAlimenta.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly ContextoBD _context;

        public AvaliacaoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Avaliacao>> ListarAvaliacoes()
        {
            return await _context.Avaliacoes.Include(a => a.Produto).ToListAsync();
        }

        public async Task Add(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        // Método para obter o ranking dos produtos por média de notas
        public async Task<List<(Produto Produto, double MediaNota, int QuantidadeAvaliacoes)>> RankingNotasProduto()
        {
            var produtos = await _context.Produtos.ToListAsync();
            var avaliacoes = await _context.Avaliacoes.ToListAsync();

            var ranking = produtos
                .Select(p => new
                {
                    Produto = p,
                    MediaNota = avaliacoes
                        .Where(a => a.ProdutoId == p.Id)
                        .Average(a => a.Nota),
                    QuantidadeAvaliacoes = avaliacoes.Count(a => a.ProdutoId == p.Id)
                })
                .OrderByDescending(r => r.MediaNota)
                .ToList();

            return ranking
                .Select(r => (r.Produto, r.MediaNota, r.QuantidadeAvaliacoes))
                .ToList();
        }
    }
}