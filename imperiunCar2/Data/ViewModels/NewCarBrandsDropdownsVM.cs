using imperiumCar2.Models;

namespace imperiunCar2.Data.ViewModels
{
    public class NewCarBrandsDropdownsVM
    {
        public NewCarBrandsDropdownsVM()
        {
            CarBrands = new List<CarBrands>();
        }
        public List<CarBrands> CarBrands { get; set; }

    }
}
