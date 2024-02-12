using Dapper;
using PosApi.IRepository;
using PosApi.Models;
using PosApi.Services;
using System.Data;

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
        public async Task<User> GetUser(User obj)
        {
            using var connection = _connection.Create();
            string query = $@"SELECT * FROM [WEB].[USERS]";
            var result = await connection.QueryAsync<User>(query);
            return result.First();
        }
        public async Task<User> CreateorUpdate(bool isNew, User obj)
        {
            using var connection = _connection.Create();
            var p = new DynamicParameters();
            p.Add("@CreateNew", isNew);
            p.Add("@UserKey",obj.UserKey);
            p.Add("@UserName",obj.UserName);
            p.Add("@Email",obj.Email);
            p.Add("@Password",obj.Password);
            p.Add("@OutputUserKey", obj.UserKey,dbType:DbType.Int32,direction:ParameterDirection.Output);
            var sp= await connection.QueryAsync<int>("[WEB].[spCreateUpdateUser]",p,commandType:CommandType.StoredProcedure);
            int userKey = p.Get<int>("@OutputUserKey");
            string query = $@"  SELECT * FROM [WEB].[Users] WHERE UserKey={userKey}";
            var result = await connection.QueryAsync<User>(query);
            return result.First();


        }
    }
}
