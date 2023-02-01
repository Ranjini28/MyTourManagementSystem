using Microsoft.EntityFrameworkCore;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.IRepository;
using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.Repository
{
    public class AgencyRepository:IAgencyRepository
    { 
              TourDbContext tourDal;
    //private int _nextId = 1;
    public AgencyRepository(TourDbContext _tourdal)
    {
        tourDal = _tourdal;
    }
    public async Task<List<TravelAgency>> GetAllAgencys()
    {
        if (tourDal != null)
        {
            return await tourDal.TravelAgencyDetails.ToListAsync();
        }
        return null;
    }
    public async Task<int> AddAgency(TravelAgency agency)
    {
        if (tourDal != null)
        {
            await tourDal.TravelAgencyDetails.AddAsync(agency);
            await tourDal.SaveChangesAsync();
            return agency.AgencyId;
        }
        return 0;
    }
    public async Task<TravelAgency> GetAgency(int? agencyid)
    {
        if (tourDal != null)
        {
            return await (from u in tourDal.TravelAgencyDetails where u.AgencyId == agencyid select u).FirstOrDefaultAsync();


        }
        return null;
    }
    public async Task<int> DeleteAgency(int? agencyid)
    {
        int result = 0;
        if (tourDal != null)
        {
            var agency = await tourDal.TravelAgencyDetails.FirstOrDefaultAsync(x => x.AgencyId == agencyid);
            if (agencyid != null)
            {
                tourDal.TravelAgencyDetails.Remove(agency);
                result = await tourDal.SaveChangesAsync();
            }
            return result;
        }
        return result;
    }
    public async Task UpdateAgency(TravelAgency agency)
    {
        if (tourDal != null)
        {
            tourDal.TravelAgencyDetails.Update(agency);
            await tourDal.SaveChangesAsync();
        }
    }

}
    }

