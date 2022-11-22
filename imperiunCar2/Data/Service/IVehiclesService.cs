using imperiumCar2.Models;
using imperiumCar2.Data.ViewModels;
using ustaTickets.Data.Base;

namespace imperiunCar2.Data.Service
{
    public interface IVehiclesService: IEntityBaseRepository<Vehicles>
    {
        Task<Vehicles> GetVehiclesByIdAsync(int id);
        Task<NewCarBrandsDropdownsVM> GetNewVehiclesDropdownsValues();
        Task AddNewVehiclesAsync(NewCarBrandsVM data);
        Task UpdateVehiclesAsync(NewCarBrandsVM data);
        Task DeleteVehiclesAsync(NewCarBrandsVM data);
    }
}
