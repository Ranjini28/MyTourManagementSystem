using MyTourManagementAPI.Models;
using System.Threading.Tasks;
namespace MyTourManagementAPI.IRepository
{
    public interface IPaymentRepository
    {
        Task<int> AddPayment(PaymentDetails paymentDetails);
        Task<List<PaymentDetails>> GetAllPayments();

        Task UpdatePayment(PaymentDetails paymentDetails);
        Task<int> DeletePayment(int? id);
        Task<PaymentDetails> GetPayment(int? id);
    }
}
