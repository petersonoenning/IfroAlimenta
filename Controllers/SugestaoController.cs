using IfroAlimenta.Components.Pages;
using IfroAlimenta.Contexto;
using IfroAlimenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IActionResult> Add(Sugestao sugestao)
    {
        _context.Sugestoes.Add(sugestao);
        await _context.SaveChangesAsync();
        return Ok();
    }

    public async Task<IActionResult> Salvar()
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
