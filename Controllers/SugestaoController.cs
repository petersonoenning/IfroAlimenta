using IfroAlimenta.Contexto; // Certifique-se de que o namespace para o seu contexto de banco de dados está correto
using IfroAlimenta.Models;
using Microsoft.EntityFrameworkCore;

namespace IfroAlimenta.Controllers
{
    public class SugestaoController
    {
        private readonly ContextoBD _contexto;

        public SugestaoController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        // Adicionar uma nova sugestão
        public async Task Add(Sugestao sugestao)
        {
            if (sugestao != null)
            {
                _contexto.Sugestoes.Add(sugestao);
                await _contexto.SaveChangesAsync();
            }
        }

        // Salvar alterações no banco de dados
        public async Task Salvar()
        {
            await _contexto.SaveChangesAsync();
        }

        // Obter todas as sugestões
        public async Task<List<Sugestao>> GetAll()
        {
            return await _contexto.Sugestoes.ToListAsync();
        }

        // Obter uma sugestão por ID
        public async Task<Sugestao?> GetById(int id)
        {
            return await _contexto.Sugestoes.FindAsync(id);
        }

        // Atualizar uma sugestão existente
        public async Task Update(Sugestao sugestao)
        {
            _contexto.Sugestoes.Update(sugestao);
            await _contexto.SaveChangesAsync();
        }

        // Deletar uma sugestão
        public async Task Delete(int id)
        {
            var sugestao = await GetById(id);
            if (sugestao != null)
            {
                _contexto.Sugestoes.Remove(sugestao);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
