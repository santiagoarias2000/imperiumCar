using imperiumCar2.Models;
using imperiunCar2.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using ustaTickets.Data.Base;

namespace imperiunCar2.Data.Service
{
    public class TransfersService : EntityBaseRepository<Transfers>, ITransfersService
    {
        private readonly ApplicationDbContext _context;
        public TransfersService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewTransfersAsync(NewVehicleVM data)
        {
            var newTrasnfers = new Transfers()
            {
                IdVehicle = data.IdVehicle,
                Value = data.Value,
                Vehicle = data.Vehicle,

            };
            await _context.Transfers.AddAsync(newTrasnfers);
            await _context.SaveChangesAsync();

            // Add Type
            foreach (var IdVehicle in data.VehiclesIds)
            {
                var newVehicle = new Vehicles()
                {
                    Id = newTrasnfers.Id
                };
                await _context.Vehicle.AddAsync(newVehicle);
            }
            await _context.SaveChangesAsync();
        }

        public Task DeleteTransfersAsync(NewVehicleVM data)
        {
            throw new NotImplementedException();
        }

        public async Task<Transfers> GetTransfersByIdAsync(int id)
        {
            var movieDetails = await _context.Transfers
                .Include(tp => tp.Vehicle.Id)
                .FirstOrDefaultAsync(m => m.Id == id);

            return movieDetails;
        }

        public async Task<NewVehicleDropdownsVM> GetNewTransfersDropdownsValues()
        {
            var response = new NewVehicleDropdownsVM()
            {

                Vehicles = await _context.Vehicle.OrderBy(a => a.LicensePlate).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateTransfersAsync(NewVehicleVM data)
        {
            var dbTransfers = await _context.Transfers.FirstOrDefaultAsync(m => m.Id == data.Id);
            if (dbTransfers != null)
            {

                dbTransfers.Vehicle = data.Vehicle;
                dbTransfers.Value = data.Value;
                dbTransfers.IdVehicle = data.IdVehicle;


                await _context.SaveChangesAsync();
            }

            // Remove existing actors
            var existingPersonDb = await _context.Vehicle.Where(m => m.Id == data.Id).ToListAsync();
            _context.Vehicle.RemoveRange(existingPersonDb);
            await _context.SaveChangesAsync();

            // Add Movie Actors
            foreach (var typePersonId in data.VehiclesIds)
            {
                var newPerson = new TypesPersons()
                {
                    Id = data.Id
                };
                await _context.TypesPersons.AddAsync(newPerson);
            }
            await _context.SaveChangesAsync();
        }

    }
}
