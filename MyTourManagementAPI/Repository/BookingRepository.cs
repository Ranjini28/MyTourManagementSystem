using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.IRepository;
using MyTourManagementAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MyTourManagementAPI.Repository
{
    public class BookingRepository : IBookingRepository
    {
        TourDbContext tourDal;
        //private int _nextId = 1;
        public BookingRepository(TourDbContext _tourdal)
        {
            tourDal = _tourdal;
        }
        public async Task<List<BookingDetails>> GetAllBookings()
        {
            if (tourDal != null)
            {
                return await tourDal.BookingDetails.ToListAsync();
            }
            return null;
        }
        public async Task<int> AddBooking(BookingDetails booking)
        {
            if (tourDal != null)
            {
                await tourDal.BookingDetails.AddAsync(booking);
                await tourDal.SaveChangesAsync();
                return booking.Id;
            }
            return 0;
        }
        public async Task<BookingDetails> GetBooking(int? bookingid)
        {
            if (tourDal != null)
            {
                return await (from u in tourDal.BookingDetails where u.Id == bookingid select u).FirstOrDefaultAsync();


            }
            return null;
        }
        public async Task<int> DeleteBooking(int? bookingid)
        {
            int result = 0;
            if (tourDal != null)
            {
                var booking = await tourDal.BookingDetails.FirstOrDefaultAsync(x => x.Id == bookingid);
                if (bookingid != null)
                {
                    tourDal.BookingDetails.Remove(booking);
                    result = await tourDal.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        public async Task UpdateBooking(BookingDetails booking)
        {
            if (tourDal != null)
            {
                tourDal.BookingDetails.Update(booking);
                await tourDal.SaveChangesAsync();
            }
        }

       /*public IList GetUserBookingInformation(int ?userid)
        {
            if (tourDal != null )
            {
                using (TourDbContext db = new TourDbContext())
                {
                   
                    List<UserRegisterDetails> users = db.UserRegisterDetails.ToList();
                    List<BookingDetails> bookings = db.BookingDetails.ToList();
                    List<TourPackageDetails> packages = db.TourPackageDetails.ToList();
                    
                    var res = (from u in tourDal.UserRegisterDetails
                               join b in
                               tourDal.BookingDetails.ToList() on u.UserId equals b.UserId into table1
                               from b in table1.ToList()
                               join t in tourDal.TourPackageDetails on
                               b.TourId equals t.TourId into table2
                               from t in table2.ToList()
                               where u.UserId==userid
                               select new BookingInfo
                               {
                                   users = u,
                                   bookings = b,
                                   tours = t
                               }).ToList();


                    return res;
                }


            }
            return null;

        }*/

        
    }
}
