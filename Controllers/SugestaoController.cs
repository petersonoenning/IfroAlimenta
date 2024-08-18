using IfroAlimenta.Contexto;
using IfroAlimenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace IfroAlimenta.Controllers
{
    public class SugestaoController: Controller
    {
        private readonly ContextoBD _context;

        public SugestaoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Sugestao>> ListaSugestoes()
        {
            var sugestoes = await _context.Sugestoes.Include(x => x.Sugestoes).ToListAsync();
            return sugestoes;
        }

        public async Task<ActionResult> Add(Sugestao sugestao)
        {
            _context.Sugestoes.Add(sugestao);
            await _context.SaveChangesAsync();
            return Ok(sugestao);
        }

        public async Task<ActionResult> Salvar()
        {
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500);
            }
        }
    }
}
