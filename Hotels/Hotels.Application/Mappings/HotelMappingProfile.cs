using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using Hotels.Application.ApplicationUser;
using Hotels.Application.Hotel;
using Hotels.Application.Hotel.Commands.EditHotel;
using Hotels.Domain.Entities;

namespace Hotels.Application.Mappings
{
    public class HotelMappingProfile : Profile
    {
        public HotelMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<HotelDto, Domain.Entities.Hotel>().ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new HotelContactDetails()
            {
                City = src.City,
                PhoneNumber = src.PhoneNumber,
                PostalCode = src.PostalCode,
                Street = src.Street,
            }
            ));
            CreateMap<Domain.Entities.Hotel, HotelDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber)
            );

            CreateMap<HotelDto, EditHotelCommand>();
        }
    }
}
