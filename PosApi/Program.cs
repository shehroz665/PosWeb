using PosApi.Endpoints;
using PosApi.IRepository;
using PosApi.Repository;
using PosApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("PosConnectionString");
    return new SqlConnectionFactory(connectionString);
});
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapUserEndpoints();
app.Run();

