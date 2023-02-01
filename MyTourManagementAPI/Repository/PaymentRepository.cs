using Microsoft.EntityFrameworkCore;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.IRepository;
using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.Repository
{
    public class PaymentRepository:IPaymentRepository
    {
        TourDbContext tourDal;
        //private int _nextId = 1;
        public PaymentRepository(TourDbContext _tourdal)
        {
            tourDal = _tourdal;
        }
        public async Task<List<PaymentDetails>> GetAllPayments()
        {
            if (tourDal != null)
            {
                return await tourDal.PaymentDetails.ToListAsync();
            }
            return null;
        }
        public async Task<int> AddPayment(PaymentDetails pkg)
        {
            if (tourDal != null)
            {
                await tourDal.PaymentDetails.AddAsync(pkg);
                await tourDal.SaveChangesAsync();
                return pkg.PaymentId;
            }
            return 0;
        }
        public async Task<PaymentDetails> GetPayment(int? Paymentid)
        {
            if (tourDal != null)
            {
                return await (from u in tourDal.PaymentDetails where u.PaymentId == Paymentid select u).FirstOrDefaultAsync();


            }
            return null;
        }
        public async Task<int> DeletePayment(int? Paymentid)
        {
            int result = 0;
            if (tourDal != null)
            {
                var Payment = await tourDal.PaymentDetails.FirstOrDefaultAsync(x => x.PaymentId == Paymentid);
                if (Paymentid != null)
                {
                    tourDal.PaymentDetails.Remove(Payment);
                    result = await tourDal.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        public async Task UpdatePayment(PaymentDetails Payment)
        {
            if (tourDal != null)
            {
                tourDal.PaymentDetails.Update(Payment);
                await tourDal.SaveChangesAsync();
            }
        }

    }
}
