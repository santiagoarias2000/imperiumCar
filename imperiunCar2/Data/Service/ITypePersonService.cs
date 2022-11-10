using imperiumCar2.Models;

namespace imperiunCar2.Data.Service
{
    public interface ITypePersonService
    {
        Task<IEnumerable<TypesPersons>> GetAllAsync();
        Task<TypesPersons> GetByIdAsync(int id);
        Task AddAsync(TypesPersons typesPersons);
        CarBrands Update(int id, TypesPersons NewTypesPersons);
        void Delete(int id);
    }
}
 