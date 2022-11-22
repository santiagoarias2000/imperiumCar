using imperiumCar2.Models;
using ustaTickets.Data.Base;
using imperiumCar2.Data.ViewModels;

namespace imperiunCar2.Data.Service
{
    public interface ITransfersService: IEntityBaseRepository<Transfers>
    {
        Task<Transfers> GetTransfersByIdAsync(int id);
        Task<NewVehicleDropdownsVM> GetNewTransfersDropdownsValues();
        Task AddNewTransfersAsync(NewVehicleVM data);
        Task UpdateTransfersAsync(NewVehicleVM data);
        Task DeleteTransfersAsync(NewVehicleVM data);
    }
}
