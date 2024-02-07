using Hotels.Domain.Interfaces;
using Hotels.Infrastructure.Persistence;
using Hotels.Infrastructure.Repositories;
using Hotels.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Hotel")));
            services.AddDefaultIdentity<IdentityUser>()
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<HotelsDbContext>();

            services.AddScoped<HotelSeeder>();

            services.AddScoped<IHotelRepository, HotelRepository>();
        }
    }
}
