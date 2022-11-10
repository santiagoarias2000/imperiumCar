using imperiumCar2.Models;

namespace imperiunCar2.Data.Service
{
    public interface ICarBrandsService
    {
        Task<IEnumerable<CarBrands>> GetAllAsync();
        Task<CarBrands> GetByIdAsync(int id);
        Task AddAsync(CarBrands carBrands);
        CarBrands Update(int id, CarBrands NewCarBrand);
        void Delete(int id);
    }
}
