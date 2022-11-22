using imperiumCar2.Data.ViewModels;
using imperiumCar2.Models;
using Microsoft.EntityFrameworkCore;
using ustaTickets.Data.Base;

namespace imperiunCar2.Data.Service
{
    public class ContractsService : EntityBaseRepository<Contracts>, IContractsService
    {
        private readonly ApplicationDbContext _context;
        public ContractsService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewContractsAsync(NewContractsVM data)
        {
            var newContract = new Contracts()
            {
                SaleValue = data.SaleValue,
                Description = data.Description,
                IdPersons = data.IdPersons,
                IdVehicle = data.IdVehicle
            };
            await _context.Contracts.AddAsync(newContract);
            await _context.SaveChangesAsync();
        }

        public Task DeleteContractsAsync(NewContractsVM data)
        {
            throw new NotImplementedException();
        }

        public async Task<Contracts> GetConstractsByIdAsync(int id)
        {
            var contractDetails = await _context.Contracts
                .Include(per => per.Persons)
                .Include(ve => ve.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);

            return contractDetails;
        }

        public async Task<NewContractsDropdownsVM> GetNewContractsDropdownsValues()
        {
            var response = new NewContractsDropdownsVM()
            {
                Persons = await _context.Persons.OrderBy(a => a.Name).ToListAsync(),
                Vehicles = await _context.Vehicle.OrderBy(a => a.LicensePlate).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateContractsAsync(NewContractsVM data)
        {
            var dbVehicles = await _context.Contracts.FirstOrDefaultAsync(m => m.Id == data.Id);
            if (dbVehicles != null)
            {

                dbVehicles.SaleValue = data.SaleValue;
                dbVehicles.Description = data.Description;
                dbVehicles.IdPersons = data.IdPersons;
                dbVehicles.IdVehicle = data.IdVehicle;

                await _context.SaveChangesAsync();
            }

            // Remove existing actors
            var existingPersonDb = await _context.Contracts.Where(m => m.Id == data.Id).ToListAsync();
            _context.Contracts.RemoveRange(existingPersonDb);
            await _context.SaveChangesAsync();
        }
    }
}

