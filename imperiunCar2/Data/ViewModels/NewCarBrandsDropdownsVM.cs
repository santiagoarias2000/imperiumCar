using imperiumCar2.Models;

namespace imperiumCar2.Data.ViewModels
{
    public class NewCarBrandsDropdownsVM
    {
        public List<CarBrands> CarBrands { get; set; }
        public NewCarBrandsDropdownsVM()
        {
            CarBrands = new List<CarBrands>();
        }


    }
}
