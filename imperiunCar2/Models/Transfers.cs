using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ustaTickets.Data.Base;

namespace imperiumCar2.Models
{
    public class Transfers: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Value")]
        [Required(ErrorMessage = "Value is required")]
        public int ValueTrans { get; set; }


        //Relationship
        public int IdVehicle { get; set; }
        [ForeignKey("IdVehicle")]
        public Vehicles? Vehicle { get; set; }
    }
}
