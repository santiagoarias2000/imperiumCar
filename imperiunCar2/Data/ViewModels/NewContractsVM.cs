using imperiumCar2.Data.Emun;
using imperiumCar2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace imperiumCar2.Data.ViewModels
{
    public class NewContractsVM
    {

        public int Id { get; set; }
        [Display(Name = "Sale Value")]
        [Required(ErrorMessage = "Sale Value is required")]
        public int SaleValue { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 50 chars")]
        public string? Description { get; set; }
 

        [Display(Name = "Select Persons")]
        [Required(ErrorMessage = "Description is required")]
        public int IdPersons { get; set; }

        [Display(Name = "Select Vehicles")]
        [Required(ErrorMessage = "Description is required")]
        public int IdVehicle { get; set; }


    }
}
