using MyTourManagementMVC.Models;

namespace MyTourManagementSystemMVC.Models
{
    public class BookingInfo
    {
         public UserRegisterDetails users { get; set; }
            public BookingDetails bookings { get; set; }
            public TourPackageDetails tours { get; set; }


        }
    }

