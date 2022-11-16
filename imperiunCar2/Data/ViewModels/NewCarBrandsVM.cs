using imperiumCar2.Data.Emun;
using imperiumCar2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace imperiunCar2.Data.ViewModels
{
    public class NewCarBrandsVM
    {

        public int Id { get; set; }


        [Display(Name = "Imagen")]
        [Required(ErrorMessage = "Imagen is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Imagen must be between 3 and 50 chars")]
        public string? Imagen { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 50 chars")]
        public string? Description { get; set; }

        [Display(Name = "Price buy")]
        [Required(ErrorMessage = "Price buy is required")]
        public double PriceBuy { get; set; }

        [Display(Name = "Price sale")]
        [Required(ErrorMessage = "Price sale is required")]
        public double PriceSale { get; set; }

        [Display(Name = "Model year")]
        [Required(ErrorMessage = "Model year is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Model year must be between 3 and 50 chars")]
        public string? ModelYear { get; set; }

        [Display(Name = "License plate")]
        [Required(ErrorMessage = "License plate is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "License plate must be between 3 and 50 chars")]
        public string? LicensePlate { get; set; }

        [Display(Name = "Sure")]
        [Required(ErrorMessage = "Sure is required")]
        public Boolean Sure { get; set; }

        [Display(Name = "Techical Mecahinical")]
        [Required(ErrorMessage = "Technical Mechanical is required")]
        public Boolean TechnicalMechanical { get; set; }


        //Relationship
        public int IdCarsBrands { get; set; }
        [ForeignKey("IdCarsBrands")]
        public CarBrands? CarsBrands { get; set; }

        public TypesCars TypesCars { get; set; }
        [Display(Name = "Select Type CAr Brands")]
        [Required(ErrorMessage = "Type Person is required")]
        public List<int> CarBrandsIds { get; set; }

        public List<Contracts>? Contract { get; set; }

        public List<Transfers>? Transfer { get; set; }
    }
}
