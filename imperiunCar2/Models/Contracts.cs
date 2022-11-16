using imperiumCar2.Data.Emun;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ustaTickets.Data.Base;

namespace imperiumCar2.Models
{
    public class Contracts:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sale Value")]
        [Required(ErrorMessage = "Sale Value is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Sale value must be between 3 and 50 chars")]
        public double SaleValue { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 50 chars")]
        public string? Description { get; set; }

        //Relationship
        public int IdPersons { get; set; }
        [ForeignKey("IdPersons")]
        public Persons? Persons { get; set; }

        public int IdVehicle { get; set; }
        [ForeignKey("IdVehicle")]
        public Vehicles? Vehicle { get; set; }

        public TypesContracts TypesContracts { get; set; }

    }
}
