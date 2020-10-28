using System.Threading.Tasks;
using DAMVC.Models.DB;

namespace DAMVC.Interfaces
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}