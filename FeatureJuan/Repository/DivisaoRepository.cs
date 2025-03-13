
using FeatureJuan.Data;
using FeatureJuan.Models;
using Microsoft.EntityFrameworkCore;

namespace FeatureJuan.Repository
{
    public class DivisaoRepository
    {
        private readonly AppDbContext _context;

        public DivisaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Divisao>> GetDivisoes()
        {
            return await _context.Divisoes
                .Select(e => new Divisao
                {
                    DivisaoId = e.DivisaoId,
                    Nome = e.Nome,
                })
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }
    }
}
