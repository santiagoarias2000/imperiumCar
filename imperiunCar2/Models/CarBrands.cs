using System.ComponentModel.DataAnnotations;
using ustaTickets.Data.Base;

namespace imperiumCar2.Models
{
    public class CarBrands:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name Brands")]
        [Required(ErrorMessage = "Name Brands is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name brands must be between 3 and 50 chars")]
        public string NameBrands { get; set; }

        //Relationship
        public List<Vehicles>? Vehicles { get; set; }

    }
}
