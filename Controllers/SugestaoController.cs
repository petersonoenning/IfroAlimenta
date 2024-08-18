using IfroAlimenta.Contexto;
using IfroAlimenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IfroAlimenta.Controllers
{
    public class SugestaoController : Controller
    {
        private readonly ContextoBD _context;

        public SugestaoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Sugestao>> ListaSugestoes()
        {
            return await _context.Sugestoes.ToListAsync();
        }

        public async Task Add(Sugestao sugestao)
        {
            await _context.Sugestoes.AddAsync(sugestao);
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
