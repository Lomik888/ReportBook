using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReportBook.DAL.Interceptors;
using ReportBook.DAL.Repository;
using ReportBook.Domain.Entity;
using ReportBook.Domain.Interface.Repository;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ReportBook.DAL.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddDataAccessLayer(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseNpgsql(Env.GetString("CONNECTION"), b => b.MigrationsAssembly("ReportBook.API"));
            });

            services.AddSingleton<DateInterceptor>();

            services.InitRepository();
        }

        private static void InitRepository(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<UserEntity>, BaseRepository<UserEntity>>();
            services.AddScoped<IBaseRepository<ReportEntity>, BaseRepository<ReportEntity>>();
        }
    }
}
