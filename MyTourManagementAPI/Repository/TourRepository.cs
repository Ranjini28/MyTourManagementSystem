using Microsoft.EntityFrameworkCore;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.IRepository;
using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.Repository
{
    public class TourRepository:ITourRepository
    {
          TourDbContext tourDal;
            //private int _nextId = 1;
            public TourRepository(TourDbContext _tourdal)
            {
                tourDal = _tourdal;
            }
            public async Task<List<TourPackageDetails>> GetAllPackages()
            {
                if (tourDal != null)
                {
                    return await tourDal.TourPackageDetails.ToListAsync();
                }
                return null;
            }
            public async Task<int> AddPackage(TourPackageDetails pkg)
            {
                if (tourDal != null)
                {
                    await tourDal.TourPackageDetails.AddAsync(pkg);
                    await tourDal.SaveChangesAsync();
                    return pkg.TourId;
                }
                return 0;
            }
            public async Task<TourPackageDetails> GetPackage(int? tourid)
            {
                if (tourDal != null)
                {
                    return await (from u in tourDal.TourPackageDetails where u.TourId == tourid select u).FirstOrDefaultAsync();


                }
                return null;
            }
            public async Task<int> DeletePackage(int? tourid)
            {
                int result = 0;
                if (tourDal != null)
                {
                    var pkg = await tourDal.TourPackageDetails.FirstOrDefaultAsync(x => x.TourId == tourid);
                    if (tourid != null)
                    {
                        tourDal.TourPackageDetails.Remove(pkg);
                        result = await tourDal.SaveChangesAsync();
                    }
                    return result;
                }
                return result;
            }
            public async Task UpdatePackage(TourPackageDetails pkg)
            {
                if (tourDal != null)
                {
                    tourDal.TourPackageDetails.Update(pkg);
                    await tourDal.SaveChangesAsync();
                }
            }

        }
    }
