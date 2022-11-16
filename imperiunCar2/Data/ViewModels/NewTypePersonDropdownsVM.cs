using imperiumCar2.Models;

namespace imperiunCar2.Data.ViewModels
{
    public class NewTypePersonDropdownsVM
    {
        public NewTypePersonDropdownsVM()
        {
            TypePerson = new List<TypesPersons>();
        }
        public List<TypesPersons> TypePerson { get; set; }

    }
}
