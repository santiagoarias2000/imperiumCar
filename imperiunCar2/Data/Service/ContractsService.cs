using imperiumCar2.Models;
using Microsoft.EntityFrameworkCore;

namespace imperiunCar2.Data.Service
{
    public class ContractsService : IContractsService
    {
        private readonly ApplicationDbContext _context;

        public ContractsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Contracts contracts)
        {
            await _context.Contracts.AddAsync(contracts);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contracts>> GetAllAsync()
        {
            var result = await _context.Contracts.ToListAsync();
            return result;
        }

        public async Task<Contracts> GetByIdAsync(int id)
        {
            var result = await _context.Contracts.FirstOrDefaultAsync(a => a.IdContract == id);
            return result;
        }

        public Contracts Update(int id, Contracts NewContracts)
        {
            throw new NotImplementedException();
        }
    }
}
