using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hotels.Application.ApplicationUser;
using Hotels.Application.Hotel.Commands.CreateHotel;
using Hotels.Application.Hotel.Commands.EditHotel;
using Hotels.Application.Mappings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddMediatR(typeof(CreateHotelCommand));
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new HotelMappingProfile(userContext));
            }
             ).CreateMapper());
            services.AddAutoMapper(typeof(HotelMappingProfile));
            services.AddValidatorsFromAssemblyContaining<CreateHotelCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<EditHotelCommandValidator>()
               .AddFluentValidationAutoValidation()
               .AddFluentValidationClientsideAdapters();
        }
    }
}
