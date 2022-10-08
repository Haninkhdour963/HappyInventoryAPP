using HappyInventoryAPP.Client.Shared;
using HappyInventoryAPP.Shared.Data;
using HappyInventoryAPP.Shared.Models;

namespace HappyInventoryAPP.Client.Services
{

    public interface IUserService
    {
        User User { get; }
        Task Initialize();
        Task Login(Login model);
        Task Logout();
        Task<PagedResult<User>> GetUsers(string? name, string page);
        Task<User> GetUser(int id);
        Task DeleteUser(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);

    }
}
