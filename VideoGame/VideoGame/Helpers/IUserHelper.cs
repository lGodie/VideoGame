using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using VideoGame.Data.Entities;
using VideoGame.Models;

namespace VideoGame.Helpers
{
    public interface IUserHelper
    {
        Task<SignInResult> LoginAsync(LoginDto model);

        Task LogoutAsync();

        Task<User> AddUser(AddUserDto view);

        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<IdentityResult> UpdateUserAsync(User user);
    }
}
