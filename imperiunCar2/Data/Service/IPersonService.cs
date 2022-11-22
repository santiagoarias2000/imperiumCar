using imperiumCar2.Models;
using ustaTickets.Data.Base;
using imperiumCar2.Data.ViewModels;

namespace imperiunCar2.Data.Service
{
    public interface IPersonService: IEntityBaseRepository<Persons>
    {
        Task<Persons> GetPersonByIdAsync(int id);
        Task<NewTypePersonDropdownsVM> GetNewPersonDropdownsValues();
        Task AddNewPersonAsync(NewTypePersonVM data);
        Task UpdatePersonAsync(NewTypePersonVM data);
        Task DeletePersonAsync(NewTypePersonVM data);
    }
}
