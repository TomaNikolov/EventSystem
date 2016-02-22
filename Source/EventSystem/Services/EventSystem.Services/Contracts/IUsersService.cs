namespace EventSystem.Services.Contracts
{
    using EventSystem.Models;

    public interface IUsersService
    {
        User GetById(string id);

        void AddPhone(string id, string phoneNumber);
    }
}
