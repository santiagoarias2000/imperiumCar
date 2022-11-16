using imperiumCar2.Models;
using imperiunCar2.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using ustaTickets.Data.Base;

namespace imperiunCar2.Data.Service
{
    public class TransfersService : EntityBaseRepository<Transfers>, ITransfersService
    {
        public TransfersService(ApplicationDbContext context) : base(context) { }

        public Task AddNewTransfersAsync(NewVehicleVM data)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTransfersAsync(NewVehicleVM data)
        {
            throw new NotImplementedException();
        }

        public Task<NewVehicleDropdownsVM> GetNewTransfersDropdownsValues()
        {
            throw new NotImplementedException();
        }

        public Task<Transfers> GetTransfersByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTransfersAsync(NewVehicleVM data)
        {
            throw new NotImplementedException();
        }
    }
}
