using imperiumCar2.Models;

namespace imperiunCar2.Data.Service
{
    public interface IContractsService
    {
        Task<IEnumerable<Contracts>> GetAllAsync();
        Task<Contracts> GetByIdAsync(int id);
        Task AddAsync(Contracts contracts);
        Contracts Update(int id, Contracts NewContracts);
        void Delete(int id);
    }
}
