using btw_api.Database;
using btw_api.Models;
using Microsoft.EntityFrameworkCore;

namespace btw_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private BtwApiContext _context;

        public UserRepository(BtwApiContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<User>> ListUsers()
        {
            IEnumerable<User> usersList = await _context.Users.Select(i => i).ToListAsync();
            return usersList;
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            IEnumerable<Role> rolesList = _context.Roles.Select(i => i)
                .Where(i => i.RoleName != "superadmin".ToLower());
            return rolesList;
        }

        public async Task<bool> CreateUser(User u)
        {
            try
            {
                await _context.AddAsync<User>(u);
                int affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
		        _context.Remove(new User() { Id = id }); // La mala pa la excepcion ObjectDisposeException .|.
                int affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }
            catch (Exception)
            {

                throw;
            } finally
            {
                _context.Dispose();
            }

        }
    }
}
