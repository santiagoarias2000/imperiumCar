using Microsoft.EntityFrameworkCore;
using imperiumCar2.Models;

namespace imperiunCar2.Data.Service
{
    public class CarBrandsService : ICarBrandsService
    {
        private readonly ApplicationDbContext _context;

        public CarBrandsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(CarBrands carBrands)
        {
            await _context.CarBrands.AddAsync(carBrands);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CarBrands>> GetAllAsync()
        {
            var result = await _context.CarBrands.ToListAsync();
            return result;
        }

        public async Task<CarBrands> GetByIdAsync(int id)
        {
            var result = await _context.CarBrands.FirstOrDefaultAsync(a => a.IdCarsBrands == id);
            return result;
        }

        public CarBrands Update(int id, CarBrands NewCarBrand)
        {
            throw new NotImplementedException();
        }
    }
}
