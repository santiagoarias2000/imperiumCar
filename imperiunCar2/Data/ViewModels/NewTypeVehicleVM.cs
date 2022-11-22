using imperiumCar2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace imperiumCar2.Data.ViewModels
{
    public class NewVehicleVM
    {

        public int Id { get; set; }

        [Display(Name = "Value")]
        [Required(ErrorMessage = "Value is required")]
        public int ValueTrans { get; set; }


        [Display(Name = "Select vehicles")]
        [Required(ErrorMessage = "vehicles is required")]
        public int IdVehicle { get; set; }


    }
}
