using Dapper;
using PosApi.IRepository;
using PosApi.Models;
namespace PosApi.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("users", async(IUserRepository repo)=>
            {
                return await repo.GetUsers();
            });
            //builder.MapGet("user", async (IUserRepository repo,string email,string password) =>
            //{

            //});
            builder.MapPost("user", async (IUserRepository repo, User obj) =>
            {
               return await repo.CreateorUpdate(true, obj);
            });
            builder.MapPut("user", async (IUserRepository repo, User obj) =>
            {
               return await repo.CreateorUpdate(false, obj);
            });
        }
    }
}
