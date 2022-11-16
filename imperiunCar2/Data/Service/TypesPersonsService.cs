using imperiumCar2.Models;
using Microsoft.EntityFrameworkCore;
using ustaTickets.Data.Base;

namespace imperiunCar2.Data.Service
{
    public class TypesPersonsService : EntityBaseRepository<TypesPersons>, ITypesPersonsService
    {
        public TypesPersonsService(ApplicationDbContext context) : base(context) { }
    }
}
