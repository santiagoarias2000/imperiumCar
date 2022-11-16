using Microsoft.EntityFrameworkCore;
using imperiumCar2.Models;
using ustaTickets.Data.Base;

namespace imperiunCar2.Data.Service
{
    public class CarBrandsService : EntityBaseRepository<CarBrands>, ICarBrandsService
    {
        public CarBrandsService(ApplicationDbContext context) : base(context) { }
    }
}
