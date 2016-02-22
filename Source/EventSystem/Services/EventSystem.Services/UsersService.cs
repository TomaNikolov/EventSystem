namespace EventSystem.Services
{
    using System;
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

        public void AddPhone(string id, string phoneNumber)
        {
            var user = this.GetById(id);
            user.PhoneNumber = phoneNumber;

            this.users.Save();           
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }
    }
}
