using imperiumCar2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace imperiunCar2.Data.ViewModels
{
    public class NewVehicleVM
    {

        public int Id { get; set; }

        [Display(Name = "Value")]
        [Required(ErrorMessage = "Value is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Value must be between 3 and 50 chars")]
        public int Value { get; set; }


        //Relationship
        public int IdVehicle { get; set; }
        [ForeignKey("IdVehicle")]
        public Vehicles Vehicle { get; set; }


    }
}
