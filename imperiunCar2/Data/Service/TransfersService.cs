using imperiumCar2.Models;
using Microsoft.EntityFrameworkCore;

namespace imperiunCar2.Data.Service
{
    public class TransfersService : ITransfersService
    {
        private readonly ApplicationDbContext _context;

        public TransfersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transfers transfers)
        {
            await _context.Transfers.AddAsync(transfers);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transfers>> GetAllAsync()
        {
            var result = await _context.Transfers.ToListAsync();
            return result;
        }

        public async Task<Transfers> GetByIdAsync(int id)
        {
            var result = await _context.Transfers.FirstOrDefaultAsync(a => a.IdTransfers == id);
            return result;
        }

        public CarBrands Update(int id, Transfers NewTransfers)
        {
            throw new NotImplementedException();
        }
    }
}
