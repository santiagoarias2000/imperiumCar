using imperiumCar2.Models;
using Microsoft.EntityFrameworkCore;
using ustaTickets.Data.Base;

namespace imperiunCar2.Data.Service
{
    public class TypePersonService : EntityBaseRepository<TypesPersons>, ITypePersonService
    {
        public TypePersonService(ApplicationDbContext context) : base(context) { }
    }
}
