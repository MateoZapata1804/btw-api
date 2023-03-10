using btw_api.Models;

namespace btw_api.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        List<Role> GetRoles();
        Task<bool> CreateUser(User u);
        Task<bool> DeleteUser(int id);
    }
}
