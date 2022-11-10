using imperiumCar2.Models;

namespace imperiunCar2.Data.Service
{
    public interface IPersonService
    {
        Task<IEnumerable<Persons>> GetAllAsync();
        Task<Persons> GetByIdAsync(int id);
        Task AddAsync(Persons person);
        CarBrands Update(int id, Persons NewPerson);
        void Delete(int id);
    }
}
