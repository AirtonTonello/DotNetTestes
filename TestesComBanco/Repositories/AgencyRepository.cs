using Microsoft.EntityFrameworkCore;
using TestesComBanco.Context;
using TestesComBanco.Interfaces;
using TestesComBanco.Models;

namespace TestesComBanco.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly BancoDbContext _dbContext;

        public AgencyRepository(BancoDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<IList<Agency>> GetAllAsync()
        {
            return await _dbContext.Agencies.ToListAsync();
        }

        public async Task<Agency> GetByIdAsync(int id)
        {
            return await _dbContext.Agencies.SingleAsync(i => i.Id == id);
        }

        public async Task AddAsync(Agency entity)
        {
            await _dbContext.Agencies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Agency entity)
        {
            _dbContext.Agencies.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var current = await _dbContext.Agencies.SingleOrDefaultAsync(i => i.Id == id);

            if (current != null)
            {
                _dbContext.Agencies.Remove(current);
                await _dbContext.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
