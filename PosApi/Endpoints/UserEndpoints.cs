using Dapper;
using PosApi.IRepository;
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
        }
    }
}
