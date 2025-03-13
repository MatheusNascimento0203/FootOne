using FeatureJuan.Data;
using FeatureJuan.Models;
using Microsoft.EntityFrameworkCore;

namespace FeatureJuan.Repository
{
    public class TimeRepository
    {
        private readonly AppDbContext _context;

        public TimeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipe>> GetTimes()
        {
            return await _context.Equipes
                .Select(e => new Equipe
                {
                    EquipeId = e.EquipeId,
                    Nome = e.Nome,
                    QuantidadeIntegrantes = e.QuantidadeIntegrantes,
                    Divisao = new Divisao
                    {
                        DivisaoId = e.Divisao.DivisaoId,
                        Nome = e.Divisao.Nome
                    }
                })
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public async Task CreateTime(Equipe equipe)
        {
            await _context.Equipes.AddAsync(equipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTime(int id)
        {
            var equipe = await _context.Equipes.FindAsync(id);
            _context.Equipes.Remove(equipe);
            await _context.SaveChangesAsync();
        }
    }
}