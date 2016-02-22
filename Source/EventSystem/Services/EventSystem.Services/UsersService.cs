namespace EventSystem.Services
{
    using EventSystem.Data.Common.Repositories;
    using EventSystem.Models;
    using EventSystem.Services.Contracts;

    public class UsersService : IUsersService
    {
        private IDbGenericRepository<User, string> users;

        public UsersService(IDbGenericRepository<User, string> users)
        {
            this.users = users;
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }
    }
}
