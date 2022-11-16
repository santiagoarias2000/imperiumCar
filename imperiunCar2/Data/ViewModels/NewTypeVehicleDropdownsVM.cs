using imperiumCar2.Models;

namespace imperiunCar2.Data.ViewModels
{
    public class NewVehicleDropdownsVM
    {
        public NewVehicleDropdownsVM()
        {
            Vehicles = new List<Vehicles>();
        }
        public List<Vehicles> Vehicles { get; set; }

    }
}
