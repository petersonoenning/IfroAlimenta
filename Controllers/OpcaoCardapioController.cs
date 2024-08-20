using IfroAlimenta.Contexto;
using IfroAlimenta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IfroAlimenta.Controllers
{
    public class OpcaoCardapioController : Controller
    {
        private readonly ContextoBD _context;

        public OpcaoCardapioController(ContextoBD context)
        {
            _context = context;
        }

        // Método para listar todas as opções de cardápio
        public async Task<List<Opcao_Cardapio>> ListaOpcoesCardapio()
        {
            return await _context.Opcoes_Cardapios.Include(o => o.Produto).Include(o => o.Cardapio).ToListAsync();
        }

        // Método para adicionar uma nova opção de cardápio
        public async Task Add(Opcao_Cardapio opcaoCardapio)
        {
            await _context.Opcoes_Cardapios.AddAsync(opcaoCardapio);
        }

        // Método para salvar as alterações no banco de dados
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
