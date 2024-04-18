

using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DanderiTV.Layer.DataAccess
{
    public static class ServicesRegistration
    {
        static readonly IConfiguration _configuration;

        static ServicesRegistration()
        {
            
        }

        public static void AddDataAccessLayer
            (this IServiceCollection services,
            IServiceProvider serviceProvider)
        {



           




        }

    }
}
