using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTourManagementAPI.Models
{
    public class PaymentDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        [Required(ErrorMessage = "Amount cannot be null")]
        public decimal Amount { get; set; }
        public string? PaymentMode { get; set; }
        public DateTime? PaymentDateTime { get; set; }
        
        [Display(Name = "UserRegisterDetails")]
        public virtual int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserRegisterDetails? users { get; set; }
        [Display(Name = "BookingDetails")]
        public virtual int Id { get; set; }

        [ForeignKey("Id")]
        public virtual BookingDetails? bookings { get; set; }
    }
}
