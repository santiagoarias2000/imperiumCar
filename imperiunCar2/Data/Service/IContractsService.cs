using imperiumCar2.Data.ViewModels;
using imperiumCar2.Models;
using ustaTickets.Data.Base;

namespace imperiunCar2.Data.Service
{
    public interface IContractsService: IEntityBaseRepository<Contracts>
    {
        Task<Contracts> GetConstractsByIdAsync(int id);
        Task<NewContractsDropdownsVM> GetNewContractsDropdownsValues();
        Task AddNewContractsAsync(NewContractsVM data);
        Task UpdateContractsAsync(NewContractsVM data);
        Task DeleteContractsAsync(NewContractsVM data);
    }
}
