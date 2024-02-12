using PosApi.Models;

namespace PosApi.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
    }
}
