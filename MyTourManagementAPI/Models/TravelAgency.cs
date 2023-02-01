using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTourManagementAPI.Models
{
    public class TravelAgency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgencyId { get; set; }
        [Required(ErrorMessage = "Agency Name is Required")]
        public string AgencyName { get; set; } = null!;

        public string? Description { get; set; }
        public string? accomodation { get; set; }
        [Required(ErrorMessage = "Travel mode is Required")]
        public string TravelMode { get; set; } = null!;

        
    }
}
