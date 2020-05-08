using System.Threading.Tasks;
using backend.Models;

namespace backend.Data.Repositories
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);

        Task<User> Login(string username, string password);

        Task<bool> UserExists(string username);

    }
}