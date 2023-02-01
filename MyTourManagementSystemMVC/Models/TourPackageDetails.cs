using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyTourManagementMVC.Models
{
    public class TourPackageDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TourId { get; set; }
        [Required(ErrorMessage = "Tour Name is Required")]
        public string TourName { get; set; } = null!;

        public string? Itinerary { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string ?tourimagepath { get; set; }
        public string? Departurepoint { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        public decimal Price { get; set; }

        [Display(Name = "TravelAgency")]
        public virtual int AgencyId { get; set; }

        [ForeignKey("AgencyId")]
        public virtual TravelAgencyDetails? agencys { get; set; }
    }
}
