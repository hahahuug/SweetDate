using SweetDate.DAL.Interfaces;
using SweetDate.DAL.Repositories;
using SweetDate.Domain.Entity;
using SweetDate.Service.Implementations;
using SweetDate.Service.Interfaces;

namespace SweetDate;

public static class Initilaitize
{
    public static void InitializeRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBaseRepository<Person>, PersonRepository>();
        services.AddScoped<IBaseRepository<User>, UserRepository>();
    }

    public static void InitializeServices(this IServiceCollection services)
    {
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IProfilService, ProfilService>();
        services.AddScoped<IUserService, UserService>();
    }
}