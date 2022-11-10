using imperiumCar2.Models;
using Microsoft.EntityFrameworkCore;

namespace imperiunCar2.Data.Service
{
    public class TypePersonService : ITypePersonService
    {
        private readonly ApplicationDbContext _context;

        public TypePersonService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TypesPersons typesPersons)
        {
            await _context.TypesPersons.AddAsync(typesPersons);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TypesPersons>> GetAllAsync()
        {
            var result = await _context.TypesPersons.ToListAsync();
            return result;
        }

        public async Task<TypesPersons> GetByIdAsync(int id)
        {
            var result = await _context.TypesPersons.FirstOrDefaultAsync(a => a.IdTypesPerson == id);
            return result;
        }

        public CarBrands Update(int id, TypesPersons NewTypesPersons)
        {
            throw new NotImplementedException();
        }
    }
}
