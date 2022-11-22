using imperiumCar2.Models;
using imperiumCar2.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using ustaTickets.Data.Base;

namespace imperiunCar2.Data.Service
{
    public class VehiclesService :EntityBaseRepository<Vehicles>, IVehiclesService
    {
        private readonly ApplicationDbContext _context;
        public VehiclesService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewVehiclesAsync(NewCarBrandsVM data)
        {
            var newVehicle = new Vehicles()
            {
                PriceBuy = data.PriceBuy,
                PriceSale = data.PriceSale,
                LicensePlate = data.LicensePlate,
                Sure = data.Sure,
                Description = data.Description,
                Imagen = data.Imagen,
                TechnicalMechanical = data.TechnicalMechanical,
                ModelYear = data.ModelYear,
                TypesCars = data.TypesCars,
                IdCarsBrands = data.IdCarsBrands

            };
            await _context.Vehicle.AddAsync(newVehicle);
            await _context.SaveChangesAsync();
        }

        public Task DeleteVehiclesAsync(NewCarBrandsVM data)
        {
            throw new NotImplementedException();
        }

        public async Task<Vehicles> GetVehiclesByIdAsync(int id)
        {
            var movieDetails = await _context.Vehicle
                .Include(tp => tp.CarsBrands)
                .FirstOrDefaultAsync(m => m.Id == id);

            return movieDetails;
        }

        public async Task<NewCarBrandsDropdownsVM> GetNewVehiclesDropdownsValues()
        {
            var response = new NewCarBrandsDropdownsVM()
            {

                CarBrands = await _context.CarBrands.OrderBy(a => a.NameBrands).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateVehiclesAsync(NewCarBrandsVM data)
        {
            var dbPerson = await _context.Vehicle.FirstOrDefaultAsync(m => m.Id == data.Id);
            if (dbPerson != null)
            {
                dbPerson.PriceBuy = data.PriceBuy;
                dbPerson.PriceSale = data.PriceSale;
                dbPerson.LicensePlate = data.LicensePlate;
                dbPerson.Sure = data.Sure;
                dbPerson.Description = data.Description;
                dbPerson.Imagen = data.Imagen;
                dbPerson.TechnicalMechanical = data.TechnicalMechanical;
                dbPerson.ModelYear = data.ModelYear;
                dbPerson.TypesCars = data.TypesCars;
                dbPerson.IdCarsBrands = data.IdCarsBrands;

                await _context.SaveChangesAsync();
            }

            // Remove existing actors
            var existingPersonDb = await _context.CarBrands.Where(m => m.Id == data.Id).ToListAsync();
            _context.CarBrands.RemoveRange(existingPersonDb);
            await _context.SaveChangesAsync();
        }

    }
}
 