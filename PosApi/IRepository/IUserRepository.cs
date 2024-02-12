using PosApi.Models;

namespace PosApi.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();

        Task<User> GetUser(User obj);

        Task<User> CreateorUpdate(bool isNew, User obj);
    }
}
