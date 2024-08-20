using IfroAlimenta.Contexto;
using IfroAlimenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IfroAlimenta.Controllers
{
    public class NotaController : Controller
    {
        private readonly ContextoBD _context;

        public NotaController(ContextoBD context)
        {
            _context = context;
        }

        // Método para atualizar a nota de um produto
        [HttpPost]
        public async Task<bool> AtribuirNota(int id, byte nota)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                produto.Nota = nota;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
