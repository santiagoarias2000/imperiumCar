using imperiumCar2.Models;

namespace imperiumCar2.Data.ViewModels
{
    public class NewTypePersonDropdownsVM
    {
        public NewTypePersonDropdownsVM()
        {
            TypesPersons = new List<TypesPersons>();
        }
        public List<TypesPersons> TypesPersons { get; set; }

    }
}
