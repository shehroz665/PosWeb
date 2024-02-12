using Dapper;
using PosApi.IRepository;
using PosApi.Models;
using PosApi.Services;

namespace PosApi.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly SqlConnectionFactory _connection;
        public UserRepository(SqlConnectionFactory connection)
        {
            _connection = connection;
        }
        public async Task<List<User>> GetUsers()
        {
            using var connection= _connection.Create();
            string query = $@"SELECT * FROM [WEB].[USERS]";
            var result = await connection.QueryAsync<User>(query);
            return result.ToList();
        }
    }
}
