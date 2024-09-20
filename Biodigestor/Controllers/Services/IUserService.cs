using System.Threading.Tasks;
using Biodigestor.Models;

namespace Biodigestor.Controllers.Services
{
    public interface IUserService
    {
        Task<bool> UserExists(string? username);
        Task CreateUser(ApplicationUser user, string password);
        Task<ApplicationUser?> AuthenticateUser(string? username, string password);
        Task<string> HashPassword(string password);
    }
}