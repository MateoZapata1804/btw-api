using btw_api.Models;
using btw_api.Repository;

namespace btw_api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository r)
        {
            this._repo = r;
        }

        public List<User> GetUsers()
        {
			try
			{
                return _repo.ListUsers().Result.ToList();
			}
			catch (Exception)
			{
				throw;
			}
        }

        public List<Role> GetRoles()
        {
            try
            {
                return _repo.GetRoles().Result.ToList<Role>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> CreateUser(User u)
        {
            try
            {
                u.Password = Encrypter.EncryptField(u.Password);
                return _repo.CreateUser(u);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> DeleteUser(int id)
        {
            try
            {
                return _repo.DeleteUser(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
