using EducaApi.Domain.Repositories;
using EducaApi.Infra.Data.Context;
using EducaApi.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EducaApi.Application.Profiles;
using EducaApi.Application.Services.Interfaces;
using EducaApi.Application.Services;
using EducaApi.Domain.Authentication;
using EducaApi.Infra.Data.Authentication;

namespace EducaApi.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
             services.AddDbContext<AppDbContext>(opts => opts
            .UseLazyLoadingProxies()
            .UseMySql(configuration
                .GetConnectionString("DbConnection"), new MySqlServerVersion(new Version())));

            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(TeacherProfile));
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            return services;
        }

    }
}
