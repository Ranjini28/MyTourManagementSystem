using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.ViewModels
{
    public class BookingInfo
    {
        public UserRegisterDetails users { get; set; }
        public BookingDetails bookings { get; set; }
        public TourPackageDetails tours { get; set; }


    }
}
