using MyTourManagementAPI.Models;
using System.Collections;
using System.Threading.Tasks;

namespace MyTourManagementAPI.IRepository
{
    public interface IBookingRepository
    {
        Task<int> AddBooking(BookingDetails bookingDetails);
        Task<List<BookingDetails>> GetAllBookings();

        Task UpdateBooking(BookingDetails bookingDetails);
        Task<int> DeleteBooking(int? id);
        Task<BookingDetails> GetBooking(int? id);
        //IList GetUserBookingInformation(int? id);

    }  
}
