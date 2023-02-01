using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTourManagementMVC.Models
{
    public class UserRegisterDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email id cannot be null")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password cannot be null")]
        public string? Password { get; set; }
        public long? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
