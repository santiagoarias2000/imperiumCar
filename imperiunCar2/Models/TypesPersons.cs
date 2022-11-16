using System.ComponentModel.DataAnnotations;
using ustaTickets.Data.Base;

namespace imperiumCar2.Models
{
    public class TypesPersons:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Type Person")]
        [Required(ErrorMessage = "Type person is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Type person must be between 3 and 50 chars")]
        public string? TypePersonName { get; set; }
        public List<Persons>? Persons { get; set; }
    }
}
