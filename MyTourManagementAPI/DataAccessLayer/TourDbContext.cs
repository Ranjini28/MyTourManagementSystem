using Microsoft.EntityFrameworkCore;
using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.DataAccessLayer
{
    public class TourDbContext : DbContext
    {
        public TourDbContext()
        {
        }

        public TourDbContext(DbContextOptions<TourDbContext> options)
       : base(options)
        {
        }
        public DbSet<UserRegisterDetails> UserRegisterDetails { get; set; }
        public DbSet<Admin> AdminTable { get; set; }
        public DbSet<TravelAgency> TravelAgencyDetails { get; set; }
        public DbSet<TourPackageDetails> TourPackageDetails { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }
        public object Post { get; internal set; }
    }
}
