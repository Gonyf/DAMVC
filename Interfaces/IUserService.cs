using DAMVC.Models;

namespace DAMVC.Interfaces
{
    public interface IUserService
    {
        User Get(int id);
        User Get(string userName);
    }
}
