using btw_api.Models;

namespace btw_api.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListUsers();
        Task<IEnumerable<Role>> GetRoles();
        Task<bool> CreateUser(User u);
        Task<bool> DeleteUser(int id);
    }
}
