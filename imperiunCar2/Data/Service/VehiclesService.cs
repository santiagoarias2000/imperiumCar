using imperiumCar2.Models;
using Microsoft.EntityFrameworkCore;
using ustaTickets.Data.Base;

namespace imperiunCar2.Data.Service
{
    public class VehiclesService :EntityBaseRepository<Vehicles>, IVehiclesService
    {
        public VehiclesService(ApplicationDbContext context) : base(context) { }
    }
}
 