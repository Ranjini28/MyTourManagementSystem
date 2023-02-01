using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTourManagementAPI.Models
{
    public class BookingDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberChildren { get; set; }
        [Display(Name = "UserRegisterDetails")]
        public virtual int UserId { get; set; }

        [ForeignKey("UserId")]

        [Display(Name = "TourPackageDetails")]
        public virtual int TourId { get; set; }
        [ForeignKey("TourId")]
        public virtual TourPackageDetails? tours { get; set; }
        
    }
}
