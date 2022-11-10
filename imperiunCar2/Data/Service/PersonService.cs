using imperiumCar2.Models;
using Microsoft.EntityFrameworkCore;

namespace imperiunCar2.Data.Service
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _context;

        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Persons person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Persons>> GetAllAsync()
        {
            var result = await _context.Persons.ToListAsync();
            return result;
        }

        public async Task<Persons> GetByIdAsync(int id)
        {
            var result = await _context.Persons.FirstOrDefaultAsync(a => a.IdPersons == id); 
            return result;
        }

        public CarBrands Update(int id, Persons NewPerson)
        {
            throw new NotImplementedException();
        }
    }
}
