using imperiumCar2.Models;
using Microsoft.EntityFrameworkCore;
using ustaTickets.Data.Base;

namespace imperiunCar2.Data.Service
{
    public class ContractsService : EntityBaseRepository<Contracts>, IContractsService
    {
        public ContractsService(ApplicationDbContext context) : base(context) { }
    }
}

