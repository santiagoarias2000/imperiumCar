using imperiumCar2.Models; 
namespace imperiunCar2.Data.Service
{
    public interface ITransfersService
    {
        Task<IEnumerable<Transfers>> GetAllAsync();
        Task<Transfers> GetByIdAsync(int id);
        Task AddAsync(Transfers transfers);
        CarBrands Update(int id, Transfers NewTransfers);
        void Delete(int id);
    }
}
