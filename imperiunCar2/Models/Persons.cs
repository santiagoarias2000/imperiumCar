using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ustaTickets.Data.Base;

namespace imperiumCar2.Models
{
    public class Persons:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Document")]
        [Required(ErrorMessage = "Document is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Document must be between 3 and 50 chars")]
        public string Document { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 50 chars")]
        public string LastName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 50 chars")]
        public string PhoneNumber { get; set; }

        //Relationship

        public int IdTypePerson { get; set; }
        [ForeignKey("IdTypesPerson")]
        public TypesPersons TypePerson { get; set; }

        public List<Contracts>? Contract { get; set; }
    }
}
