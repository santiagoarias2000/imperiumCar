using imperiumCar2.Models;
using imperiumCar2.Data.ViewModels;
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
                ValueTrans = data.ValueTrans,

            };
            await _context.Transfers.AddAsync(newTrasnfers);
            await _context.SaveChangesAsync();

        }

        public Task DeleteTransfersAsync(NewVehicleVM data)
        {
            throw new NotImplementedException();
        }

        public async Task<Transfers> GetTransfersByIdAsync(int id)
        {
            var transfersDetails = await _context.Transfers
                .Include(tp => tp.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);

            return transfersDetails;
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

                dbTransfers.ValueTrans = data.ValueTrans;


                await _context.SaveChangesAsync();
            }

            // Remove existing actors
            var existingPersonDb = await _context.Vehicle.Where(m => m.Id == data.Id).ToListAsync();
            _context.Vehicle.RemoveRange(existingPersonDb);
            await _context.SaveChangesAsync();
        }

    }
}
