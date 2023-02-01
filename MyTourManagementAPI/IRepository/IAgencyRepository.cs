using MyTourManagementAPI.Models;
using System.Threading.Tasks;


namespace MyTourManagementAPI.IRepository
{
    public interface IAgencyRepository
    {
        Task<int> AddAgency(TravelAgency agencyDetails);
        Task<List<TravelAgency>> GetAllAgencys();

        Task UpdateAgency(TravelAgency agencyDetails);
        Task<int> DeleteAgency(int? id);
        Task<TravelAgency> GetAgency(int? id);
    }
}
