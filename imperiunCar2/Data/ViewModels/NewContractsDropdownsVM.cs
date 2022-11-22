using imperiumCar2.Models;

namespace imperiumCar2.Data.ViewModels
{
    public class NewContractsDropdownsVM
    {
        public NewContractsDropdownsVM()
        {
            Persons = new List<Persons>();
            Vehicles = new List<Vehicles>();
        }
        public List<Persons> Persons { get; set; }
        public List<Vehicles> Vehicles { get; set; }

    }
}
