using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.IRepository
{
    public interface IAdminRepository
    {
        Task<int> AddAdmin(Admin adminDetails);
    }
}
