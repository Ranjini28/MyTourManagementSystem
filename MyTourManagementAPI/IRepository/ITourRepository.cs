using MyTourManagementAPI.Models;
using System.Threading.Tasks;


namespace MyTourManagementAPI.IRepository
{
    public interface ITourRepository
    {
        Task<int> AddPackage(TourPackageDetails packageDetails);
        Task<List<TourPackageDetails>> GetAllPackages();

        Task UpdatePackage(TourPackageDetails packageDetails);
        Task<int> DeletePackage(int? id);
        Task<TourPackageDetails> GetPackage(int? id);
    }
}
