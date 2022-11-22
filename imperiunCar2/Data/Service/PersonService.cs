using imperiumCar2.Models;
using Microsoft.EntityFrameworkCore;
using ustaTickets.Data.Base;
using imperiumCar2.Data.ViewModels;
using System.Linq.Expressions;

namespace imperiunCar2.Data.Service
{
    public class PersonService : EntityBaseRepository<Persons>, IPersonService
    {
        private readonly ApplicationDbContext _context;
        public PersonService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewPersonAsync(NewTypePersonVM data)
        {
            var newPerson = new Persons()
            {
                Document = data.Document,
                Name = data.Name,
                LastName = data.LastName,
                PhoneNumber = data.PhoneNumber,
            };
            await _context.Persons.AddAsync(newPerson);
            await _context.SaveChangesAsync();

        }

        public Task DeletePersonAsync(NewTypePersonVM data)
        {
            throw new NotImplementedException();
        }

        public async Task<Persons> GetPersonByIdAsync(int id)
        {
            var movieDetails = await _context.Persons
                .Include(tp => tp.TypePerson)
                .FirstOrDefaultAsync(m => m.Id == id);

            return movieDetails;
        }

        public async Task<NewTypePersonDropdownsVM> GetNewPersonDropdownsValues()
        {
            var response = new NewTypePersonDropdownsVM()
            {

                TypesPersons = await _context.TypesPersons.OrderBy(a => a.TypePersonName).ToListAsync(),
            };

            return response;
        }

        public async Task UpdatePersonAsync(NewTypePersonVM data)
        {
            var dbPerson = await _context.Persons.FirstOrDefaultAsync(m => m.Id == data.Id);
            if (dbPerson != null)
            {

                dbPerson.Name = data.Name;
                dbPerson.Document = data.Document;
                dbPerson.Name = data.Name;
                dbPerson.LastName = data.LastName;
                dbPerson.PhoneNumber = data.PhoneNumber;

                await _context.SaveChangesAsync();
            }

            // Remove existing actors
            var existingPersonDb = await _context.TypesPersons.Where(m => m.Id == data.Id).ToListAsync();
            _context.TypesPersons.RemoveRange(existingPersonDb);
            await _context.SaveChangesAsync();
        }


    }
}
