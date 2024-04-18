using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.Application.Interfaces.Services;
using DanderiTV.Layer.Application.Repositories;
using DanderiTV.Layer.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DanderiTV.Layer.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {

            #region Repository Injection

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<IDirectorRepository, DirectorRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            #endregion

            #region Services Injection
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IActorService, ActorsService>();
            services.AddTransient<IDirectorService, DirectorService>();
            services.AddTransient<IUserService, UserService>();
            #endregion

        }
    }
}
