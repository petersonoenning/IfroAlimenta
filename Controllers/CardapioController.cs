using IfroAlimenta.Contexto;
using IfroAlimenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IfroAlimenta.Controllers
{
    public class CardapioController : Controller
    {
        private readonly ContextoBD _context;

        public CardapioController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Cardapio>> ListarCardapios()
        {
            return await _context.Cardapios.Include(c => c.Opcoes).ToListAsync();
        }

        public async Task<bool> AdicionarCardapio(Cardapio cardapio, List<int> produtosIds)
        {
            _context.Cardapios.Add(cardapio);
            await _context.SaveChangesAsync();

            foreach (var produtoId in produtosIds)
            {
                var opcaoCardapio = new Opcao_Cardapio
                {
                    IdCardapio = cardapio.Id,
                    IdProduto = produtoId
                };
                _context.Opcoes_Cardapios.Add(opcaoCardapio);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
