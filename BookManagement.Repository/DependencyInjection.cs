using BookManagement.Repository.EntityModels;
using BookManagement.Repository.Repository;
using BookManagement.Repository.Repository.IRepository;
using BookManagement.Service.Mapper;
using BookManagement.Service.Services;
using BookManagement.Service.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfractstructure(this IServiceCollection services, IConfiguration config)
        {
            // Configure UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MapperConfigs).Assembly);


            //add DJ here

            // Configure User services and repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();


            //Configure the local database connection
            services.AddDbContext<BookStoreContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("BookManagement"));
            });

            return services;
        }
    }
}
