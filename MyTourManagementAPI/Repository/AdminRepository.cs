using Microsoft.EntityFrameworkCore;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.IRepository;
using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.Repository
{
    public class AdminRepository:IAdminRepository
    {
        TourDbContext tourDal;
        public async Task<int> AddAdmin(Admin admin)
        {
            if (tourDal != null)
            {
                await tourDal.AdminTable.AddAsync(admin);
                await tourDal.SaveChangesAsync();
                return admin.adminId;
            }
            return 0;
        }
    }
}
