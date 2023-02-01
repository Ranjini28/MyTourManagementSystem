using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.IRepository;
using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        TourDbContext tourDal;
        //private int _nextId = 1;
        public UserRepository(TourDbContext _tourdal)
        {
            tourDal = _tourdal;
        }
        public async Task<List<UserRegisterDetails>> GetAllUsers()
        {
            if (tourDal != null)
            {
                return await tourDal.UserRegisterDetails.ToListAsync();
            }
            return null;
        }
        public async Task<int> AddUser(UserRegisterDetails user)
        {
            if (tourDal != null)
            {
                await tourDal.UserRegisterDetails.AddAsync(user);
                await tourDal.SaveChangesAsync();
                return user.UserId;
            }
            return 0;
        }
        public async Task<UserRegisterDetails> GetUser(int? userid)
        {
            if (tourDal != null)
            {
                return await (from u in tourDal.UserRegisterDetails where u.UserId == userid select u).FirstOrDefaultAsync();


            }
            return null;
        }
        public async Task<int> DeleteUser(int? userid)
        {
            int result = 0;
            if (tourDal != null)
            {
                var user = await tourDal.UserRegisterDetails.FirstOrDefaultAsync(x => x.UserId == userid);
                if (userid != null)
                {
                    tourDal.UserRegisterDetails.Remove(user);
                    result = await tourDal.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        public async Task UpdateUser(UserRegisterDetails user)
        {
            if (tourDal != null)
            {
                tourDal.UserRegisterDetails.Update(user);
                await tourDal.SaveChangesAsync();
            }
        }

        public async Task<UserRegisterDetails> UserLogin(string useremail, string password)
        {

            /*int userid = 0;
            if (tourDal != null)
            {

                var result = await tourDal.UserRegisterDetails.FirstOrDefaultAsync(x => x.Email == useremail && x.Password == password);

                if(useremail!=null || password!=null)
            {
                    userid = result.UserId;
            }
                return userid;
            }
            return userid;*/
            if (tourDal != null)
            {
                return await (from u in tourDal.UserRegisterDetails where u.Email == useremail && u.Password == password select u).FirstOrDefaultAsync();


            }
            return null;


        }

        public async Task<UserRegisterDetails> GetUserByPhoneNumber(long? phno)
        {
            if (tourDal != null)
            {
               
                    return await (from u in tourDal.UserRegisterDetails where u.PhoneNumber == phno select u).FirstOrDefaultAsync();


               
            }
            return null;
        }
    }
       
}
