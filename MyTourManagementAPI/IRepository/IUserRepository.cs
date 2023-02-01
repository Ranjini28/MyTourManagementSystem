using MyTourManagementAPI.Models;
using System.Threading.Tasks;

namespace MyTourManagementAPI.IRepository
{
    public interface IUserRepository
    {
        Task<int> AddUser(UserRegisterDetails userRegisterDetails);
        Task<List<UserRegisterDetails>> GetAllUsers();

        Task UpdateUser(UserRegisterDetails userRegisterDetails);
        Task<int> DeleteUser(int? id);
        Task<UserRegisterDetails> GetUser(int? id);
        Task<UserRegisterDetails> UserLogin(string username, string password);
        Task<UserRegisterDetails> GetUserByPhoneNumber(long? phno);
    }

}
